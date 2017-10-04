using PartyApp.Core.Model.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Core.Model
{
    public class MediaContainer //Seems like a good candidate for aggregate
    {
        public bool UseImageDefault { get; set; }
        public bool UseVideoDefault { get; set; }
        public int? TitleImageId { get; set; }
        public virtual IList<Image> Images { get; set; } = new List<Image>();
        public virtual IList<Video> Videos { get; set; } = new List<Video>();
    }
}
