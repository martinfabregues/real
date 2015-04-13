using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class CobroRemito
    {
        public int cobroremito_id { get; set; }
        public Remito remito { get; set; }
        public double cobroremito_importe { get; set; }
    }
}
