using PartyApp.Core.Enum;

namespace PartyApp.Core.Model.Content
{
    public class ContentUsage : EntityBase
    {
        public virtual ContentUsageTypeValues ContentUsageType { get; set; }
        public double? Sequence { get; set; }
        public int? GroupSequence { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public int? TagId { get; set; }
        public int? ActivityId { get; set; }
        public string QueryString { get; set; }
        public virtual ContentUsageStatusTypeValues ContentUsageStatusType { get; set; }

        public virtual Content Content { get; set; }

        public int ContentId { get; set; }
        //public virtual ImageContent ImageContent { get; set; }

        public int? ParentFeatureInstanceId { get; set; }
        public virtual FeatureInstance ParentFeatureInstance { get; set; }

    }
}
