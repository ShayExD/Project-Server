using Microsoft.AspNetCore.Mvc;
using ProjectServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpPost("SignUp")]
        public bool SignUp([FromBody] User user)
        {
            return user.Registration();
        }

        [HttpPost("logIn")]
        public User LogIn(string email, [FromBody] string password)
        {
            return Models.User.LogIn(email, password);//אם יחזור יחזיר יוזר 
        }

        [HttpPost("addToFavorite")]
        public bool addSongToFavorite(int idUser, int idSong)
        {
            return Models.User.addSongToFavorite(idUser, idSong);
        }

        [HttpPost("deleteSongFromFavorite")]
        public bool deleteSongFromFavorite(int idUser, int idSong)
        {
            return Models.User.deleteSongFromFavorite(idUser, idSong);
        }

        [HttpGet]
        [Route("getAllUsers")]
        public List<User> getAllUsers()
        {
            return Models.User.getAllUsers();
        }



        [HttpGet]
        [Route("userFavoriteSongs")]
        public Dictionary<int, List<Song>> userFavoriteSongs(int idUser)
        {
            return Models.User.userFavoriteSongs(idUser);
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
