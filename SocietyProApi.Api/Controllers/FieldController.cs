using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;

namespace SocietyProApi.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Field")]
    public class FieldController : Controller
    {
        private readonly IFieldRepository _fieldRepository;

        public FieldController(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        // GET: api/Field
        [HttpGet(Name = "Get_Fields")]
        public IEnumerable<Field> Get()
        {
            return _fieldRepository.GetAll();
        }

        // GET: api/Field/5
        [HttpGet("{id}", Name = "GetField")]
        public Field Get(int id)
        {
            return _fieldRepository.GetById(id);
        }

        // POST: api/Field
        [HttpPost]
        public void Post([FromBody]Field value)
        {
            _fieldRepository.Add(value);
        }

        // PUT: api/Field/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Field value)
        {
            _fieldRepository.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Field field = _fieldRepository.GetById(id);
            _fieldRepository.Remove(field);
        }
    }
}
