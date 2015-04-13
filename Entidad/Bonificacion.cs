using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class Bonificacion
    {
        public int bonid { get; set; }
        public int proid { get; set; }
        public string bonnombre { get; set; }
        public DateTime bonfechacreacion { get; set; }
        public DateTime bonfechainicio { get; set; }
        public DateTime bonfechafin { get; set; }
        public Decimal bondescuento { get; set; }
        public int estid { get; set; }
        public Proveedor proveedor { get; set; }
        public Estado estado { get; set; }

    }
}
