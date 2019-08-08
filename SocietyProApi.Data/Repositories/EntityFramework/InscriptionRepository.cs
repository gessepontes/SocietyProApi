using SocietyProApi.Data.Repository.EntityFramework.Common;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace SocietyProApi.Data.Repository.EntityFramework
{
    public class InscriptionRepository : RepositoryBase<Inscription>, IInscriptionRepository
    {
    }
}
