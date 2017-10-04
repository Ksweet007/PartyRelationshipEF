using PartyApp.Core.Enum;
using PartyApp.Core.Model.Content;
using System.Collections.Generic;

namespace PartyApp.Core.Model
{
    public class FeatureInstance
    {
        public int FeatureInstanceId { get; set; }
        public virtual FeatureValues Feature { get; set; }
        //public int FeatureId { get; set; }
        public int? FeatureInstanceStatusTypeId { get; set; }
        public int CMIId { get; set; }

        public virtual IList<ContentUsage> ContentUsages { get; set; } = new List<ContentUsage>();
        //public virtual IList<ContentUsage> ParentContentUsages { get; set; } = new List<ContentUsage>();
    }
}
