namespace ProjectServer.Models
{
    public class Artist
    {
        public Artist()
        {
        }

        public Artist(string artistName, int occurrenceInFav)
        {
            ArtistName = artistName;
            OccurrenceInFav = occurrenceInFav;
        }
        public string ArtistName { get; set; }
        public int OccurrenceInFav { get; set; }


    }
}
