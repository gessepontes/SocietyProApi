
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
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public IEnumerable<Player> GetPlayerTeam(int id)
        {
            return db.Players.Where(p => p.Team.IDPESSOA == id && p.Team.ATIVO == true && p.STATUS == true).OrderBy(p=>p.NOME).ToList();
        }

        public override void Update(Player obj)
        {
            db.Entry(obj).State = EntityState.Modified;

            if (obj.FOTO == null)
            {
                db.Entry(obj).Property("FOTO").IsModified = false;
            }
            else
            {
                string sFoto = obj.ID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                Diverso.SaveCoverPicture(obj.FOTO, "FotoJogador", sFoto);
                obj.FOTO = sFoto;
            }

            db.Entry(obj).Property("DATACADASTRO").IsModified = false;
            db.Entry(obj).Property("DATADISPENSA").IsModified = false;
            db.Entry(obj).Property("STATUS").IsModified = false;

            

            db.SaveChanges();
        }

        public override void Add(Player obj)
        {
            if (obj.FOTO == null)
            {
                obj.FOTO = "semimagem.png";
            }
            else
            {
                string sFoto = obj.ID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                Diverso.SaveCoverPicture(obj.FOTO, "FotoJogador", sFoto);

                obj.FOTO = sFoto;
            }


            db.Add(obj);
            db.SaveChanges();
        }

        public override void Remove(Player obj)
        {
            obj.STATUS = false;
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}