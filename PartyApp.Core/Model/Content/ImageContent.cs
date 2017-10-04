using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Core.Model.Content
{
    public class ImageContent
    {
        public int ImageContentId { get; set; }
        public double? AspectRatio { get; set; }
        public int? OrigHeight { get; set; }
        public int? OrigWidth { get; set; }
        public int? HorizontalDPI { get; set; }
        public int? VerticalDPI { get; set; }
        public string QueryString { get; set; }
        public string Device { get; set; }
        public DateTime? ImageCreateDate { get; set; }
        public string UserIP { get; set; }
        public virtual MediaContent MediaContent { get; set; }
    }
}
