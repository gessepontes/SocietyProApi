using Microsoft.EntityFrameworkCore;
using SocietyProApi.Data.Repository.EntityFramework.Common;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace SocietyProApi.Data.Repository.EntityFramework
{
    public class FieldRepository : RepositoryBase<Field>, IFieldRepository
    {
        public override IEnumerable<Field> GetAll()
        {
            return db.Fields.OrderBy(p => p.NOME).ToList();
        }

        public override Field GetById(int? id)
        {
            return db.Fields.Include(p => p.FieldItens).Where(p => p.ID == id).FirstOrDefault();
        }
    }
}
