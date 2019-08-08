using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.Common;
using System.Collections.Generic;

namespace SocietyProApi.Domain.Interfaces.EntityFramework
{
    public interface ITeamRepository : IRepositoryBase<Team> {
        IEnumerable<Team> GetTeamPerson(int id);
    }
}
