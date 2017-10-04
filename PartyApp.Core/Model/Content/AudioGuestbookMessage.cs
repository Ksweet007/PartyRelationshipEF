using System;

namespace PartyApp.Core.Model.Content
{
    public class AudioGuestbookMessage : EntityBase, IComparable<AudioGuestbookMessage>
    {
        public int AudioGuestBookMessageId { get; set; }
        public double Sequence { get; set; }
        public string Caption { get; set; }
        public int Duration { get; set; }
        public string PhysicalLocationUrl { get; set; }

        public int CompareTo(AudioGuestbookMessage other)
        {
            return null == other ? 1 : Sequence.CompareTo(other.Sequence);
        }
    }
}
