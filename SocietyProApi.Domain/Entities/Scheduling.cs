using System;
using static SocietyProApi.Domain.Diversos.Diverso;

namespace SocietyProApi.Domain.Entities
{
    public class Scheduling
    {
        public Scheduling()
        {
            DATACADASTRO = DateTime.Now;
            MARCADOAPP = true;
            STATUS = "A";
            TIPO = TipoAgendamento.Avulso;
        }

        public int ID { get; set; }
        public DateTime DATA { get; set; }
        public int IDHORARIO { get; set; }
        public TipoAgendamento TIPO { get; set; }
        public TipoHorario TIPOHORARIO { get; set; }
        public string STATUS { get; set; }
        public int? IDPESSOA { get; set; }
        public string CLIENTENAOCADASTRADO { get; set; }
        public string TELEFONE { get; set; }

        public DateTime DATACADASTRO { get; set; }
        public DateTime? DATACANCELAMENTO { get; set; }
        public int? IDPESSOACANCELAMENTO { get; set; }
        public bool MARCADOAPP { get; set; }
    }

    public class SchedulingAPI
    {
        public int ID { get; set; }
        public string HORARIO { get; set; }
        public int IDCAMPO { get; set; }
        public int IDITEMCAMPO { get; set; }
        public bool AGENDADO { get; set; }
        public TipoHorario TIPOHORARIO { get; set; }
    }

    public class HoraryComplete
    {
        public int ID { get; set; }
        public string CAMPO { get; set; }
        public string LOGO { get; set; }
        public string LOCAL { get; set; }
        public string ENDERECO { get; set; }
        public int IDCAMPO { get; set; }
        public DateTime DATA { get; set; }
        public string HORA { get; set; }
        public string STATUS { get; set; }
        public string PESSOA { get; set; }
        public string TELEFONE { get; set; }
        public decimal VALOR { get; set; }


    }

}
