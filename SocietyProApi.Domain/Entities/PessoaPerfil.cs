using System.ComponentModel.DataAnnotations.Schema;
using static SocietyProApi.Domain.Diversos.Enum;

namespace SocietyProApi.Domain.Entities
{
    public class PessoaPerfil
    {
        public int ID { get; set; }
        public TipoPerfil TipoPerfil { get; set; }

        public int IDPESSOA { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
