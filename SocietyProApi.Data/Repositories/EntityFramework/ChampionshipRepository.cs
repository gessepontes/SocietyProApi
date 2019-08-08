using Microsoft.EntityFrameworkCore;
using SocietyProApi.Data.Repository.EntityFramework.Common;
using SocietyProApi.Domain.Entities;
using SocietyProApi.Domain.Interfaces.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace SocietyProApi.Data.Repository.EntityFramework
{
    public class ChampionshipRepository : RepositoryBase<Championship>, IChampionshipRepository
    {
        public IEnumerable<Championship> GetChampionshipInscription(int id)
        {
            ICollection<int> listaInscricao = db.Inscriptions.Where(p => p.IDTime == id).Select(s => s.ID).ToList();

            return db.Championships.Include(p => p.Inscriptions).Where(p => listaInscricao.Contains(p.ID));
        }

        public IEnumerable<Championship> GetPreInscription() => db.Championships.Where(p => p.bDisponivelInscricao == true).ToList();

    }
}
