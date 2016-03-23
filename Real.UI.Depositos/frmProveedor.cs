using Real.UI.Depositos.Entidad;
using Real.UI.Depositos.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real.UI.Depositos
{
    public partial class frmProveedor : Form
    {
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtRazonSocial.Text = string.Empty;
            ckbActivo.CheckState = CheckState.Checked;

            this.ActiveControl = txtRazonSocial;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarProveedor();
        }

        private void RegistrarProveedor()
        {
            Proveedor proveedor = new Proveedor();
            proveedor.razon_social = txtRazonSocial.Text;
            proveedor.activo = Convert.ToInt32(ckbActivo.Checked);

            int resultado = Proveedores.Add(proveedor);
            if(resultado > 0)
            {
                MessageBox.Show("OK");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            IniciarControles();
        }
    }
}
