using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class CobroRemitoCredito : CobroRemito
    {
        public CobroRemito cobroremito { get; set; }
        public Plan plan { get; set; }
        public double cobroremitocredito_costoplan { get; set; }
    }
}
