using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class FacturaProveedor
    {
        public int id { get; set; }
        public string numero { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fecharecepcion { get; set; }
        public int sucursal_id { get; set; }
        public int proveedor_id { get; set; }
        public string numeroremito { get; set; }
        public int activo { get; set; }
        public decimal importe { get; set; }
        public string observaciones { get; set; }
        public double subtotal { get; set; }
        public double iva { get; set; }
        public double ingbrutos { get; set; }
        public double resolucion_2408 { get; set; }
        public virtual IList<FacturaProveedorDetalle> detalle { get; set; }
        public virtual IList<RemitoProveedor> remitos { get; set; }
        public virtual Proveedor proveedor { get; set; }

    }

    public class FacturaProveedorMap : EntityMap<FacturaProveedor>
    {
        public FacturaProveedorMap()
        {
            Map(x => x.id).ToColumn("fapid", caseSensitive: false);
            Map(x => x.numero).ToColumn("fapnumero", caseSensitive: false);
            Map(x => x.fecha).ToColumn("fapfecha", caseSensitive: false);
            Map(x => x.fecharecepcion).ToColumn("fapfecharecepcion", caseSensitive: false);
            Map(x => x.sucursal_id).ToColumn("sucid", caseSensitive: false);
            Map(x => x.proveedor_id).ToColumn("proid", caseSensitive: false);
            Map(x => x.numeroremito).ToColumn("fapremito", caseSensitive: false);
            Map(x => x.activo).ToColumn("estid", caseSensitive: false);
            Map(x => x.importe).ToColumn("fapimporte", caseSensitive: false);
            Map(x => x.subtotal).ToColumn("subtotal", caseSensitive: false);
            Map(x => x.iva).ToColumn("iva", caseSensitive: false);
            Map(x => x.ingbrutos).ToColumn("ingbrutos", caseSensitive: false);
            Map(x => x.observaciones).ToColumn("observaciones", caseSensitive: false);
        }
    }
}
