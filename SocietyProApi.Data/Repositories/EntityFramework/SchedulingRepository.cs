using Microsoft.EntityFrameworkCore;
using SocietyProApi.Data.Repository.EntityFramework.Common;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

using static SocietyProApi.Domain.Diversos.Diverso;

namespace SocietyProApi.Data.Repository.EntityFramework
{
    public class SchedulingRepository : RepositoryBase<Scheduling>, ISchedulingRepository
    {
        public IEnumerable<HoraryComplete> GetFieldScheduling(int idCampo, int idPessoa)
        {
            IQueryable<int> hp = from p in db.Horarys
                                 where (p.FieldItem.IDCAMPO == idCampo)
                                 select p.ID;

            IQueryable<int> he = from p in db.HoraryExtras
                                 where (p.FieldItem.IDCAMPO == idCampo)
                                 select p.ID;

            List<Scheduling> hap = db.Schedulings.Where(p => hp.Contains(p.IDHORARIO) && p.TIPOHORARIO == TipoHorario.Padrao && p.IDPESSOA == idPessoa).ToList();
            List<Scheduling> hae = db.Schedulings.Where(p => he.Contains(p.IDHORARIO) && p.TIPOHORARIO == TipoHorario.Extra && p.IDPESSOA == idPessoa).ToList();

            List<HoraryComplete> listTotal = new List<HoraryComplete>();

            foreach (var item in hap)
            {
                HoraryComplete hpc = new HoraryComplete();

                hpc.ID = item.ID;
                hpc.DATA = item.DATA;

                if (item.STATUS == "A")
                {
                    hpc.STATUS = "Aprovado";
                }
                else if (item.STATUS == "C")
                {
                    hpc.STATUS = "Cancelado";
                }
                else if (item.STATUS == "P")
                {
                    hpc.STATUS = "Pendente";
                }


                Horary h = db.Horarys.Include(b => b.FieldItem).Include(b => b.FieldItem.Field).Where(b => b.ID == item.IDHORARIO).FirstOrDefault();

                hpc.HORA = h.HORARIO;
                hpc.CAMPO = h.FieldItem.DESCRICAO;
                hpc.LOGO = h.FieldItem.Field.LOGO;
                hpc.VALOR = h.FieldItem.Field.VALOR;

                Pessoa p = db.Pessoas.Find(item.IDPESSOA);
                hpc.PESSOA = p.NOME;
                hpc.TELEFONE = p.TELEFONE;


                listTotal.Add(hpc);
            }

            foreach (var item in hae)
            {
                HoraryComplete hpc = new HoraryComplete();

                hpc.ID = item.ID;
                hpc.DATA = item.DATA;

                if (item.STATUS == "A")
                {
                    hpc.STATUS = "Aprovado";
                }
                else if (item.STATUS == "C")
                {
                    hpc.STATUS = "Cancelado";
                }
                else if (item.STATUS == "P")
                {
                    hpc.STATUS = "Pendente";
                }

                HoraryExtra h = db.HoraryExtras.Include(b => b.FieldItem).Include(b => b.FieldItem.Field).Where(b => b.ID == item.IDHORARIO).FirstOrDefault();

              
                hpc.HORA = h.HORARIO;
                hpc.CAMPO = h.FieldItem.DESCRICAO;
                hpc.LOGO = h.FieldItem.Field.LOGO;
                hpc.VALOR = h.FieldItem.Field.VALOR;

                Pessoa p = db.Pessoas.Find(item.IDPESSOA);
                hpc.PESSOA = p.NOME;
                hpc.TELEFONE = p.TELEFONE;

                listTotal.Add(hpc);
            }

            return listTotal.OrderByDescending(p => p.DATA).ThenBy(p => p.HORA).ToList();
        }

