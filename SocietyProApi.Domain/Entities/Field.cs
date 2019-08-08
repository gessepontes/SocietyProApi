using SocietyProApi.Domain.Diversos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyProApi.Domain.Entities
{
    public class Field
    {
        public Field()
        {
            DATACADASTRO = DateTime.Now;
            STATUS = true;
        }

        public int ID { get; set; }

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

        public string ENDERECO { get; set; }
        public string TELEFONE { get; set; }

        [Column(TypeName = "money")]
        public decimal VALOR { get; set; }

        [Column(TypeName = "money")]
        public decimal VALORMENSAL { get; set; }

        public bool STATUS { get; set; }
        public bool AGENDAMENTO { get; set; }
        public string LOGO { get; set; }
        public DateTime DATACADASTRO { get; set; }
        public int IDPESSOA { get; set; }
        public int IDCIDADE { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<FieldItem> FieldItens { get; set; }
        public virtual ICollection<Championship> Championship { get; set; }

    }
}
