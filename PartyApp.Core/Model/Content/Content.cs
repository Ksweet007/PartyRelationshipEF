using System;
using System.Collections.Generic;

namespace PartyApp.Core.Model.Content
{
    public class Content : EntityBase
    {
        public Content()
        {
            ContentUsages = new HashSet<ContentUsage>();
        }

        public string ContentCaption { get; set; }
        public string ContentDescription { get; set; }
        public int ContentTypeId { get; set; }
        public string ContentName { get; set; }
        public int? ContentOriginTypeId { get; set; }
        public int? ParentContentId { get; set; }
        public DateTime? ContentAcquiredDate { get; set; }
        public int? StorageUnitTypeId { get; set; }
        public decimal? StorageUnits { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime? EffectiveEndDate { get; set; }
        public int? SourceID { get; set; }
        public string SourceDesc { get; set; }
        public int? SourceContentId { get; set; }
        public string UploadSessionId { get; set; }
        public int? ContentAcquiredTypeId { get; set; }
        public string submittedBy { get; set; }
        public virtual ICollection<ContentUsage> ContentUsages { get; set; }

        //public int ImageContentId { get; set; }
        //public virtual ImageContent ImageContent { get; set; }
        public virtual MediaContent MediaContent { get; set; }
        public virtual TextContent TextContent { get; set; }
    }
}
