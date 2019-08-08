using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;

namespace SocietyProApi.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Championship")]
    public class ChampionshipController : Controller
    {
        private readonly IChampionshipRepository _championshipRepository;

        public ChampionshipController(IChampionshipRepository championshipRepository)
        {
            _championshipRepository = championshipRepository;
        }

        [HttpGet(Name = "Get_Championships")]
        public IEnumerable<Championship> Get()
        {
            return _championshipRepository.GetAll();
        }

        [HttpGet("GetPreInscription/", Name = "GetPreInscription")]
        public IEnumerable<Championship> GetPreInscription()
        {
            return _championshipRepository.GetPreInscription();
        }

        [HttpGet("GetChampionshipInscription/{id}", Name = "GetChampionshipInscription")]
        public IEnumerable<Championship> GetChampionshipInscription(int id)
        {
            return _championshipRepository.GetChampionshipInscription(id);
        }

    }
}