using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Real.UI.Depositos.Entidad
{
    public class IngresoDetalle
    {
        public int id { get; set; }
        public int ingreso_id { get; set; }
        public int producto_id { get; set; }
        public int cantidad { get; set; }
    }
}
