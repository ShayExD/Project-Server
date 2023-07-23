using ProjectServer.Models.DAL;

namespace ProjectServer.Models
{
    public class User
    {

        public User()
        {

        }

        public User(int id, string email, string password, string username, string registrationdate)
        {
            Id = id;
            Email = email;
            Password = password;
            Username = username;
            Registrationdate = registrationdate;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Registrationdate { get; set; }



        public static bool addSongToFavorite(int idUser, int idSong)
        {
            DBservices dbs = new DBservices();
            return dbs.addSongToFavorite(idUser, idSong);
        }

        public static bool deleteSongFromFavorite(int idUser, int idSong)
        {
            DBservices dbs = new DBservices();
            return dbs.deleteSongFromFavorite(idUser, idSong);
        }

        public bool Registration()
        {
            DBservices dbs = new DBservices();
            return dbs.Insert(this);
        }

        public static User LogIn(string email, string password)
        {
            DBservices dbs = new DBservices();
            return dbs.LogIn(email, password);


        }

        public static Dictionary<int, List<Song>> userFavoriteSongs(int idUser)
        {
            DBservices dbs = new DBservices();
            return dbs.userFavoriteSongs(idUser);
        }

        public static List<User> getAllUsers()
        {
            DBservices dbs = new DBservices();
            return dbs.getAllUsers();
        }


    }
}

