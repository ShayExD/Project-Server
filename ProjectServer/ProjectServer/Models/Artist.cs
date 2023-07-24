using ProjectServer.Models.DAL;

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

        public static List<Artist> getArtistCountInFavorite()
        {
            DBservices dbs = new DBservices();
            return dbs.getArtistCountInFavorite();
        }






    }

}
