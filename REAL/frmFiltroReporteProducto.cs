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
    public partial class frmFiltroReporteProducto : Form
    {
        public frmFiltroReporteProducto()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            cmbProveedor.Enabled = false;
            CargarComboBoxProveedor();

        }

        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetProveedoresDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbCompleto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCompleto.Checked == true)
            {
                ckbProveedor.CheckState = CheckState.Unchecked;
                cmbProveedor.Enabled = false;
            }
        }

        private void ckbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbProveedor.Checked == true)
            {
                cmbProveedor.Enabled = true;
                ckbCompleto.CheckState = CheckState.Unchecked;
            }
            else
            {
                cmbProveedor.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ckbCompleto.Checked == true)
            {
                frmReporteProductos frm = new frmReporteProductos("COMPLETO", Convert.ToInt32(cmbProveedor.SelectedValue));
                frm.MdiParent = this.MdiParent;
                frm.Text = "PRODUCTOS - Reporte de Productos Completo";
                this.Hide();
                frm.Show();
            }
            else
            {
                if (ckbProveedor.Checked == true)
                {
                    frmReporteProductos frm = new frmReporteProductos("PROVEEDOR", Convert.ToInt32(cmbProveedor.SelectedValue));
                    frm.MdiParent = this.MdiParent;
                    frm.Text = "PRODUCTOS - Reporte de Productos por Proveedor";
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("DEBE SELECCIONAR UN TIPO DE REPORTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmFiltroReporteProducto_Load(object sender, EventArgs e)
        {
            IniciarControles();
        }
    }
}
