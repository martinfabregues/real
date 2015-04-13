using Entidad;
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
    public partial class dlgProducto : Form
    {
        public int prdid { get; set; }
        public string prdcodigo {get; set;}
        public int proid { get; set; }
        public string tipooperacion { get; set; }

        public dlgProducto(int pi)
        {
            proid = pi;
            InitializeComponent();
        }


        public dlgProducto()
        {
            tipooperacion = "remito";

            InitializeComponent();
        }

        private void CargarGrid()
        {
            try
            {
                List<Producto> list = Productos.GetTodosConsulta();

                var result = (from producto in list
                              where producto.proveedor.proid == proid && producto.estado.estid == 1
                              select new
                              {
                                  producto.prdid,  
                                  producto.prdcodigo,
                                  producto.categoria.catnombre,
                                  producto.prddenominacion,

                              }).ToList();

                if (result.Count > 0)
                {
                    dgvProductos.DataSource = result;
                    dgvProductos.CurrentRow.Selected = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CargarGridCompleto()
        {
            try
            {
                List<Producto> list = Productos.GetTodosConsulta();

                var result = (from producto in list
                              where producto.estado.estid == 1
                              select new
                              {
                                  producto.prdid,
                                  producto.prdcodigo,
                                  producto.categoria.catnombre,
                                  producto.prddenominacion,

                              }).ToList();

                if (result.Count > 0)
                {
                    dgvProductos.DataSource = result;
                    dgvProductos.CurrentRow.Selected = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PersonalizarGrid()
        {
            if (dgvProductos.Rows.Count > 0)
            {
                dgvProductos.Columns[0].Visible = false;
                dgvProductos.Columns[1].HeaderText = "Código";
                dgvProductos.Columns[2].HeaderText = "Categoria";                
                dgvProductos.Columns[3].HeaderText = "Producto";


            }
        }
      
        private void dlgProducto_Load(object sender, EventArgs e)
        {
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (tipooperacion == "remito")
            {
                CargarGridCompleto();
                PersonalizarGrid();
            }
            else
            {
                CargarGrid();
                PersonalizarGrid();
            }
            

            this.ActiveControl = txtNombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                if (dgvProductos.CurrentRow.Index > -1)
                {
                    prdid = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
                    prdcodigo = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                dgvProductos.DataSource = null;
                errorProvider1.SetError(btnBuscar, "Debe completar el campo nombre.");
                txtNombre.Focus();
            }
            else
            {
                if (tipooperacion == "remito")
                {
                    BuscarLikeDenominacionCompleto(txtNombre.Text);
                    PersonalizarGrid();
                }
                else
                {
                    BuscarLikeDenominacion(txtNombre.Text);
                    PersonalizarGrid();
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                dgvProductos.DataSource = null;
                errorProvider1.SetError(btnBuscar, "Debe completar el campo nombre.");
                txtNombre.Focus();
            }
            else
            {
                if (tipooperacion == "remito")
                {
                    BuscarLikeDenominacionCompleto(txtNombre.Text);
                    PersonalizarGrid();
                }
                else
                {
                    BuscarLikeDenominacion(txtNombre.Text);
                    PersonalizarGrid();
                }
                
            }
        }

        private void dgvProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //
            // Si el control DataGridView no tiene el foco, 
            // se abandonamos el procedimiento, llamando al metodo base
            //
            
            if ((!dgvProductos.Focused))
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
            if (dgvProductos.SelectedRows.Count > 0)
            {
                if (dgvProductos.CurrentRow.Index > -1)
                {
                    DataGridViewRow row = dgvProductos.CurrentRow;
                    prdid = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
                    prdcodigo = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    //frmSeleccion frm = new frmSeleccion(cuenta, desc);
                    //frm.ShowDialog();
                }
            }

            return true;
        }

        private void BuscarLikeDenominacion(String prddenominacion)
        {
            try
            {
                List<Producto> list = Productos.GetTodosConsulta();

                var result = (from producto in list
                              where producto.proveedor.proid == proid && producto.estado.estid == 1 && producto.prddenominacion.Contains(prddenominacion)
                              select new
                              {
                                  producto.prdid,
                                  producto.prdcodigo,
                                  producto.categoria.catnombre,   
                                  producto.prddenominacion,

                              }).ToList();

                if (result.Count > 0)
                {
                    dgvProductos.DataSource = result;
                    dgvProductos.CurrentRow.Selected = false;
                }
                else
                {
                    dgvProductos.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BuscarLikeDenominacionCompleto(String prddenominacion)
        {
            try
            {
                List<Producto> list = Productos.GetTodosConsulta();

                var result = (from producto in list
                              where producto.estado.estid == 1 && producto.prddenominacion.Contains(prddenominacion)
                              select new
                              {
                                  producto.prdid,
                                  producto.prdcodigo,
                                  producto.categoria.catnombre,
                                  producto.prddenominacion,

                              }).ToList();

                if (result.Count > 0)
                {
                    dgvProductos.DataSource = result;
                    dgvProductos.CurrentRow.Selected = false;
                }
                else
                {
                    dgvProductos.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
