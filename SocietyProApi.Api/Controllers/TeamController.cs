using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;

namespace SocietyProApi.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Team")]
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        // GET: api/Team
        [HttpGet(Name = "Get_Team")]
        public IEnumerable<Team> Get()
        {
            return _teamRepository.GetAll().Take(20);
        }

        [HttpGet("GetTeamPerson/{id}", Name = "GetTeamPerson")]
        public IEnumerable<Team> GetTeamPerson(int id)
        {
            return _teamRepository.GetTeamPerson(id);
        }

        // GET: api/Team/5
        [HttpGet("{id}", Name = "GetTeam")]
        public Team Get(int id)
        {
            return _teamRepository.GetById(id);
        }

        // POST: api/Team
        [HttpPost]
        public void Post([FromBody]Team value)
        {
            _teamRepository.Add(value);
        }
        
        // PUT: api/Team/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Team value)
        {
            _teamRepository.Update(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Team Player = _teamRepository.GetById(id);
            _teamRepository.Remove(Player);
        }
    }
}
