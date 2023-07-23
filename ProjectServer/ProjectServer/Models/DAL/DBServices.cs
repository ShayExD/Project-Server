using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using ProjectServer.Models;

    namespace ProjectServer.Models.DAL
{
    public class DBservices
    {
        public DBservices()
        {

        }

        //------User Services------//
        public bool Insert(User user)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@username", user.Username);
            paramDic.Add("@email", user.Email);
            paramDic.Add("@password", user.Password);


            cmd = CreateCommandWithStoredProcedure("InsertUser", con, paramDic);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                /*int numEffected = Convert.ToInt32(cmd.ExecuteScalar());*/ // returning the id
                return numEffected == 1;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        public List<User> getAllUsers()
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }


            cmd = CreateCommandWithStoredProcedure("getAllUsers", con, null);             // create the command


            List<User> UserList = new List<User>();

            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(dataReader["id"]);
                    user.Username = dataReader["username"].ToString();
                    user.Email = dataReader["email"].ToString();
                    user.Password = dataReader["password"].ToString();
                    user.Registrationdate = dataReader["registrationdate"].ToString();
                    UserList.Add(user);
                }
                return UserList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        public User LogIn(string email, string password)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@email", email);
            paramDic.Add("@password", password);


            cmd = CreateCommandWithStoredProcedure("LoginUser", con, paramDic);             // create the command

            User user = new User();


            try
            {

                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    user.Id = Convert.ToInt32(dataReader["id"]);
                    user.Email = dataReader["email"].ToString();
                    user.Password = dataReader["password"].ToString();
                    user.Username = dataReader["username"].ToString();
                    user.Registrationdate = dataReader["registrationdate"].ToString();

                }
                if (user.Email == null)
                {
                    throw new Exception("User Doesnt exits");
                }
                return user;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        public bool addSongToFavorite(int idUser, int idSong)  //פונקציה שלא מחזירה ערך
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@idUser", idUser);
            paramDic.Add("@idSong", idSong);



            cmd = CreateCommandWithStoredProcedure("InsertSongToFavorites", con, paramDic);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                //int numEffected = Convert.ToInt32(cmd.ExecuteScalar()); // returning the id
                return numEffected == 1;
            }

            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        public bool deleteSongFromFavorite(int idUser, int idSong)  //פונקציה שלא מחזירה ערך
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@idUser", idUser);
            paramDic.Add("@idSong", idSong);


            cmd = CreateCommandWithStoredProcedure("DeleteSongFromFavorites", con, paramDic);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                //int numEffected = Convert.ToInt32(cmd.ExecuteScalar()); // returning the id
                return numEffected == 1;
            }

            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        
        //------Song Services------//
        public List<Song> getAllSongs()
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }


            cmd = CreateCommandWithStoredProcedure("GetAllSongs", con, null);             // create the command


            List<Song> SongList = new List<Song>();

            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    Song s = new Song();
                    s.Id = Convert.ToInt32(dataReader["id"]);
                    s.Artist = dataReader["artist"].ToString();
                    s.SongName = dataReader["song"].ToString();
                    s.Lyrics = dataReader["text"].ToString();
                    SongList.Add(s);
                }
                return SongList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        public List<Song> getSongsByArtist(string artist)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@artist", artist);

            cmd = CreateCommandWithStoredProcedure("GetSongByArtist", con, paramDic);            // create the command


            List<Song> SongList = new List<Song>();

            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    Song s = new Song();
                    s.Id = Convert.ToInt32(dataReader["id"]);
                    s.Artist = dataReader["artist"].ToString();
                    s.SongName = dataReader["song"].ToString();
                    s.Lyrics = dataReader["text"].ToString();
                    SongList.Add(s);
                }
                return SongList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        public List<Song> getSongsBySongName(string songName)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@SongName", songName);

            cmd = CreateCommandWithStoredProcedure("GetSongByName", con, paramDic);            // create the command


            List<Song> SongList = new List<Song>();

            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    Song s = new Song();
                    s.Id = Convert.ToInt32(dataReader["id"]);
                    s.Artist = dataReader["artist"].ToString();
                    s.SongName = dataReader["song"].ToString();
                    s.Lyrics = dataReader["text"].ToString();
                    SongList.Add(s);
                }
                return SongList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        public List<Song> getSongsByLyrics(string lyrics)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@songText", lyrics);

            cmd = CreateCommandWithStoredProcedure("GetSongByText", con, paramDic);            // create the command


            List<Song> SongList = new List<Song>();

            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    Song s = new Song();
                    s.Id = Convert.ToInt32(dataReader["id"]);
                    s.Artist = dataReader["artist"].ToString();
                    s.SongName = dataReader["song"].ToString();
                    s.Lyrics = dataReader["text"].ToString();
                    SongList.Add(s);
                }
                return SongList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }


        public Dictionary<int, List<Song>> userFavoriteSongs(int idUser)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@idUser", idUser);

            cmd = CreateCommandWithStoredProcedure("UserFavoritesSongs", con, paramDic);            // create the command


            List<Song> SongList = new List<Song>();
            Dictionary<int,List<Song>> DicUserIdAndSongs = new Dictionary<int, List<Song>>();



            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    Song s = new Song();
                    s.Id = Convert.ToInt32(dataReader["idSong"]);
                    s.SongName = dataReader["song"].ToString();
                    s.Artist = dataReader["artist"].ToString();
                    s.Lyrics = dataReader["text"].ToString();
                    SongList.Add(s);
                }
                DicUserIdAndSongs.Add(idUser, SongList);

                return DicUserIdAndSongs;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }


        public List<string> GetAllArtists()
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }


            cmd = CreateCommandWithStoredProcedure("GetAllArtists", con, null);             // create the command


            List<string> ArtistList = new List<string>();

            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    string nameOfArtist= dataReader["artist"].ToString(); ;

                    ArtistList.Add(nameOfArtist);
                }
                return ArtistList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }


        public List<Artist> getArtistCountInFavorite()
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }


            cmd = CreateCommandWithStoredProcedure("ArtistCountInFavorite", con, null);             // create the command


            List<Artist> ArtistList = new List<Artist>();

            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    Artist artist = new Artist();
                    artist.ArtistName = dataReader["artist"].ToString();
                    artist.OccurrenceInFav = Convert.ToInt32(dataReader["occurrenceCount"]); 
                    ArtistList.Add(artist);
                }
                return ArtistList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        public List<Song> getSongsCountInFavorite()
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }


            cmd = CreateCommandWithStoredProcedure("SongsCountInFavorite", con, null);             // create the command


            List<Song> SongList = new List<Song>();

            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    Song s = new Song();
                    s.SongName = dataReader["song"].ToString();
                    s.OccurrenceInFav = Convert.ToInt32(dataReader["occurrenceCount"]);
                    SongList.Add(s);
                }
                return SongList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }






        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();
            string cStr = configuration.GetConnectionString("myProjDB");
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }
        private SqlCommand CreateCommandWithStoredProcedure(String spName, SqlConnection con, Dictionary<string, object> paramDic)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

            if (paramDic != null)
                foreach (KeyValuePair<string, object> param in paramDic)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);

                }


            return cmd;
        }
    }
}
