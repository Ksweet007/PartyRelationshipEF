using PartyApp.Core.Enum;
using PartyApp.Core.Interfaces;
using PartyApp.Core.Model;
using PartyApp.Core.Model.Content;
using PartyApp.Infrastructure.Data.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PartyApp.Infrastructure.Data
{
    public class ContentRepository : IContentRepository
    {
        private readonly ContentDbContext _db;
        public ContentRepository(ContentDbContext db)
        {
            _db = db;
        }

        public Movie GetMovieByCmiId(int cmiId)
        {
            return _db.Movies.Single(m => m.CMIId == cmiId);
        }

        public FeatureInstance GetMovieFeatureInstanceByCmiId(int cmiId)
        {
            return _db.FeatureInstances
                .Include(f => f.ContentUsages.Select(x => x.Content))
                .SingleOrDefault(f => f.Feature == FeatureValues.Movie && f.CMIId == cmiId);
        }

        public IList<ContentUsage> ListContentUsagesByCmiId(int cmiId)
        {
            var featureInstance = _db.FeatureInstances
                .Include(f => f.ContentUsages.Select(x => x.Content))
                .SingleOrDefault(f => f.Feature == FeatureValues.Movie && f.CMIId == cmiId);

            return featureInstance?.ContentUsages?.ToList();
        }

        //private bool IsContentAvailable(ContentUsage contentUsage)
        //{
        //    return contentUsage.ContentUsageStatusType == ContentUsageStatusTypeValues.Available
        //        && (contentUsage.ImageContent.EffectiveEndDate == null || contentUsage.ImageContent.EffectiveEndDate > DateTime.Now);
        //}

    }
}
