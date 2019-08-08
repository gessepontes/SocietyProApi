using SocietyProApi.Domain.Diversos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocietyProApi.Domain.Entities
{
    public class Championship
    {
        public Championship()
        {
            dDataCadastro = DateTime.Now;
            bDisponivelInscricao = true;
        }

        public int ID { get; set; }

        string sNomeCampeonato;
        public string sNome
        {
            get
            {
                if (string.IsNullOrEmpty(sNomeCampeonato))
                {
                    return sNomeCampeonato;
                }
                return Diverso.FirstCharToUpper(sNomeCampeonato);
            }
            set
            {
                sNomeCampeonato = value;
            }

        }


        public DateTime? dDataInicio { get; set; }
        public DateTime? dDataFim { get; set; }
        public TipoCampeonato iTipoCampeonato { get; set; }
        public TipoArbitragem iTipoArbitragem { get; set; }
        public int TIPO { get; set; }
        public int iCodCampo { get; set; }
        public int iQuantidadeTimes { get; set; }
        public bool bPreInscricao { get; set; }
        public bool bIdaVolta { get; set; }
        public bool bDisponivelTransmissao { get; set; }
        public bool bDisponivelInscricao { get; set; }

        public string LOGO { get; set; }

        public int IDPESSOA { get; set; }

        public DateTime? dDataCadastro { get; set; }

        public virtual Field Field { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; set; }

    }

    public enum TipoCampeonato : int
    {
        Grupos = 1,
        [Display(Name = "Mata-Mata")]
        MataMata = 2,
        [Display(Name = "Pontos Corridos")]
        PontosCorridos = 3
    }


    public enum TipoArbitragem : int
    {
        [Display(Name = "Society")]
        Society = 1,
        [Display(Name = "Campo de 11")]
        Campo = 2
    }
}
