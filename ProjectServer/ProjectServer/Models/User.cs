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

