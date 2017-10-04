using PartyApp.Core.Model;
using PartyApp.Core.Model.Content;
using System.Collections.Generic;

namespace PartyApp.Core.Interfaces
{
    public interface IContentRepository
    {
        Movie GetMovieByCmiId(int cmiId);
        FeatureInstance GetMovieFeatureInstanceByCmiId(int cmiId);
        IList<ContentUsage> ListContentUsagesByCmiId(int cmiId);
    }
}
