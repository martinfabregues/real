using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class Plan
    {
        public int plan_id { get; set; }
        public string plan_denominacion { get; set; }
        public TarjetaCredito tarjetacredito { get; set; }
        public double plan_comision { get; set; }
        public double plan_costofinanciero { get; set; }
        public double plan_costoinflacionario { get; set; }
        public double plan_margenfinanciero { get; set; }
    }
}
