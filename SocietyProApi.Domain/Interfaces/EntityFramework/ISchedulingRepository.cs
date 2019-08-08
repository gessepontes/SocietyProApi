using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;

namespace SocietyProApi.Domain.Interfaces.EntityFramework
{
    public interface ISchedulingRepository : IRepositoryBase<Scheduling> {
        IEnumerable<SchedulingAPI> GetHorary(int id, DateTime Data);
        IEnumerable<HoraryComplete> GetFieldScheduling(int idCampo, int idPessoa);
        HoraryComplete GetTicket(int id);
    }
}
