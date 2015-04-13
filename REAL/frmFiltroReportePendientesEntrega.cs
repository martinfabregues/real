using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmFiltroReportePendientesEntrega : Form
    {
        public frmFiltroReportePendientesEntrega()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            cmbProveedor.Enabled = false;
            
        }

        private void frmFiltroReportePendientesEntrega_Load(object sender, EventArgs e)
        {
            IniciarControles();
            CargarComboBoxProveedor();
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

        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetProveedoresDatos();
        }

        private void ckbCompleto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCompleto.Checked == true)
            {
                cmbProveedor.Enabled = false;
                ckbProveedor.CheckState = CheckState.Unchecked;
            }
            else
            {

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ckbProveedor.Checked == true)
            {

                frmReportePendientesEntrega frm = new frmReportePendientesEntrega("PROVEEDOR", Convert.ToInt32(cmbProveedor.SelectedValue));
                frm.MdiParent = this.MdiParent;
                frm.Text = "REPORTE PENDIENTES DE ENTREGA - FILTRO POR PROVEEDOR";
                this.Hide();
                frm.Show();
            }
            else
            {
                if (ckbCompleto.Checked == true)
                {
                    frmReportePendientesEntrega frm = new frmReportePendientesEntrega("COMPLETO", Convert.ToInt32(cmbProveedor.SelectedValue));
                    frm.MdiParent = this.MdiParent;
                    frm.Text = "REPORTE PENDIENTES DE ENTREGA - COMPLETO";
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("DEBE SELECCIONAR AL MENOS UN TIPO DE REPORTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
