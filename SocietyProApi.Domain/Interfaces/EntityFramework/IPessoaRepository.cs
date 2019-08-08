using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.Common;

namespace SocietyProApi.Domain.Interfaces.EntityFramework
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa> {

        Pessoa Authenticate(string email,string password);
    }
}
