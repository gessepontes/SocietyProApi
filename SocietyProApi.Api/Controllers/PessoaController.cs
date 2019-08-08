using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;

namespace SocietyProApi.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Pessoa")]
    public class PessoaController : Controller
    {

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }


        // GET: api/Pessoa
        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            return _pessoaRepository.GetAll().Take(5);
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}", Name = "Get")]
        public Pessoa Get(int id)
        {
            return _pessoaRepository.GetById(id);
        }

        // POST: api/Pessoa
        [HttpPost]
        public void Post([FromBody]Pessoa value)
        {
            _pessoaRepository.Add(value);
        }

        // PUT: api/Pessoa/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Pessoa value)
        {
            _pessoaRepository.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Pessoa pessoa = _pessoaRepository.GetById(id);
            _pessoaRepository.Remove(pessoa);
        }
    }
}
