namespace PartyApp.Core.Model.Content
{
    public class Music : EntityBase
    {
        public string MusicName { get; set; }
        public int Duration { get; set; }
        public string PhysicalLocationUrl { get; set; }
        public string Artist { get; set; }
        //public virtual IList<MusicPublisher> Publishers { get; set; }
        //public virtual IList<MusicCategory> MusicCategories { get; set; }
    }
}
