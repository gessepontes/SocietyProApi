using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.Common;
using System.Collections.Generic;

namespace SocietyProApi.Domain.Interfaces.EntityFramework
{
    public interface IChampionshipRepository : IRepositoryBase<Championship> {
        IEnumerable<Championship> GetPreInscription();
        IEnumerable<Championship> GetChampionshipInscription(int id);
    }
}
