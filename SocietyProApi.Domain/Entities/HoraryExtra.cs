using System;

namespace SocietyProApi.Domain.Entities
{
    public class HoraryExtra
    {
        public int ID { get; set; }
        public int IDITEMCAMPO { get; set; }
        public string HORARIO { get; set; }
        public DateTime DATA { get; set; }

        public virtual FieldItem FieldItem { get; set; }
    }
}
