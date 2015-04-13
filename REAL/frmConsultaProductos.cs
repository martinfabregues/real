using DAL;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmConsultaProductos : Form
    {
        public frmConsultaProductos()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            cmbProveedor.Enabled = false;
            txtNombre.Enabled = false;

        }

        private void CargarGrid(List<Producto> list)
        {
            try
            {               
                var result = (from filaproducto in list
                              select new
                              {
                                  filaproducto.prdid,
                                  filaproducto.proveedor.pronombre,
                                  filaproducto.marca.mardenominacion,
                                  filaproducto.categoria.catnombre,
                                  filaproducto.prdcodigo,
                                  filaproducto.prddenominacion,
                                  filaproducto.prdcosto,
                                  filaproducto.prdmetros,
                                  filaproducto.estado.estestado
                              }).ToList();

                dgvProductos.DataSource = result;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void PersonalizarGrid()
        {
            dgvProductos.Columns[0].Visible = false;

            dgvProductos.Columns[0].HeaderText = "ID";
            dgvProductos.Columns[1].HeaderText = "PROVEEDOR";
            dgvProductos.Columns[2].HeaderText = "MARCA";
            dgvProductos.Columns[3].HeaderText = "CATEGORIA";
            dgvProductos.Columns[4].HeaderText = "CÓDIGO";
            dgvProductos.Columns[5].HeaderText = "PRODUCTO";
            dgvProductos.Columns[6].HeaderText = "COSTO BRUTO";
            dgvProductos.Columns[7].HeaderText = "METROS";
            dgvProductos.Columns[8].HeaderText = "ESTADO";


            dgvProductos.Columns[6].DefaultCellStyle.Format = "c";

            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }
   
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetTodos();
        }

        private void frmConsultaProductos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            IniciarControles();        
            CargarComboBoxProveedor();

            backgroundWorker.RunWorkerAsync();
          
        }

        private void ckbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            if (ckbProveedor.Checked == true)
                cmbProveedor.Enabled = true;
            else
                cmbProveedor.Enabled = false;
        }

        private void ckbProducto_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            if (ckbProducto.Checked == true)
                txtNombre.Enabled = true;
            else
                txtNombre.Enabled = false;
                txtNombre.Text = string.Empty;
        }

        private void BuscarPorCriterio()
        {
            ProductoCriteria filtro = new ProductoCriteria()
            {
                prddenominacion = txtNombre.Text,
                proveedor = Convert.ToInt32(cmbProveedor.SelectedValue) == -1 ? null : new Proveedor() { proid = Convert.ToInt32(cmbProveedor.SelectedValue) }
            };

            try
            {
                List<Producto> list = Productos.GetFiltro(filtro);
                CargarGrid(list);
                PersonalizarGrid();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPorCriterio();
        }

        private void frmConsultaProductos_Resize(object sender, EventArgs e)
        {
            dgvProductos.Width = this.Width - 40;
            dgvProductos.Height = this.Height - 250;
            btnCerrar.Location = new Point(this.Width - 110, this.Height - 80);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty)
            {
                BuscarPorCriterio();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Producto> list = e.Argument as List<Producto>;
            //Thread.Sleep(10000);
            list = Productos.GetTodosConsulta();
            e.Result = list;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CargarGrid(e.Result as List<Producto>);
            PersonalizarGrid();
        }

    }
}
