using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Real.UI.Depositos.Entidad
{
    public class Salida
    {
        public int id { get; set; }
        public DateTime fecha_salida { get; set; }
        public int deposito_salida_id { get; set; }
        public int deposito_destino_id { get; set; }
    }
}
