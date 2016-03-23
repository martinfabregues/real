using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class OrdenCompra
    {
        public int id { get; set; }
        public string numero { get; set; }
        public DateTime fecha { get; set; }
        public Proveedor proveedor { get; set; }
        public int proveedor_id { get; set; }
        public decimal importe { get; set; }
        public int estado_id { get; set; }
        public string observacion { get; set; }
        public int activo { get; set; }
        public IList<OrdenCompraDetalle> Detalle { get; set; }
    }

    public class OrdenCompraMap : EntityMap<OrdenCompra>
    {
        public OrdenCompraMap()
        {
            Map(x => x.id).ToColumn("odcid", caseSensitive: false);
            Map(x => x.numero).ToColumn("odcnumero", caseSensitive: false);
            Map(x => x.fecha).ToColumn("odcfecha", caseSensitive: false);
            Map(x => x.proveedor_id).ToColumn("proid", caseSensitive: false);
            Map(x => x.importe).ToColumn("odcimporte", caseSensitive: false);
            Map(x => x.estado_id).ToColumn("estid", caseSensitive: false);
            Map(x => x.activo).ToColumn("odcactivo", caseSensitive: false);
            Map(x => x.observacion).ToColumn("odcobservacion", caseSensitive: false);
        }
    }
}
