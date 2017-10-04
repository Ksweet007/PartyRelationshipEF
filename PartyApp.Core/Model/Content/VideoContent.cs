using System;

namespace PartyApp.Core.Model.Content
{
    public class VideoContent
    {
        public int VideoContentId { get; set; }
        public int? Duration { get; set; }
        public DateTime? VideoCreateDate { get; set; }
        public string ThumbnailURL { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public virtual MediaContent MediaContent { get; set; }
    }
}
