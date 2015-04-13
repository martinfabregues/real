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
    public partial class frmConsultaBonificacionesRegistradas : Form
    {
        public frmConsultaBonificacionesRegistradas()
        {
            InitializeComponent();
        }

        //LISTO
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //LISTO
        private void IniciarControles()
        {
            txtNombre.Enabled = false;
            cmbProveedor.Enabled = false;
            txtNombre.Focus();
        }

        //LISTO
        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetTodos();
        }

        //LISTO
        private void PersonalidarDataGrid()
        {
            dgvBonificacion.Columns[0].Visible = false;

            dgvBonificacion.Columns[0].HeaderText = "Id";
            dgvBonificacion.Columns[1].HeaderText = "Proveedor";
            dgvBonificacion.Columns[2].HeaderText = "Nombre";
            dgvBonificacion.Columns[3].HeaderText = "Creación";
            dgvBonificacion.Columns[4].HeaderText = "Inicio";
            dgvBonificacion.Columns[5].HeaderText = "Finaliza";
            dgvBonificacion.Columns[6].HeaderText = "Descuento";
            dgvBonificacion.Columns[7].HeaderText = "Estado";

            dgvBonificacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBonificacion.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvBonificacion.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }


        //LISTO
        private void CargarGrilla()
        {
            List<Bonificacion> list = Bonificaciones.GetTodoConsulta();

            var result = (from fila in list
                          select new
                          {
                              fila.bonid,
                              fila.proveedor.pronombre,
                              fila.bonnombre,
                              fila.bonfechacreacion,
                              fila.bonfechainicio,
                              fila.bonfechafin,
                              fila.bondescuento,
                              fila.estado.estestado,
                          }).ToList();

            if (result.Count > 0)
            {
                dgvBonificacion.DataSource = result;
                dgvBonificacion.CurrentRow.Selected = false;

                PersonalidarDataGrid();
            }
            else
            {
                dgvBonificacion.DataSource = null;
            }
        }


        private void frmConsultaBonificacionesRegistradas_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            IniciarControles();
            CargarComboBoxProveedor();
            CargarGrilla();

        }

        //LISTO
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //LISTO
        private void BuscarPorCriterio()
        {
            BonificacionCriteria filtro = new BonificacionCriteria()
            {
                bonnombre = txtNombre.Text,
                proveedor = Convert.ToInt32(cmbProveedor.SelectedValue) == -1 ? null : new Proveedor() { proid = Convert.ToInt32(cmbProveedor.SelectedValue) }
            };

            try
            {
                List<Bonificacion> list = Bonificaciones.GetFiltro(filtro);

                var result = (from fila in list
                              select new
                              {
                                  fila.bonid,
                                  fila.proveedor.pronombre,
                                  fila.bonnombre,
                                  fila.bonfechacreacion,
                                  fila.bonfechainicio,
                                  fila.bonfechafin,
                                  fila.bondescuento,
                                  fila.estado.estestado,
                              }).ToList();
                if (result.Count > 0)
                {
                    dgvBonificacion.DataSource = result;
                    dgvBonificacion.CurrentRow.Selected = false;
                    PersonalidarDataGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //LISTO
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                BuscarPorCriterio();
            }
        }

        //LISTO
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPorCriterio();
        }

        //LISTO
        private void ckbNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNombre.Checked == true)
            {
                txtNombre.Enabled = true;
            }
            else
            {
                txtNombre.Enabled = false;
            }
        }

        //LISTO
        private void ckbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbProveedor.Checked == true)
            {
                cmbProveedor.Enabled = true;
            }
            else
            {
                cmbProveedor.Enabled = false;
            }
        }

        //LISTO
        private void frmConsultaBonificacionesRegistradas_Resize(object sender, EventArgs e)
        {
            dgvBonificacion.Width = this.Width - 40;
            dgvBonificacion.Height = this.Height - 250;
            btnAceptar.Location = new Point(this.Width - 200, this.Height - 70);
            btnCancelar.Location = new Point(this.Width - 100, this.Height - 70); 
        }

    }
}
