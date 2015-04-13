using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class RemitoDetalle
    {
        public int remitodetalle_id { get; set; }
        public Remito remito { get; set; }
        public Producto producto { get; set; }
        public int remitodetalle_cantidad { get; set; }
        public double remitodetalle_importeunitario { get; set; }
        public string remitodetalle_numeroreserva { get; set;}
        public int sucid { get; set; }

    }
}
