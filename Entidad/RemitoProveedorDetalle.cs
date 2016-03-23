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

        public int ordendetalle_id { get; set; }

        public virtual RemitoProveedor remitoproveedor { get; set; }
        public virtual Producto producto { get; set; }
        public virtual OrdenCompra ordencompra { get; set; }
    }
}
