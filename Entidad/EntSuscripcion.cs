using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntSuscripcion
    {
        public long Idasociacion { get; set; }
        public long Idsuscriptor { get; set; }
        public DateTime Fechaalta { get; set; }
        public DateTime Fechafin { get; set; }
        public string Motivofin { get; set; }

    }
}
