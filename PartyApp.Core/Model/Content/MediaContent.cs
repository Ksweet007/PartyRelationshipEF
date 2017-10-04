namespace PartyApp.Core.Model.Content
{
    public class MediaContent
    {
        public int MediaContentId { get; set; }
        public int? MediaContentTypeId { get; set; }
        public int? SequenceNumber { get; set; }
        public int? AuditId { get; set; }
        public string PhysicalLocationURL { get; set; }
        //public virtual AudioContent AudioContent { get; set; }
        public virtual Content Content { get; set; }
        public virtual ImageContent ImageContent { get; set; }
        //public virtual VideoContent VideoContent { get; set; }
    }
}
