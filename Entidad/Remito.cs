using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class Remito
    {
        public int remito_id { get; set; }
        public string remito_numero { get; set; }
        public string remito_numerofactura { get; set; }
        public DateTime remito_fecha { get; set; }
        public double remito_importe { get; set; }
        public EstadoComprobante estadocomprobante { get; set; }
        public Sucursal sucursal { get; set; }
        public Cliente cliente { get; set; }      
        public Movimiento movimiento { get; set; }
        public TipoMovimiento tipomovimiento { get; set; }
        public TipoComprobante tipocomprobante { get; set; }
        public Vendedor vendedor { get; set; }

        public List<RemitoDetalle> detalle { get; set; }

        public List<CobroRemito> cobros { get; set; }
        public List<CobroRemitoContado> cobrocontado { get; set; }
        public List<CobroRemitoCredito> cobrocredito { get; set; }

    }
}
