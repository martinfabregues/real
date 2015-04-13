using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ServiceAutorizacion
    {
        public int seaid { get; set; }
        public int serid { get; set; }
        public DateTime seafecha { get; set; }
        public int seacobertura { get; set; }
        public Decimal seaimporte { get; set; }
    }
}
