using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class RemitoProveedorDetalle
    {
        public int id { get; set; }
        public int remitoproveedor_id { get; set; }
        public int producto_id { get; set; }
        public int cantidad { get; set; }
        public int orden_id { get; set; }
    }
}
