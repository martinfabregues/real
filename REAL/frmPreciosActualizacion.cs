using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmPreciosActualizacion : Form
    {
        public frmPreciosActualizacion()
        {
            InitializeComponent();
        }


        private void CargarComboProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "prorazonsocial";
            cmbProveedor.DataSource = Proveedores.GetTodos();
        }


        private void CargarComboListaPrecio(Proveedor proveedor)
        {
            cmbLista.ValueMember = "listaprecio_id";
            cmbLista.DisplayMember = "listaprecio_denominacion";
            IList<ListaPrecio> listas = ListasPrecio.GetTodosPorIdProveedor(proveedor);
            if (listas.Count > 0)
            {
                cmbLista.DataSource = listas;
            }
            else
            {
                cmbLista.DataSource = null;
                cmbLista.Items.Add("NO HAY LISTAS REGISTRADAS.");
            }

        }


        private void frmPreciosActualizacion_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;

            CargarComboProveedor();
            PersonalizarGrid();
        }

        private void cmbProveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarComboListaPrecio((Proveedor)cmbProveedor.SelectedItem);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDatos();
        }


        private void BuscarDatos()
        {
            dgvDetalle.Rows.Clear();
            List<ListaPrecioProducto> lista = ListasPrecioProducto.GetTodoPorIdLista(Convert.ToInt32(cmbLista.SelectedValue));

            if (lista.Count > 0)
            {
                foreach (ListaPrecioProducto fila in lista)
                {
                    dgvDetalle.Rows.Add(fila.listaprecioproducto_id, fila.listaprecio.listaprecio_denominacion, fila.producto.prddenominacion, fila.listaprecioproducto_costobruto, fila.listaprecioproducto_costoneto, fila.listaprecioproducto_precioventa);
                }

                PersonalizarGrid();
            }
            else
            {
                dgvDetalle.DataSource = null;
            }          

        }


        private void PersonalizarGrid()
        {
            dgvDetalle.Columns[0].Visible = false;
            dgvDetalle.Columns[1].HeaderText = "Lista de Precio";
            dgvDetalle.Columns[2].HeaderText = "Producto";
            dgvDetalle.Columns[3].HeaderText = "Costo Bruto";
            dgvDetalle.Columns[4].HeaderText = "Costo Neto";
            dgvDetalle.Columns[5].HeaderText = "Precio Venta";

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
            dgvDetalle.EditMode = DataGridViewEditMode.EditOnF2;

            //dgvDetalle.Columns[3].DefaultCellStyle.Format = "c"; 
            //dgvDetalle.Columns[4].DefaultCellStyle.Format = "c";
            //dgvDetalle.Columns[5].DefaultCellStyle.Format = "c";
        }

        private void frmPreciosActualizacion_Resize(object sender, EventArgs e)
        {
            this.dgvDetalle.Width = this.Width - 40;
            this.dgvDetalle.Height = this.Height - 200;
            btnActualizar.Location = new Point(this.Width - 200, this.Height - 80);
        }

        private DataTable CrearDataTable()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("listaprecioproducto_id");
            datos.Columns.Add("listaprecio_denominacion");
            datos.Columns.Add("prddenominacion");
            datos.Columns.Add("listaprecioproducto_costobruto"); 
            datos.Columns.Add("listaprecioproducto_costoneto");
            datos.Columns.Add("listaprecioproducto_precioventa");

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                DataRow fila = datos.NewRow();
                fila["listaprecioproducto_id"] = row.Cells[0].Value;
                fila["listaprecio_denominacion"] = row.Cells[1].Value;
                fila["prddenominacion"] = row.Cells[2].Value;
                fila["listaprecioproducto_costobruto"] = row.Cells[3].Value;
                fila["listaprecioproducto_costoneto"] = row.Cells[4].Value;
                fila["listaprecioproducto_precioventa"] = row.Cells[5].Value;

                datos.Rows.Add(fila);
            }
            return datos;
        }

        private void ActualizarCostos()
        {
            DataTable datos = CrearDataTable();          
            bool resultado = ListasPrecioProducto.ActualizarCostos(datos);
            if (resultado == true)
            {
                MessageBox.Show("Se actualizaron los precios correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BuscarDatos();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al actualizar los precios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarCostos();
        }

        private void dgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 3)
            {
                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxNumeric_KeyPress);

            }
        }

        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {          
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || char.IsControl(e.KeyChar)
                )
            {

                e.Handled = false;
            }

            else
            {             
                e.Handled = true;
            }
        }

    }
}
