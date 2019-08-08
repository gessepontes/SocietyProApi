using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;

namespace SocietyProApi.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Player")]
    public class PlayerController : Controller
    {

        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }


        // GET: api/Player
        [HttpGet(Name = "Get_Players")]
        public IEnumerable<Player> Get()
        {
            return _playerRepository.GetAll();
        }

        // GET: api/Player/5
        [HttpGet("{id}", Name = "GetPlayer")]
        public Player Get(int id)
        {
            return _playerRepository.GetById(id);
        }

        [HttpGet("GetPlayerTeam/{id}", Name = "GetPlayerTeam")]
        public IEnumerable<Player> GetPlayerTeam(int id)
        {
            return _playerRepository.GetPlayerTeam(id);
        }

        // POST: api/Player
        [HttpPost]
        public void Post([FromBody]Player value)
        {
            _playerRepository.Add(value);
        }

        // PUT: api/Player/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Player value)
        {
            _playerRepository.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Player Player = _playerRepository.GetById(id);
            _playerRepository.Remove(Player);
        }
    }
}
