using Microsoft.AspNetCore.Mvc;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;

namespace SocietyProApi.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;

        public AuthController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpPost]
        public Pessoa Post([FromBody]Pessoa value)

        {
            if (string.IsNullOrEmpty(value.EMAIL) || string.IsNullOrEmpty(value.SENHA))
                return null;

            var _pessoa = _pessoaRepository.Authenticate(value.EMAIL, value.SENHA);

            return _pessoa;
        }
    }
}
