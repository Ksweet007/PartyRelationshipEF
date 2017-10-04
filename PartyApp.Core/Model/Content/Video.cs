using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Core.Model.Content
{
    public class Video : EntityBase, IComparable<Video>
    {
        public int FiId { get; set; }
        public int VideoContentId { get; set; }
        public string BaseUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public int Duration { get; set; }
        public string Caption { get; set; }
        public float Sequence { get; set; }
        public bool IsPendingApproval { get; set; }
        public string AcquireDate { get; set; }
        public string SubmittedBy { get; set; }
        public string Origin { get; set; }
        public string AcquisitionType { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool IsProcessing { get; set; }

        public string ContentRolePartyName { get; set; }
        public int CompareTo(Video other)
        {
            return null == other ? 1 : Sequence.CompareTo(other.Sequence);
        }
    }
}
