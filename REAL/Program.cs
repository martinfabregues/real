using Dapper.FluentMap;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REAL
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            FluentMapper.Intialize(config =>
            {
                config.AddMap(new RemitoProveedorMap());
                config.AddMap(new FacturaProveedorMap());
                config.AddMap(new OrdenCompraMap());
                config.AddMap(new OrdenCompraDetalleMap());
                config.AddMap(new OrdenCompraPendienteMap());
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
