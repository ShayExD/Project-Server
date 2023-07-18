﻿using Microsoft.AspNetCore.Mvc;
using ProjectServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {

        [HttpGet]
        [Route("GetAllSongs")]
        public List<Song> GetByPrice()
        {
            return Song.getAllSongs();
        }

        [HttpGet]
        [Route("getSongsByArtist")]
        public List<Song> getSongsByArtist(string artist)
        {
            return Song.getSongsByArtist(artist);
        }

        [HttpGet]
        [Route("getSongsBySongName")]
        public List<Song> getSongsBySongName(string songName)
        {
            return Song.getSongsBySongName(songName);
        }

        [HttpGet]
        [Route("getSongsByLyrics")]
        public List<Song> getSongsByLyrics(string lyrics)
        {
            return Song.getSongsByLyrics(lyrics);
        }

        // GET: api/<SongController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SongController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
