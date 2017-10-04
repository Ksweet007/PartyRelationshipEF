namespace PartyApp.Core.Model.Content
{
    public class TextContent
    {
        public int TextContentId { get; set; }
        public int? TextContentTypeId { get; set; }
        public int? SequenceNumber { get; set; }
        public string TextValue { get; set; }
        public string Language { get; set; }
        public virtual Content Content { get; set; }
    }
}
