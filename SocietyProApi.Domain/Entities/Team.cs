using SocietyProApi.Domain.Diversos;
using System;
using System.Collections.Generic;

namespace SocietyProApi.Domain.Entities
{
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
            DATACADASTRO = DateTime.Now.Date;
            OBSERVACAO = "";
            STATUS = true;
        }

        public int ID { get; set; }
        public int IDPESSOA { get; set; }

        string sNome;
        public string NOME
        {
            get
            {
                if (string.IsNullOrEmpty(sNome))
                {
                    return sNome;
                }
                return Diverso.FirstCharToUpper(sNome);
            }
            set
            {
                sNome = value;
            }
        }

        public string SIMBOLO { get; set; }
        public string FOTO { get; set; }
        public int TIPO { get; set; }
        public string OBSERVACAO { get; set; }
        public DateTime DATAFUNDACAO { get; set; }
        public bool ATIVO { get; set; }
        public bool STATUS { get; set; }
        public DateTime DATACADASTRO { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; set; }
        public Pessoa Pessoa { get; set; }

    }
}