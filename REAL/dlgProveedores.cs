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
    public partial class dlgProveedores : Form
    {
        public int proid { get; set; }
        public dlgProveedores()
        {
          
            InitializeComponent();
        }

        //LISTO
        private void CargarGrilla()
        {
            List<Proveedor> list = Proveedores.GetTodos();
            var result = (from fila in list
                          select new
                          {
                              fila.proid,
                              fila.procodigo,
                              fila.prorazonsocial,
                              fila.prodireccion,
                              fila.probarrio,
                          }).ToList();
            if (result.Count > 0)
            {
                dgvProveedor.DataSource = result;
                dgvProveedor.CurrentRow.Selected = false;
                PersonalizarGrilla();
            }

        }

        //LISTO
        private void PersonalizarGrilla()
        {
            dgvProveedor.Columns[0].Visible = false;
            dgvProveedor.Columns[1].HeaderText = "CÓDIGO";
            dgvProveedor.Columns[2].HeaderText = "RAZÓN SOC.";
            dgvProveedor.Columns[3].HeaderText = "DIRECCIÓN";
            dgvProveedor.Columns[4].HeaderText = "BARRIO";          

            dgvProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedor.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        //LISTO
        private void dlgProveedores_Load(object sender, EventArgs e)
        {
            CargarGrilla();      
        }

        //LISTO
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.SelectedRows.Count > 0)
            {
                if (dgvProveedor.CurrentRow.Index > -1)
                {
                    proid = Convert.ToInt32(dgvProveedor.CurrentRow.Cells["proid"].Value);

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
            if ((!dgvProveedor.Focused))
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

            if (dgvProveedor.SelectedRows.Count > 0)
            {
                if (dgvProveedor.CurrentRow.Index > -1)
                {
                    DataGridViewRow row = dgvProveedor.CurrentRow;
                    proid = Convert.ToInt32(dgvProveedor.CurrentRow.Cells[0].Value);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    //frmSeleccion frm = new frmSeleccion(cuenta, desc);
                    //frm.ShowDialog();
                }
            }

            return true;
        }

        //LISTO
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                dgvProveedor.DataSource = null;
                errorProvider1.SetError(btnBuscar, "Debe completar el campo nombre.");
                txtNombre.Focus();

            }
            else
            {
                BuscarLikeNombre(txtNombre.Text);
                PersonalizarGrilla();
            }
        }

        //LISTO
        private void BuscarLikeNombre(string pronombre)
        {
            List<Proveedor> list = Proveedores.GetTodos();

            var result = (from fila in list
                          where fila.pronombre.Contains(pronombre)
                          select new
                          {
                              fila.proid,
                              fila.procodigo,
                              fila.prorazonsocial,
                              fila.prodireccion,
                              fila.probarrio,

                          }).ToList();

            if (result.Count > 0)
            {
                dgvProveedor.DataSource = result;
                dgvProveedor.CurrentRow.Selected = false;
                PersonalizarGrilla();
            }
            else
            {
                dgvProveedor.DataSource = null;
            }
        }

        //LISTO
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty)
            {
                BuscarLikeNombre(txtNombre.Text);                
            }
        } 

    }
}
