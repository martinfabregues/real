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
            dgvProveedores.Columns[1].HeaderText = "Código";
            dgvProveedores.Columns[2].HeaderText = "R.Social";
            dgvProveedores.Columns[3].HeaderText = "Nombre";
            dgvProveedores.Columns[4].HeaderText = "Dirección";
            dgvProveedores.Columns[5].HeaderText = "Barrio";
            dgvProveedores.Columns[6].HeaderText = "Cod.Postal";
            dgvProveedores.Columns[7].Visible = false;
            dgvProveedores.Columns[8].HeaderText = "Teléfono";
            dgvProveedores.Columns[9].Visible = false;
            dgvProveedores.Columns[10].HeaderText = "Cuit";
            dgvProveedores.Columns[11].HeaderText = "Ing.Brutos";
            dgvProveedores.Columns[12].Visible = false;
            dgvProveedores.Columns[13].HeaderText = "Email";
            dgvProveedores.Columns[14].Visible = false;

            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }


        private void frmConsultaProveedor_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
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
