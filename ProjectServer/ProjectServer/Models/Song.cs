using ProjectServer.Models.DAL;

    namespace ProjectServer.Models
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

        public Song(string songName, int occurrenceInFav)
        {
            Id = 0;
            Artist = "";
            SongName = songName;
            Lyrics = "";
            OccurrenceInFav = occurrenceInFav;
        }

            public int Id { get; set; }
            public string Artist { get; set; }
            public string SongName { get; set; }
            public string Lyrics { get; set; }
            public int OccurrenceInFav { get; set; }
        public static List<Song> getAllSongs()
            {
                DBservices dbs = new DBservices();
                return dbs.getAllSongs();
            }

        public static List<Song> getSongsByArtist(string artist)
        {
            DBservices dbs = new DBservices();
            return dbs.getSongsByArtist(artist);
        }

        public static List<Song> getSongsBySongName(string songName)
        {
            DBservices dbs = new DBservices();
            return dbs.getSongsBySongName(songName);
        }

        public static List<Song> getSongsByLyrics(string lyrics)
        {
            DBservices dbs = new DBservices();
            return dbs.getSongsByLyrics(lyrics);
        }

        public static List<string> GetAllArtists()
        {
            DBservices dbs = new DBservices();
            return dbs.GetAllArtists();
        }

        public static List<Artist> getArtistCountInFavorite()
        {
            DBservices dbs = new DBservices();
            return dbs.getArtistCountInFavorite();
        }

        public static List<Song> getSongsCountInFavorite()
        {
            DBservices dbs = new DBservices();
            return dbs.getSongsCountInFavorite();
        }


    }
    }

