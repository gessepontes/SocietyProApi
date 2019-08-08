using System;
using System.ComponentModel.DataAnnotations;

namespace SocietyProApi.Domain.Entities
{
    public class Inscription
    {
        [Key]
        public int ID { get; set; }
        public int IDTime { get; set; }

        public int IDCampeonato { get; set; }

        public bool bAtivo { get; set; }
        public DateTime dDataCadastro { get; set; }

        public virtual Championship Championship { get; set; }
        public virtual Team Team { get; set; }
    }
}
