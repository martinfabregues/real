using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmOrdenCompraGenerar : Form
    {
        public frmOrdenCompraGenerar()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            _grid.RowCount = 1;
        }

        private void frmOrdenCompraGenerar_Load(object sender, EventArgs e)
        {
            IniciarControles();
        }

        private void ObtenerProveedor(int proid)
        {
            //Proveedor proveedor = Proveedores.
        }
    }
}
