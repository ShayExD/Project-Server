using ProjectServer.Models.DAL;

namespace ProjectServer.Models
{
    namespace ProjectServer.Models
    {
        public class User
        {
            public User() { }

            public User(int id, string username, string email, string password, string registrationdate)
            {
                this.Id = id;
                Username = username;
                Email = email;
                Password = password;
                Registrationdate = registrationdate;
            }

            public int Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Registrationdate { get; set; }

            public static bool addSongToFavorite(int idUser, int idSong)
            {
                DBservices dbs = new DBservices();
                return dbs.addSongToFavorite(idUser, idSong);
            }

            public static bool deleteSongToFavorite(int idUser, int idSong)
            {
                DBservices dbs = new DBservices();
                return dbs.deleteSongToFavorite(idUser, idSong);
            }

            //public static List<User> getNotAllUserUsers(int id)
            //{
            //    DBservices dbs = new DBservices();
            //    return dbs.getNotUserUsers(id);
            //}

            //public static bool addUser(int idUser, int idUser)
            //{
            //    DBservices dbs = new DBservices();
            //    return dbs.addUser(idUser, idUser);
            //}
        }
    }

}
