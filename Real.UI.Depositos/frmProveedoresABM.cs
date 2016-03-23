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
    public partial class frmProveedoresABM : Form
    {
        public frmProveedoresABM()
        {
            InitializeComponent();
        }

        private void frmProveedoresABM_Load(object sender, EventArgs e)
        {
            dgvProveedores.DataSource = Proveedores.FindAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
