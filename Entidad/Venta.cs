using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class Venta
    {
        public string sucnombre { get; set; }
        public int remito_id { get; set; }
        public DateTime remito_fecha { get; set; }
        public string remito_numero { get; set; }
        public string vendedor_nombre { get; set; }
        public double remito_importe { get; set; }
        public double totalventa { get; set; }
        public double totalcostosiniva { get; set; }
        public double totalprecioventateorico { get; set; }
        public double totalgastofinanciacion { get; set; }
        public double ganancia { get; set; }
        public double margenganancia { get; set; }

    }
}
