using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class OrdenCompraDetalle
    {
        public int id { get; set; }
        public int orden_id { get; set; }
        public int producto_id { get; set; }
        public int cantidad { get; set; }
        public int sucursal_id { get; set; }
        public decimal importe_unitario { get; set; }
        public int estado_id { get; set; }
        public string observacion { get; set; }

        public Producto producto { get; set; }
        public Sucursal sucursal { get; set; }
        public virtual OrdenCompra orden { get; set; }
    }

    public class OrdenCompraDetalleMap : EntityMap<OrdenCompraDetalle>
    {
        public OrdenCompraDetalleMap()
        {
            Map(x => x.id).ToColumn("ocdid", caseSensitive: false);
            Map(x => x.orden_id).ToColumn("odcid", caseSensitive: false);
            Map(x => x.producto_id).ToColumn("prdid", caseSensitive: false);
            Map(x => x.cantidad).ToColumn("ocdcantidad", caseSensitive: false);
            Map(x => x.importe_unitario).ToColumn("ocdimporteunit", caseSensitive: false);
            Map(x => x.sucursal_id).ToColumn("sucid", caseSensitive: false);
            Map(x => x.estado_id).ToColumn("ecdid", caseSensitive: false);
            Map(x => x.observacion).ToColumn("ocdobservacion", caseSensitive: false);
        }
    }

}
