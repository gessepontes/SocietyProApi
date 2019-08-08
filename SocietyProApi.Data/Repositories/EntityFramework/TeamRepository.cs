using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocietyProApi.Data.Repository.EntityFramework.Common;
using SocietyProApi.Domain.Diversos;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;

namespace SocietyProApi.Data.Repository.EntityFramework
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public IEnumerable<Team> GetTeamPerson(int id)
        {
            return db.Teams.Where(p => p.IDPESSOA == id && p.STATUS == true).OrderBy(p => p.NOME).ToList();
        }

        public override void Update(Team obj)
        {

            if (obj.ATIVO) {
                foreach (var item in db.Teams.Where(p => p.IDPESSOA == obj.IDPESSOA && p.STATUS == true && p.ATIVO == true).ToList())
                {
                    db.Entry(item).State = EntityState.Modified;
                    item.ATIVO = false;
                    db.SaveChanges();
                }  
            }

            db.Entry(obj).State = EntityState.Modified;           

            if (obj.SIMBOLO == null)
            {
                db.Entry(obj).Property("SIMBOLO").IsModified = false;
            }
            else
            {
                string sFoto = obj.ID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                Diverso.SaveCoverPicture(obj.FOTO, "Simbolo", sFoto);
                obj.SIMBOLO = sFoto;
            }

            db.Entry(obj).Property("DATACADASTRO").IsModified = false;
            db.Entry(obj).Property("STATUS").IsModified = false;

            obj.FOTO = "semimagem.png";

            db.SaveChanges();
        }

        public override void Add(Team obj)
        {
            if (obj.ATIVO)
            {
                foreach (var item in db.Teams.Where(p => p.IDPESSOA == obj.IDPESSOA && p.STATUS == true && p.ATIVO == true).ToList())
                {
                    db.Entry(item).State = EntityState.Modified;
                    item.ATIVO = false;
                    db.SaveChanges();
                }
            }

            if (obj.SIMBOLO == null)
            {
                obj.SIMBOLO = "semimagem.png";
            }
            else
            {
                string sFoto = obj.ID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                Diverso.SaveCoverPicture(obj.FOTO, "FotoJogador", sFoto);

                obj.SIMBOLO = sFoto;
            }

            obj.FOTO = "semimagem.png";

            db.Add(obj);
            db.SaveChanges();
        }

        public override void Remove(Team obj)
        {
            obj.STATUS = false;
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
