namespace PartyApp.Core.Model.Content
{
    public class AudioContent : EntityBase
    {
        public int AudioContentId { get; set; }
        public int? AudioContentTypeId { get; set; }
        public string CallerId { get; set; }
        public byte[] CallerIdData { get; set; }
        public int? Duration { get; set; }
        public virtual MediaContent MediaContent { get; set; }
    }
}
