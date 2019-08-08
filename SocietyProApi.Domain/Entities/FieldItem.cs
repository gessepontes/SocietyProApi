using SocietyProApi.Domain.Diversos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyProApi.Domain.Entities
{
    public class FieldItem
    {
        public FieldItem()
        {
            ATIVO = true;
        }

        public int ID { get; set; }

        string sDescricao;
        public string DESCRICAO
        {
            get
            {
                if (string.IsNullOrEmpty(sDescricao))
                {
                    return sDescricao;
                }
                return Diverso.FirstCharToUpper(sDescricao);
            }
            set
            {
                sDescricao = value;
            }

        }

        public int IDCAMPO { get; set; }

        public bool ATIVO { get; set; }
        public virtual Field Field { get; set; }
        public virtual ICollection<Horary> Horarys { get; set; }
        public virtual ICollection<HoraryExtra> HoraryExtras { get; set; }
    }
}
