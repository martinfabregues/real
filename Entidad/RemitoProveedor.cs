using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class RemitoProveedor
    {
        public int id { get; set; }
        public DateTime fechaemision { get; set; }
        public DateTime fecharecepcion { get; set; }
        public int proveedor_id { get; set; }
        public string numero { get; set; }
        public int sucursal_id { get; set; }
        public int activo { get; set; }
        public string observaciones { get; set; }
        public virtual IList<RemitoProveedorDetalle> detalle { get; set; }
        public virtual Sucursal sucursal { get; set; }
        public virtual FacturaProveedor factura { get; set; }
        
    }

    public class RemitoProveedorMap : EntityMap<RemitoProveedor>
    {
        public RemitoProveedorMap()
        {
            Map(x => x.id).ToColumn("remitoproveedor_id", caseSensitive: false);
            Map(x => x.fechaemision).ToColumn("remitoproveedor_fecha", caseSensitive: false);
            Map(x => x.fecharecepcion).ToColumn("remitoproveedor_fecharecepcion", caseSensitive: false);
            Map(x => x.proveedor_id).ToColumn("proid", caseSensitive: false);
            Map(x => x.numero).ToColumn("remitoproveedor_numero", caseSensitive: false);
            Map(x => x.sucursal_id).ToColumn("sucid", caseSensitive: false);
            Map(x => x.activo).ToColumn("estid", caseSensitive: false);
            Map(x => x.observaciones).ToColumn("observaciones", caseSensitive: false);
        }
    }
}
