using Microsoft.EntityFrameworkCore;
using SocietyProApi.Data.Repository.EntityFramework.Common;
using SocietyProApi.Domain.Diversos;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace SocietyProApi.Data.Repository.EntityFramework
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public Pessoa Authenticate(string email, string password)
        {
            var _pessoa = db.Pessoas.Include(x => x.PessoaPerfis).FirstOrDefault(x => x.EMAIL == email && x.SENHA == password);

            if (_pessoa == null)
                return null;

            _pessoa.token = Diverso.GetBuildToken(_pessoa.EMAIL);
            return _pessoa;
        }

        public override IEnumerable<Pessoa> GetAll() =>
            db.Pessoas.Include(x => x.PessoaPerfis).ToList();

        public override Pessoa GetById(int? id) {
            Pessoa _p = db.Pessoas.Include(x => x.PessoaPerfis).FirstOrDefault(x => x.ID == id);

            _p.SENHA = "";
            return _p;
        } 
    }
}
