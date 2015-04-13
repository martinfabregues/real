using Entidad;
using Entidad.Criteria;
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
    public partial class frmConsultaProveedor : Form
    {
        public frmConsultaProveedor()
        {
            InitializeComponent();
        }

        //LISTO 
        private void CargarGrilla()
        {
            List<Proveedor> list = Proveedores.GetTodos();
            if (list.Count > 0)
            {
                dgvProveedores.DataSource = Proveedores.GetTodos();
                dgvProveedores.CurrentRow.Selected = false;
            }
            else
            {
                dgvProveedores.DataSource = null;
            }
        }

        //LISTO
        private void PersonalizarGrilla()
        {
            dgvProveedores.Columns[0].Visible = false;
            dgvProveedores.Columns[1].HeaderText = "CÓDIGO";
            dgvProveedores.Columns[2].HeaderText = "R.SOCIAL";
            dgvProveedores.Columns[3].HeaderText = "NOMBRE";
            dgvProveedores.Columns[4].HeaderText = "DIRECCIÓN";
            dgvProveedores.Columns[5].HeaderText = "BARRIO";
            dgvProveedores.Columns[6].HeaderText = "COD.POSTAL";
            dgvProveedores.Columns[7].Visible = false;
            dgvProveedores.Columns[8].HeaderText = "TELÉFONO";
            dgvProveedores.Columns[9].Visible = false;
            dgvProveedores.Columns[10].HeaderText = "CUIT";
            dgvProveedores.Columns[11].HeaderText = "ING.BRUTOS";
            dgvProveedores.Columns[12].Visible = false;
            dgvProveedores.Columns[13].HeaderText = "EMAIL";
            dgvProveedores.Columns[14].Visible = false;

            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }


        private void frmConsultaProveedor_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CargarGrilla();
            PersonalizarGrilla();
        }

        private void frmConsultaProveedor_Resize(object sender, EventArgs e)
        {
            dgvProveedores.Width = this.Width - 40;
            dgvProveedores.Height = this.Height - 200;
            btnCerrar.Location = new Point(this.Width - 110, this.Height - 80);
        }

        //LISTO
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty)
            {
                BuscarPorCriterio();               
            }
        }

        //LISTO
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty)
            {
                BuscarPorCriterio();
            }
        }

        //LISTO
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //LISTO
        private void BuscarPorCriterio()
        {
            ProveedorCriteria filtro = new ProveedorCriteria()
            {
                pronombre = txtNombre.Text,                
            };

            try
            {
                List<Proveedor> list = Proveedores.GetFiltro(filtro);
                if (list.Count > 0)
                {
                    dgvProveedores.DataSource = list;
                    dgvProveedores.CurrentRow.Selected = false;
                    PersonalizarGrilla();
                }
                else
                {
                    dgvProveedores.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
