using PartyApp.Core.Enum;
using PartyApp.Core.Interfaces;
using PartyApp.Core.Model.Content;
using PartyRelationshipEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static PartyRelationshipEF.ConsoleLoggers.Writer;
using static System.Console;

namespace PartyRelationshipEF
{
    public class ContentProcessor : IContentProcessor
    {
        private readonly IContentRepository _contentRepo;

        public ContentProcessor(IContentRepository contentRepo)
        {
            _contentRepo = contentRepo;
        }

        public void RunApp()
        {
            //Go Get FeatureInstanceId by CmiId and FeatureId 84 for premium movie 18 for Movie
            Prompt("Enter CmiId");
            WriteLine("");

            //var cmiId = ReadLine();
            var cmiId = 6634491;

            var contentTimer = new Stopwatch();
            contentTimer.Start();

            var movieUserData = _contentRepo.GetMovieByCmiId(cmiId);
            WriteLine($"Total Time to load User Data - {contentTimer.Elapsed}");

            var movieContentUsages = _contentRepo.ListContentUsagesByCmiId(cmiId);
            contentTimer.Stop();
            WriteLine($"Total Time to load Content - {contentTimer.Elapsed}");

            var imageContentUsages = movieContentUsages.Where(IsImageContent).ToList();
            PopulateMovieImages(movieUserData, imageContentUsages);
        }

        private bool IsImageContent(ContentUsage contentUsage)
        {
            return contentUsage.ContentUsageType == ContentUsageTypeValues.Image ||
                   contentUsage.ContentUsageType == ContentUsageTypeValues.PrimaryPhoto ||
                   contentUsage.ContentUsageType == ContentUsageTypeValues.DefaultImage;
        }

        private void PopulateMovieImages(Movie movie, IList<ContentUsage> imageList)
        {
            foreach (var cuImage in imageList)
            {
                var image = new Image
                {
                    Id = cuImage.Id,
                    ImageId = cuImage.Content.Id,
                    Sequence = cuImage.Sequence ?? 0
                };

                movie.AddImage(image);
            }
        }

    }
}