        public IEnumerable<SchedulingAPI> GetHorary(int id, DateTime Data)
        {
            List<SchedulingAPI> list = new List<SchedulingAPI>();
            int diaSemana = (int)Data.DayOfWeek;

            foreach (Horary item in db.Horarys.Where(p => p.IDITEMCAMPO == id && p.STATUS == true && p.DIASEMANA == diaSemana))
            {
                Scheduling agendados = db.Schedulings.Where(p => p.DATA == Data && p.TIPOHORARIO == TipoHorario.Padrao && p.IDHORARIO == item.ID && p.STATUS != "C").FirstOrDefault();

                if (agendados == null)
                {
                    SchedulingAPI newItem = new SchedulingAPI { ID = item.ID, HORARIO = item.HORARIO.Trim(), TIPOHORARIO = TipoHorario.Padrao, AGENDADO = false };
                    list.Add(newItem);
                }
                else
                {
                    SchedulingAPI newItem = new SchedulingAPI { ID = item.ID, HORARIO = item.HORARIO.Trim(), TIPOHORARIO = TipoHorario.Padrao, AGENDADO = true };
                    list.Add(newItem);
                }
            }

            foreach (HoraryExtra item in db.HoraryExtras.Where(p => p.IDITEMCAMPO == id && p.DATA == Data))
            {
                Scheduling agendados = db.Schedulings.Where(p => p.DATA == Data && p.TIPOHORARIO == TipoHorario.Extra && p.IDHORARIO == item.ID && p.STATUS != "C").FirstOrDefault();

                if (agendados == null)
                {
                    SchedulingAPI newItem = new SchedulingAPI { ID = item.ID, HORARIO = item.HORARIO.Trim(), TIPOHORARIO = TipoHorario.Extra, AGENDADO = false };
                    list.Add(newItem);
                }
                else
                {
                    SchedulingAPI newItem = new SchedulingAPI { ID = item.ID, HORARIO = item.HORARIO.Trim(), TIPOHORARIO = TipoHorario.Extra, AGENDADO = true };
                    list.Add(newItem);
                }
            }

            return list;
        }

        public HoraryComplete GetTicket(int id)
        {
            Scheduling hap = db.Schedulings.Find(id);
            HoraryComplete hpc = new HoraryComplete();

            hpc.ID = hap.ID;
            hpc.DATA = hap.DATA;

            if (hap.STATUS == "A")
            {
                hpc.STATUS = "Aprovado";
            }
            else if (hap.STATUS == "C")
            {
                hpc.STATUS = "Cancelado";
            }
            else if (hap.STATUS == "P")
            {
                hpc.STATUS = "Pendente";
            }

            if (hap.TIPOHORARIO == TipoHorario.Padrao)
            {
                Horary hp = db.Horarys.Include(b => b.FieldItem).Include(b => b.FieldItem.Field).Where(b => b.ID == hap.IDHORARIO).FirstOrDefault();

                hpc.HORA = hp.HORARIO;
                hpc.CAMPO = hp.FieldItem.DESCRICAO;
                hpc.LOGO = hp.FieldItem.Field.LOGO;
                hpc.ENDERECO = hp.FieldItem.Field.ENDERECO;
                hpc.VALOR = hp.FieldItem.Field.VALOR;
                hpc.LOCAL = hp.FieldItem.Field.NOME;
                hpc.TELEFONE = hp.FieldItem.Field.TELEFONE;
            }
            else
            {
                HoraryExtra he = db.HoraryExtras.Include(b => b.FieldItem).Include(b => b.FieldItem.Field).Where(b => b.ID == hap.IDHORARIO).FirstOrDefault();

                hpc.HORA = he.HORARIO;
                hpc.CAMPO = he.FieldItem.DESCRICAO;
                hpc.LOGO = he.FieldItem.Field.LOGO;
                hpc.ENDERECO = he.FieldItem.Field.ENDERECO;
                hpc.VALOR = he.FieldItem.Field.VALOR;
                hpc.LOCAL = he.FieldItem.Field.NOME;
                hpc.TELEFONE = he.FieldItem.Field.TELEFONE;
            }

            Pessoa p = db.Pessoas.Find(hap.IDPESSOA);
            hpc.PESSOA = p.NOME;

            return hpc;
        }
    }
}
