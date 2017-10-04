namespace PartyApp.Core.Model.Content
{
    public class MovieMusicSelection : EntityBase
    {
        public int MusicId { get; set; }
        public int MovieId { get; set; }
        public double Sequence { get; set; }
        public virtual Music Music { get; set; }
    }
}
