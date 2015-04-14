using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class FacturaProveedorRemitoProveedor
    {
        public int id { get; set; }
        public int facturaproveedor_id { get; set; }
        public int remitoproveedor_id { get; set; }
    }
}
