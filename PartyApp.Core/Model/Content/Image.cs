using System;

namespace PartyApp.Core.Model.Content
{
    public class Image : EntityBase, IComparable<Image>
    {
        public DateTime? AcquireDate { get; set; }
        public string AcquisitionType { get; set; }
        public double AspectRatio { get; set; }
        public string BaseURL { get; set; }
        public string Caption { get; set; }
        public string ContentUsageTypeDesc { get; set; }
        public int ImageId { get; set; }
        public bool IsDefault => ContentUsageTypeDesc?.ToLower() == "default image";
        public bool IsPendingApproval { get; set; }
        public bool IsPrimary { get; set; }
        public string Origin { get; set; }
        public string QueryString { get; set; }
        public double Sequence { get; set; }
        public string SubmittedBy { get; set; }

        public int CompareTo(Image other)
        {
            return null == other ? 1 : Sequence.CompareTo(other.Sequence);
        }
    }
}
