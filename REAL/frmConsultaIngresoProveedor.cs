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
    public partial class frmConsultaIngresoProveedor : Form
    {
        public frmConsultaIngresoProveedor()
        {
            InitializeComponent();
        }


        private void IniciarControles()
        {
            txtProducto.Enabled = false;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;
            cmbProveedor.Enabled = false;
            cmbSucursal.Enabled = false;
            dgvEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void CargarGrilla()
        {
            //DataTable dt = new DataTable();
            //dt = FacturasProveedorDetalle.GetFacturaProveedorTodo();
            //if(dt.Rows.Count>0)
            //{
            //    dgvEntregas.DataSource = dt.DefaultView;
            //    PersonalizarGrilla();
            //}
            
        }

        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetTodos();

        }

        private void CargarComboBoxSucursal()
        {
            cmbSucursal.ValueMember = "sucid";
            cmbSucursal.DisplayMember = "sucnombre";
            cmbSucursal.DataSource = Sucursales.GetTodos();

        }

        private void PersonalizarGrilla()
        {
            //dgvEntregas.Columns[0].Visible = false;
            //dgvEntregas.Columns[1].HeaderText = "Nro. Fac.";
            //dgvEntregas.Columns[2].HeaderText = "Nro. Rem.";
            //dgvEntregas.Columns[3].HeaderText = "Fec. Fac.";
            //dgvEntregas.Columns[4].HeaderText = "Fec. Rec.";
            //dgvEntregas.Columns[5].HeaderText = "Sucursal";
            //dgvEntregas.Columns[6].HeaderText = "Producto";
            //dgvEntregas.Columns[7].HeaderText = "Cant.";
            //dgvEntregas.Columns[8].HeaderText = "Imp. Unit.";
            //dgvEntregas.Columns[9].HeaderText = "Total";
            //dgvEntregas.Columns[10].HeaderText = "Nro. Orden";

            //dgvEntregas.Columns[8].DefaultCellStyle.Format = "c";
            //dgvEntregas.Columns[9].DefaultCellStyle.Format = "c";

            //dgvEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgvEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvEntregas.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        private void CargarDataGrid()
        {
            var query = (from row in RemitosProveedor.FindIngresos()
                         select new
                         {
                             row.remitoproveedor.id,                             
                             row.remitoproveedor.numero,
                             row.remitoproveedor.fechaemision,
                             row.remitoproveedor.fecharecepcion,
                             row.remitoproveedor.sucursal.sucnombre,
                             row.producto.prddenominacion,
                             row.cantidad,
                             row.ordencompra.odcnumero,
                             row.ordencompra.odcfecha

                         }).ToList();

            dgvEntregas.Rows.Clear();
            foreach(var fila in query)
            {
                dgvEntregas.Rows.Add(fila.id, fila.numero, fila.fechaemision.ToShortDateString(), 
                    fila.fecharecepcion.ToShortDateString(), fila.sucnombre, fila.prddenominacion, 
                    fila.cantidad, fila.odcnumero, fila.odcfecha.ToShortDateString());
            }
        }

        private void FiltrarForm()
        {
            string nroremito = txtRemito.Text == string.Empty ? null : txtRemito.Text;
            string producto = ckbProducto.Checked ? (string)txtProducto.Text : null;
            
            int? proveedor_id = ckbProveedor.Checked ? (int?)Convert.ToInt32(cmbProveedor.SelectedValue) : null;
            int? sucursal_id = ckbSucursal.Checked ? (int?)Convert.ToInt32(cmbSucursal.SelectedValue) : null;
            
            DateTime? desde = ckbFecha.Checked ? (DateTime?)dtpDesde.Value : null;
            DateTime? hasta = ckbFecha.Checked ? (DateTime?)dtpHasta.Value : null;

            var query = (from row in RemitosProveedor.FindIngresosCondicional(nroremito, producto, proveedor_id, sucursal_id, desde, hasta)
                         select new
                         {
                             row.remitoproveedor.id,
                             row.remitoproveedor.numero,
                             row.remitoproveedor.fechaemision,
                             row.remitoproveedor.fecharecepcion,
                             row.remitoproveedor.sucursal.sucnombre,
                             row.producto.prddenominacion,
                             row.cantidad,
                             row.ordencompra.odcnumero,
                             row.ordencompra.odcfecha

                         }).ToList();

            dgvEntregas.Rows.Clear();
            foreach (var fila in query)
            {
                dgvEntregas.Rows.Add(fila.id, fila.numero, fila.fechaemision.ToShortDateString(),
                    fila.fecharecepcion.ToShortDateString(), fila.sucnombre, fila.prddenominacion,
                    fila.cantidad, fila.odcnumero, fila.odcfecha.ToShortDateString());
            }
        }

        private void frmConsultaIngresoProveedor_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            IniciarControles();
            //CargarGrilla();
            CargarComboBoxProveedor();
            CargarComboBoxSucursal();

            CargarDataGrid();
        }

        private void frmConsultaIngresoProveedor_Resize(object sender, EventArgs e)
        {
            //dgvEntregas.Width = this.Width - 40;
            //dgvEntregas.Height = this.Height - 300;
            //groupBox1.Width = this.Width - 40;
            //btnAceptar.Location = new Point(20, this.Height - 70);
            //btnCancelar.Location = new Point(this.Width - 100, this.Height - 70);
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            FiltrarForm();
            //if (txtProducto.Text != string.Empty)
            //{
            //    DataTable dt = new DataTable();
            //    dt = FacturasProveedorDetalle.GetFacturaProveedorTodoPorNombreProducto(txtProducto.Text);
            //    if (dt.Rows.Count > 0)
            //    {
            //        dgvEntregas.DataSource = dt.DefaultView;
            //        PersonalizarGrilla();
            //    }
            //    else
            //    {
            //        dgvEntregas.DataSource = null;
            //    }
            //}
        }

        private void txtFactura_TextChanged(object sender, EventArgs e)
        {
            //if (txtFactura.Text != string.Empty)
            //{
            //    DataTable dt = new DataTable();
            //    dt = FacturasProveedorDetalle.GetFacturaProveedorTodoPorNumeroFactura(txtFactura.Text);
            //    if (dt.Rows.Count > 0)
            //    {
            //        dgvEntregas.DataSource = dt.DefaultView;
            //        PersonalizarGrilla();
            //    }
            //    else
            //    {
            //        dgvEntregas.DataSource = null;
            //    }
            //}
        }

        private void txtRemito_TextChanged(object sender, EventArgs e)
        {
            FiltrarForm();
            //if (txtRemito.Text != string.Empty)
            //{
            //    DataTable dt = new DataTable();
            //    dt = FacturasProveedorDetalle.GetFacturaProveedorTodoPorNumeroRemito(txtRemito.Text);
            //    if (dt.Rows.Count > 0)
            //    {
            //        dgvEntregas.DataSource = dt.DefaultView;
            //        PersonalizarGrilla();
            //    }
            //    else
            //    {
            //        dgvEntregas.DataSource = null;
            //    }
            //}
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {


            FiltrarForm();

            //errorProvider1.Clear();
            //if (ckbFecha.Checked == true)
            //{
            //    if (dtpDesde.Value <= dtpHasta.Value)
            //    {
            //        DataTable dt = new DataTable();
            //        dt = FacturasProveedorDetalle.GetFacturaProveedorTodoEntreFechas(dtpDesde.Value, dtpHasta.Value);
            //        if (dt.Rows.Count > 0)
            //        {
            //            dgvEntregas.DataSource = dt.DefaultView;
            //            PersonalizarGrilla();

            //        }
            //        else
            //        {
            //            dgvEntregas.DataSource = null;
            //        }
            //    }
            //    else
            //    {
            //        errorProvider1.SetError(dtpDesde, "LA FECHA INICIAL NO PUEDE SER MAYOR A LA FINAL");
            //    }

            //}
            //else
            //{
            //    if (ckbProveedor.Checked == true)
            //    {
            //        DataTable dt = new DataTable();
            //        dt = FacturasProveedorDetalle.GetFacturaProveedorTodoPorIdProveedor(Convert.ToInt32(cmbProveedor.SelectedValue));
            //        if (dt.Rows.Count > 0)
            //        {
            //            dgvEntregas.DataSource = dt.DefaultView;
            //            PersonalizarGrilla();
            //        }
            //        else
            //        {
            //            dgvEntregas.DataSource = null;
            //        }

            //    }
            //    else
            //    {

            //        if (ckbSucursal.Checked == true)
            //        {
            //            DataTable dt = new DataTable();
            //            dt = FacturasProveedorDetalle.GetFacturaProveedorTodoPorIdSucursal(Convert.ToInt32(cmbSucursal.SelectedValue));
            //            if (dt.Rows.Count > 0)
            //            {

            //                dgvEntregas.DataSource = dt.DefaultView;
            //                PersonalizarGrilla();

            //            }
            //            else
            //            {
            //                dgvEntregas.DataSource = null;
            //            }



            //        }
            //        else
            //        {
            //            DataTable dt = new DataTable();
            //            dt = FacturasProveedorDetalle.GetFacturaProveedorTodo();
            //            if (dt.Rows.Count > 0)
            //            {
            //                dgvEntregas.DataSource = dt.DefaultView;
            //                PersonalizarGrilla();
            //            }
            //            else
            //            {
            //                dgvEntregas.DataSource = null;
            //            }

            //        }


            //    }

            //}
        }

        private void ckbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFecha.CheckState == CheckState.Checked)
            {
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
            }
            else
            { 
                dtpHasta.Enabled = false;
                dtpDesde.Enabled = false;
            }
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO REMITO";
                e.Handled = true;
                //txtFactura.Focus();
                return;
            }
        }

        private void txtRemito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '-'))
            {
                //lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO REMITO";
                e.Handled = true;
                txtRemito.Focus();
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbProveedor.CheckState == CheckState.Checked)
                cmbProveedor.Enabled = true;
            else
                cmbProveedor.Enabled = false;
        }

        private void ckbSucursal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSucursal.CheckState == CheckState.Checked)
                cmbSucursal.Enabled = true;
            else
                cmbSucursal.Enabled = false;
        }

        private void ckbProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbProducto.CheckState == CheckState.Checked)
                txtProducto.Enabled = true;
            else
                txtProducto.Enabled = false;
        }

        private void dgvEntregas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvEntregas.CurrentCell.ColumnIndex.Equals(9))
            {
                int x = dgvEntregas.CurrentRow.Index;
                int remito_id = Convert.ToInt32(dgvEntregas.Rows[x].Cells[0].Value);
                string remito_numero = dgvEntregas.Rows[x].Cells[1].Value.ToString();
                IList<FacturaProveedor> facturasL = FacturasProveedor.FindFacturasProveedorPorIdRemito(remito_id);
                if (facturasL.Count > 0)
                {
                    string mensaje = string.Empty;
                    foreach (var fila in facturasL)
                    {
                        mensaje = mensaje + Environment.NewLine + " * " + fila.numero + " - " + fila.fecha.ToShortDateString();
                    }

                    string msg = "Facturas Asociadas al Remito: " + remito_numero + Environment.NewLine;
                    msg = msg + mensaje;
                    MessageBox.Show(msg, "Facturas Asociadas al Remito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El Remito de Compra no tiene asociada ninguna Factura.", "Facturas Asociadas al Remito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

      
    }
}
