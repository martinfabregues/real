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
    public partial class frmPendientesEliminar : Form
    {
        public frmPendientesEliminar()
        {
            InitializeComponent();
        }

        private void CargarDataGrid()
        {

            var query = (from row in OrdenesCompra.FindPendientes()
                         select new
                         {
                             odcid = row.id,
                             odcnumero = row.ordencompra.numero,
                             odcfecha = row.ordencompra.fecha,
                             row.proveedor.pronombre,
                             row.producto.prdcodigo,
                             row.producto.prddenominacion,
                             ocdcantidad = (row.cantidad - row.ingreso),
                             ocdimporte = row.importe_unitario,
                             total = (row.cantidad * row.importe_unitario),
                             row.sucursal.sucnombre

                         }).ToList();

            dgvDetalle.Rows.Clear();
            foreach (var fila in query)
            {
                dgvDetalle.Rows.Add(fila.odcid, fila.odcnumero, fila.odcfecha.ToShortDateString(), fila.pronombre, 
                    fila.prdcodigo, fila.prddenominacion, fila.ocdcantidad, fila.ocdimporte, fila.total, fila.sucnombre);
            }

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void CrearColumnaEliminar()
        {
            DataGridViewButtonColumn Eliminar = new DataGridViewButtonColumn();
            Eliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Eliminar.HeaderText = "Eliminar Producto";
            Eliminar.Name = "btnEliminar";
            Eliminar.Text = "Eliminar Producto";
            Eliminar.UseColumnTextForButtonValue = true;

            dgvDetalle.Columns.Add(Eliminar);

        }


        private void PersonalizarDataGrid()
        {
            dgvDetalle.Columns[0].Visible = false;
            dgvDetalle.Columns[1].HeaderText = "Sucursal";
            dgvDetalle.Columns[2].HeaderText = "Proveedor";
            dgvDetalle.Columns[3].HeaderText = "N° Orden";
            dgvDetalle.Columns[4].HeaderText = "Fecha Orden";
            dgvDetalle.Columns[5].HeaderText = "Cantidad";
            dgvDetalle.Columns[6].HeaderText = "Código Producto";
            dgvDetalle.Columns[7].HeaderText = "Producto";
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;

        }


        private void CargarComboProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetTodos();
        }

        private void CargarComboSucursal()
        {
            cmbSucursal.ValueMember = "sucid";
            cmbSucursal.DisplayMember = "sucnombre";
            cmbSucursal.DataSource = Sucursales.GetTodos();
        }

        private void frmPendientesEliminar_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            CargarDataGrid();
            //PersonalizarDataGrid();
            //CrearColumnaEliminar();

            CargarComboProveedor();
            CargarComboSucursal();
        }

        private void frmPendientesEliminar_Resize(object sender, EventArgs e)
        {
            dgvDetalle.Width = this.Width - 40;
            dgvDetalle.Height = this.Height - 220;
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0 && dgvDetalle.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                 DialogResult result = MessageBox.Show("Se va a eliminar el producto del registro, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (result == System.Windows.Forms.DialogResult.Yes)
                 {
                     DataGridViewRow fil = dgvDetalle.CurrentRow;
                     int fila = dgvDetalle.CurrentRow.Index;
                     int resultado = OrdenesCompraPendiente.EliminarPendiente(Convert.ToInt32(fil.Cells[0].Value));
                     if (resultado > 0)
                     {
                         CargarDataGrid();
                     }
                     else
                     {
                         MessageBox.Show("Ocurrio un error al intentar borrar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }

            }
        }


        private void FiltrarForm()
        {
            int? proveedor_id = Convert.ToInt32(cmbProveedor.SelectedValue);
            int? sucursal_id = Convert.ToInt32(cmbSucursal.SelectedValue);

            string numero_orden = null;
            string producto = txtProducto.Text == string.Empty ? null : txtProducto.Text;

            var query = (from row in OrdenesCompra.FindPendientesCondicional(proveedor_id, sucursal_id, numero_orden, producto)
                         select new
                         {
                             odcid = row.id,
                             odcnumero = row.ordencompra.numero,
                             odcfecha = row.ordencompra.fecha,
                             row.proveedor.pronombre,
                             row.producto.prdcodigo,
                             row.producto.prddenominacion,
                             ocdcantidad = (row.cantidad - row.ingreso),
                             ocdimporte = row.importe_unitario,
                             total = (row.cantidad * row.importe_unitario),
                             row.sucursal.sucnombre

                         }).ToList();

            dgvDetalle.Rows.Clear();
            foreach (var fila in query)
            {
                dgvDetalle.Rows.Add(fila.odcid, fila.odcnumero, fila.odcfecha.ToShortDateString(), fila.pronombre, 
                    fila.prdcodigo, fila.prddenominacion, fila.ocdcantidad, fila.ocdimporte, fila.total, fila.sucnombre);
            }


            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void BuscarPorCriterio()
        {
            OrdenCompraPendienteCriteria filtro = new OrdenCompraPendienteCriteria()
            {
                producto = txtProducto.Text == string.Empty ? null : new Producto() { prddenominacion = txtProducto.Text },
                proveedor = Convert.ToInt32(cmbProveedor.SelectedValue) == -1 ? null : new Proveedor() { proid = Convert.ToInt32(cmbProveedor.SelectedValue) },
                sucursal = Convert.ToInt32(cmbSucursal.SelectedValue) == -1 ? null : new Sucursal() { sucid = Convert.ToInt32(cmbSucursal.SelectedValue) }
       
            };

            try
            {
                List<OrdenCompraPendiente> list = OrdenesCompraPendiente.GetByCriteria(filtro);
                if (list.Count > 0)
                {
                    var resultado = (from pendiente in list
                                     orderby pendiente.ordencompra.fecha ascending
                                     select new
                                     {
                                         ocpid = pendiente.id,
                                         pendiente.sucursal.sucnombre,
                                         pendiente.proveedor.pronombre,
                                         odcnumero = pendiente.ordencompra.numero,
                                         odcfecha = pendiente.ordencompra.fecha,
                                         ocdcantidad = pendiente.cantidad,
                                         pendiente.producto.prdcodigo,
                                         pendiente.producto.prddenominacion,
                                     }).ToList();

                    dgvDetalle.DataSource = resultado;

                    PersonalizarDataGrid();
                    CrearColumnaEliminar();
                }
                else
                {

                    dgvDetalle.DataSource = null;
                    dgvDetalle.Columns.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarForm();
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtProducto.Text))
            {
                FiltrarForm();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
