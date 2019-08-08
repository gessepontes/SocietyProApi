using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.Common;
using System.Collections.Generic;

namespace SocietyProApi.Domain.Interfaces.EntityFramework
{
    public interface IPlayerRepository : IRepositoryBase<Player> {
        IEnumerable<Player> GetPlayerTeam(int id);
    }
}
