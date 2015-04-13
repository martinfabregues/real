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
    public partial class dlgBonificaciones : Form
    {
        public int bonid { get; set; }
        public dlgBonificaciones()
        {
            InitializeComponent();
        }

        //LISTO
        private void IniciarControles()
        {
            txtNombre.Enabled = false;
            cmbProveedor.Enabled = false;
            txtNombre.Focus();
        }

        //LISTO
        private void dlgBonificaciones_Load(object sender, EventArgs e)
        {
            IniciarControles();
            CargarComboBoxProveedor();
            CargarGrilla();
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
            dgvBonificacion.Columns[3].HeaderText = "Inicio";
            dgvBonificacion.Columns[4].HeaderText = "Finaliza";
            dgvBonificacion.Columns[5].HeaderText = "Descuento";
            dgvBonificacion.Columns[6].HeaderText = "Estado";

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvBonificacion.SelectedRows.Count > 0)
            {
                if (dgvBonificacion.CurrentRow.Index > -1)
                {
                    bonid = Convert.ToInt32(dgvBonificacion.CurrentRow.Cells[0].Value);
                }
            }
        }

        //LISTO
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //
            // Si el control DataGridView no tiene el foco, 
            // se abandonamos el procedimiento, llamando al metodo base
            //
            if ((!dgvBonificacion.Focused))
                return base.ProcessCmdKey(ref msg, keyData);

            //
            // Si la tecla presionada es distinta al ENTER, 
            // se abandonamos el procedimiento, llamando al metodo base
            //
            if (keyData != Keys.Enter)
                return base.ProcessCmdKey(ref msg, keyData);
            //
            // Obtenemos la fila actual 
            //

            if (dgvBonificacion.SelectedRows.Count > 0)
            {
                if (dgvBonificacion.CurrentRow.Index > -1)
                {
                    DataGridViewRow row = dgvBonificacion.CurrentRow;
                    bonid = Convert.ToInt32(dgvBonificacion.CurrentRow.Cells[0].Value);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    //frmSeleccion frm = new frmSeleccion(cuenta, desc);
                    //frm.ShowDialog();
                }
            }

            return true;
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
            else
            {
                dgvBonificacion.DataSource = null;
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

  


    }
}
