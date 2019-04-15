namespace rNascarTimingAndScoring.Models
{
    public class FavoriteDriver
    {
        public int SeriesId { get; set; }
        public string Driver { get; set; }

        public override string ToString()
        {
            return Driver;
        }
    }
}
