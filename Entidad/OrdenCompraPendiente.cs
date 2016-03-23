using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class OrdenCompraPendiente
    {
        public int id { get; set; }
        public int orden_id { get; set; }
        public int producto_id { get; set; }
        public int cantidad {get;set;}
        public decimal importe_unitario { get; set; }
        public int sucursal_id { get; set; }
        public int proveedor_id { get; set; }
        public int estado_id { get; set; }
        public int ingreso { get; set; }
        public int ordendetalle_id { get; set; }


        public virtual OrdenCompra ordencompra { get; set; }
        public virtual Producto producto { get; set; }
        public virtual Sucursal sucursal { get; set; }
        public virtual Proveedor proveedor { get; set; }

    }

    public class OrdenCompraPendienteMap : EntityMap<OrdenCompraPendiente>
    {
        public OrdenCompraPendienteMap()
        {
            Map(x => x.id).ToColumn("ocpid", caseSensitive: false);
            Map(x => x.orden_id).ToColumn("odcid", caseSensitive: false);
            Map(x => x.producto_id).ToColumn("prdid", caseSensitive: false);
            Map(x => x.cantidad).ToColumn("ocdcantidad", caseSensitive: false);
            Map(x => x.importe_unitario).ToColumn("ocdimporte", caseSensitive: false);
            Map(x => x.sucursal_id).ToColumn("sucid", caseSensitive: false);
            Map(x => x.proveedor_id).ToColumn("proid", caseSensitive: false);
            Map(x => x.estado_id).ToColumn("espid", caseSensitive: false);
            Map(x => x.ingreso).ToColumn("ingreso", caseSensitive: false);
            Map(x => x.ordendetalle_id).ToColumn("ordendetalle_id", caseSensitive: false);
        }
    }

}
