using Microsoft.AspNetCore.Mvc;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;
using System;
using System.Collections.Generic;

namespace SocietyProApi.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Scheduling")]
    public class SchedulingController : Controller
    {
        private readonly ISchedulingRepository _schedulingRepository;

        public SchedulingController(ISchedulingRepository schedulingRepository)
        {
            _schedulingRepository = schedulingRepository;
        }

        [HttpGet("GetHorary/{id}/{data}", Name = "GetHorary")]
        public IEnumerable<SchedulingAPI> GetHorary(int id, string data)
        {
            return _schedulingRepository.GetHorary(id, Convert.ToDateTime(data));
        }

        [HttpGet("GetFieldScheduling/{idCampo}/{idPessoa}", Name = "GetFieldScheduling")]
        public IEnumerable<HoraryComplete> GetFieldScheduling(int idCampo, int idPessoa)
        {
            return _schedulingRepository.GetFieldScheduling(idCampo, idPessoa);
        }

        [HttpGet("GetTicket/{id}", Name = "GetTicket")]
        public HoraryComplete GetTicket(int id)
        {
            return _schedulingRepository.GetTicket(id);
        }

        [HttpPost]
        public void Post([FromBody]Scheduling value)
        {
            _schedulingRepository.Add(value);
        }

        [HttpPut("PutCancel/", Name = "PutCancel")]
        public void Put([FromBody]Scheduling value)
        {
            Scheduling scheduling = _schedulingRepository.GetById(value.ID);
            scheduling.STATUS = "C";
            _schedulingRepository.Update(scheduling);
        }
    }
}