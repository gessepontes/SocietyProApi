using static SocietyProApi.Domain.Diversos.Diverso;

namespace SocietyProApi.Domain.Entities
{
    public class Horary
    {
        public int ID { get; set; }

        public int IDITEMCAMPO { get; set; }
        public string HORARIO { get; set; }
        public int DIASEMANA { get; set; }
        public bool STATUS { get; set; }

        public virtual FieldItem FieldItem { get; set; }
    }
}
