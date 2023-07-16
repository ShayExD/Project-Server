using ProjectServer.Models.DAL;

namespace WebApplication1.Models
{
    namespace WebApplication1.Models
    {
        public class Song
        {

            public Song(int id, string artist, string songName, string lyrics)
            {
                Id = id;
                Artist = artist;
                SongName = songName;
                Lyrics = lyrics;
            }
            public Song() { }

            public int Id { get; set; }
            public string Artist { get; set; }
            public string SongName { get; set; }
            public string Lyrics { get; set; }

            public static List<Song> getAllSongs()
            {
                DBservices dbs = new DBservices();
                return dbs.getAllSongs();
            }

            //public static List<Song> getNotAllUserSongs(int id)
            //{
            //    DBservices dbs = new DBservices();
            //    return dbs.getNotUserSongs(id);
            //}

            //public static bool addSong(int idUser, int idSong)
            //{
            //    DBservices dbs = new DBservices();
            //    return dbs.addSong(idUser, idSong);
            //}
        }
    }

}
