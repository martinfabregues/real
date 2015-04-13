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
    public partial class frmOrdenCompraABM : Form
    {
        private int count = 0;

        public frmOrdenCompraABM()
        {
            InitializeComponent();
        }

        private void frmOrdenCompraABM_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarComboProveedor();
           
            IniciarControles();

            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void AgregarColumnasGrid()
        {
            //DataGridViewButtonColumn detalle = new DataGridViewButtonColumn();
            //detalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //detalle.HeaderText = "Detalles";
            //detalle.Name = "btnDetalle";
            //detalle.Text = "Detalles";
            //detalle.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn reeimprimir = new DataGridViewButtonColumn();
            reeimprimir.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            reeimprimir.HeaderText = "Imprimir";
            reeimprimir.Name = "btnImprimir";
            reeimprimir.Text = "Imprimir";
            reeimprimir.UseColumnTextForButtonValue = true;


            //_grid.Columns.Add(detalle);
            //dgvOrdenes.Columns.Add(reeimprimir);

            count = 1;
        }

        private void IniciarControles()
        {
            this.Text = "Ordenes de Compra ABM - Administrar Ordenes de Compra";
            btnSalir.Visible = false;
        }

        private void CargarDatos()
        {
            IList<OrdenCompra> ordenes = OrdenesCompra.FindAll();

            foreach(OrdenCompra row in ordenes)
            {
                dgvOrdenes.Rows.Add(row.odcid, row.odcnumero, row.odcfecha.ToShortDateString(), row.proveedor.pronombre, row.odcimporte, row.odcactivo);
            }

         

            dgvOrdenes.Columns[0].Visible = false;
            dgvOrdenes.Columns[4].DefaultCellStyle.Format = "c";

            AgregarColumnasGrid();
            dgvOrdenes.SelectedRows[0].Selected = false;
        }

        private void CargarComboProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "prorazonsocial";

            cmbProveedor.DataSource = Proveedores.FindAll();

            //cmbProveedor.AutoCompleteCustomSource = LoadAutoComplete();
            //cmbProveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cmbProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public static AutoCompleteStringCollection LoadAutoComplete()
        {
            IList<Proveedor> datos = Proveedores.FindAll(); ;
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (Proveedor fila in datos)
            {
                stringCol.Add(Convert.ToString(fila.prorazonsocial));
            }

            return stringCol;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes._reporteComprasListado frm = new Reportes._reporteComprasListado();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevaOrdenCompra frm = new frmNuevaOrdenCompra("NUEVO");
            frm.MdiParent = this.MdiParent;
            frm.Text = "COMPRAS - NUEVA ORDEN DE COMPRA";
            frm.Show();
        }

        private void _grid_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void _grid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (count != 0)
            {
                int id = Convert.ToInt32(dgvOrdenes.Rows[e.RowIndex].Cells[1].Value);
                OrdenCompra orden = new OrdenCompra();
                orden.odcid = id;
                //ObtenerDetalle(orden);
            }
        }

        //private void ObtenerDetalle(OrdenCompra orden)
        //{
        //    dgvDetalle.DataSource = null;
        //    OrdenCompra ordencompra = OrdenesCompra.FindByIdWithDetalle(orden.odcid);

        //    var det = (from row in ordencompra.Detalle
        //               select new
        //               {
        //                   Sucursal = row.sucursal.sucnombre,                     
        //                   Código = row.producto.prdcodigo,
        //                   Cant = row.ocdcantidad,
        //                   Producto = row.producto.prddenominacion,
        //                   Importe = row.ocdimporteunit,
        //                   Total = row.ocdimporteunit * row.ocdcantidad,

        //               }).ToList();

        //    dgvDetalle.DataSource = det;

        //    dgvDetalle.Columns[4].DefaultCellStyle.Format = "c";
        //    dgvDetalle.Columns[5].DefaultCellStyle.Format = "c";
        //}

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmNuevaOrdenCompra frm = new frmNuevaOrdenCompra("MODIFICAR");
            frm.MdiParent = this.MdiParent;
            frm.Text = "COMPRAS - MODIFICAR ORDEN DE COMPRA";
            frm.Show();
        }

        private void _grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrdenes.Columns[e.ColumnIndex].Name == "btnImprimir")
            {
                DataGridViewRow fila = dgvOrdenes.CurrentRow;

                int id = Convert.ToInt32(fila.Cells[1].Value);
                frmReporteOrdenCompra frm = new frmReporteOrdenCompra(id);
                frm.MdiParent = this.MdiParent;
                string fmt = "00000000.##";
                frm.Text = "IMPRESIÓN ORDEN DE COMPRA N° " + id.ToString(fmt);
                frm.Show();
            }
        }

        private void dgvOrdenes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (count != 0)
            //{
            //    int id = Convert.ToInt32(dgvOrdenes.Rows[e.RowIndex].Cells[0].Value);
            //    OrdenCompra orden = new OrdenCompra();
            //    orden.odcid = id;
            //    //ObtenerDetalle(orden);
            //}
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            frmNuevaOrdenCompra frm = new frmNuevaOrdenCompra("NUEVO");
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells[0].Value);
            string numero = dgvOrdenes.CurrentRow.Cells[1].Value.ToString();
            DialogResult result = MessageBox.Show("Desea modificar la Orden de Compra Nro. " + numero + " ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                frmNuevaOrdenCompra frm = new frmNuevaOrdenCompra("MODIFICAR", id);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells[0].Value);
            string numero = dgvOrdenes.CurrentRow.Cells[1].Value.ToString();
            DialogResult result = MessageBox.Show("Desea anular la Orden de Compra Nro. " + numero  +  " ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {

            }
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells[0].Value);
            string numero = dgvOrdenes.CurrentRow.Cells[1].Value.ToString();
            DialogResult result = MessageBox.Show("Desea imprimir la Orden de Compra Nro. " + numero + " ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                frmReporteOrdenCompra frm = new frmReporteOrdenCompra(id);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrdenCompraABM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string nroorden = txtNumero.Text == string.Empty ? null : txtNumero.Text;
            int? proveedor_id = Convert.ToInt32(cmbProveedor.SelectedValue) == -1 ? null : (int?)Convert.ToInt32(cmbProveedor.SelectedValue);
            DateTime? desde   = ckbFecha.Checked ? (DateTime?)dtpDesde.Value : null;
            DateTime? hasta   = ckbFecha.Checked ? (DateTime?)dtpHasta.Value : null;



        }

        private void FiltrarForm(string? numero, int? proveedor_id, DateTime? desde, DateTime? hasta)
        {
            var query = (from row in OrdenesCompra.BusquedaCondicional(numero, proveedor_id, desde, hasta)
                         select row).ToList();

            dgvOrdenes.Rows.Clear();
            foreach(var fila in query)
            {
                //agreagar filas filtradas al datagrid
                dgvOrdenes.Rows.Add();
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvOrdenes.Columns[e.ColumnIndex].Name == "detalle")
            {
                int id = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells[0].Value);
                string numero = dgvOrdenes.CurrentRow.Cells[1].Value.ToString();
                //DialogResult result = MessageBox.Show("Desea imprimir la Orden de Compra Nro. " + numero + " ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == System.Windows.Forms.DialogResult.Yes)
                //{
                    frmReporteOrdenCompra frm = new frmReporteOrdenCompra(id);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                //}
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                errorProvider1.SetError(txtNumero, "Solo se permiten números en el campo Nro. de Orden.");
                e.Handled = true;
                txtCantidad1.Focus();
                return;
            }
        }
    }
}
