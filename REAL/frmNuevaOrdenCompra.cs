using Entidad;
using Negocio;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Configuration;
using DAL;
using REAL.Utils;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace REAL
{
    public partial class frmNuevaOrdenCompra : Form
    {
        public string tipoMovimiento { get; set; }
        private List<OrdenCompraDetalle> listado = new List<OrdenCompraDetalle>();
        private int indexproveedor;
        public int orden_id { get; set; }

        //public int odcid { get; set; }
        public frmNuevaOrdenCompra(string tM)
        {
            tipoMovimiento = tM;
            //odcid = oC;
            InitializeComponent();
        }

        public frmNuevaOrdenCompra(string op, int id)
        {
            tipoMovimiento = op;
            orden_id = id;
            //odcid = oC;
            InitializeComponent();
        }

        //LISTO
        private void IniciarControlesModificar()
        {
            
            txtMetros.Visible = false;
            txtIdOrden.Visible = false;
            txtid.Visible = false;
            txtCodigo.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtProducto.Enabled = false;
            lblTotal.Text = "0.00";
            dgvDetalle.DataSource = null;

            Bitmap img = new Bitmap(Properties.Resources.search, new Size(16, 16));

            txtCosto.Enabled = false;
            txtObservacion.Text = string.Empty;
            cmbProveedor.SelectedIndex = 0;
            btnBuscar.Image = img;
          
            txtCoeficiente.Text = string.Empty;
            txtCoeficiente.Visible = false;
           
            txtCostoNeto.Enabled = false;
            txtCostoNeto.Text = string.Empty;
            lblSubtotal.Text = "0.00";
            lblIva.Text = "0.00";
            lblIngBrutos.Text = "0.00";
            lblMetros.Text = "0.00";
            ProgressBar1.Visible = false;

            txtOrden.Visible = false;
          
        }

        //LISTO
        private void IniciarControles()
        {
            Bitmap img = new Bitmap(Properties.Resources.search, new Size(16, 16));
            btnBuscar.Image = img;
        
            txtOrden.Visible = false;
            txtIdOrden.Visible = false;
         
            //label8.Visible = false;
            txtid.Visible = false;
            txtCodigo.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtProducto.Enabled = false;
            lblTotal.Text = "0.00";
            dgvDetalle.DataSource = null;
            txtMetros.Visible = false;
            txtCosto.Enabled = false;
            txtObservacion.Text = string.Empty;
           
            
            txtCoeficiente.Text = string.Empty;
            cmbProveedor.SelectedIndex = 0;
            txtCoeficiente.Visible = false;
            txtCostoNeto.Enabled = false;
            txtCostoNeto.Text = string.Empty;
            lblSubtotal.Text = "0.00";
            lblIva.Text = "0.00";
            lblIngBrutos.Text = "0.00";
            lblMetros.Text = "0.00";

        }

        //LISTO
        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetTodos();
        }

        //LISTO
        private void CrearGrid()
        {
            DataGridViewComboBoxColumn entrega = new DataGridViewComboBoxColumn();
            entrega.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            entrega.HeaderText = "Lugar de Entrega";
            DataTable dtSucursales = new DataTable();
            dtSucursales = Sucursales.SucursalObtenerTodo();
            entrega.ValueMember = "sucid";
            entrega.DisplayMember = "sucnombre";
            entrega.DataSource = dtSucursales;
            entrega.Name = "sucid";

            DataGridViewButtonColumn Eliminar = new DataGridViewButtonColumn();
            Eliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Eliminar.HeaderText = "Eliminar";
            Eliminar.Name = "btnEliminar";
            Eliminar.Text = "Eliminar";
            Eliminar.UseColumnTextForButtonValue = true;



            DataGridViewCellStyle currencyCellStyle = new DataGridViewCellStyle();
            currencyCellStyle.Format = "C";
            dgvDetalle.Columns[4].DefaultCellStyle = currencyCellStyle;


            dgvDetalle.Columns.Add(entrega);
            dgvDetalle.Columns.Add(Eliminar);

            //dgvDetalle.AutoResizeColumns();
            //dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        //LISTO
        private void LimpiarControles()
        {
            txtCodigo.Text = string.Empty;
           
            txtProducto.Text = string.Empty;
            txtCosto.Text = string.Empty;
            lblMetros.Text = "0.00";
            lblTotal.Text = "0.00";
          
            txtCostoNeto.Text = string.Empty;
        }

        //LISTO
        private void ObtenerBonificacionesProducto(int prdid)
        {   
         
            try
            {
                List<BonificacionProducto> bonificacionproducto = BonificacionesProducto.GetPorProducto(prdid);
                if (bonificacionproducto.Count > 0)
                {
                    foreach (BonificacionProducto fila in bonificacionproducto)
                    {
                       
                    }
                }
                else
                {
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //LISTO
        private void frmNuevaOrdenCompra_Load(object sender, EventArgs e)
        {
            obtenerdatos();

            ProgressBar1.Visible = false;
           
            CargarComboBoxProveedor();

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
           
            List<Producto> list = Productos.GetTodosConsulta();
            if (list.Count > 0)
            {
              

                AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
                foreach (Producto row in list)
                {
                    stringCol.Add(Convert.ToString(row.prddenominacion));
                }

              
                LimpiarControles();
            }


            if (tipoMovimiento == "NUEVO")
            {               
                IniciarControles();
                CrearGrid();             
            }
            else
            {                
                IniciarControlesModificar();
                CrearGrid();               
                LimpiarControles();
                BuscarDatosOrdenCompra(orden_id);
            }

        }

        //LISTO
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //LISTO
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            txtCodigo.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtProducto.Text = string.Empty;
         
            txtCostoNeto.Text = string.Empty;
            errorProvider.Clear();

            dlgProducto dlg = new dlgProducto(Convert.ToInt32(cmbProveedor.SelectedValue));
            dlg.Text = "PRODUCTOS - LISTADO DE PRODUCTOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.prdid != 0)
            {
                txtid.Text = dlg.prdid.ToString();
                txtCodigo.Text = dlg.prdcodigo.ToString();
               
            }
        }

        //LISTO
        private Double CalcularBonificaciones(Producto producto)
        {
            
            double total = Convert.ToDouble(txtCosto.Text);
            List<BonificacionProducto> list = BonificacionesProducto.GetPorProducto(producto.prdid);
            if (list.Count > 0)
            {
                foreach (BonificacionProducto fila in list)
                {
                    total = Math.Round(total * Convert.ToDouble(fila.bonificacion.bondescuento),2);
                   
                }               
            }
            else
            {
                txtCostoNeto.Text = txtCosto.Text;
                txtCoeficiente.Text = "1.00";
               
            }

            return total;
        }

        private void ObtenerCostoProducto(Producto producto)
        {
            try
            {
                ListaPrecioProducto listaproducto = ListasPrecioProducto.GetProductoPrecioVigente(producto);
                if (listaproducto != null)
                {
                    txtCosto.Text = listaproducto.listaprecioproducto_costobruto.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //LISTO
        private void ObtenerProducto(int prdid)
        {
            Producto producto = Productos.GetPorId(prdid);
                       
            if (producto != null)
            {
                if (producto.proveedor.proid == Convert.ToInt32(cmbProveedor.SelectedValue))
                {               
                    txtProducto.Text = producto.prddenominacion;

                    ObtenerCostoProducto(producto);

                    //txtCosto.Text = producto.prdcosto.ToString();
                    txtCodigo.Text = producto.prdcodigo;
                    txtMetros.Text = producto.prdmetros.ToString();
                    //txtCoeficiente.Text = (CalcularBonificaciones(producto).ToString());
                    txtCostoNeto.Text = (CalcularBonificaciones(producto).ToString());         


                }
            }
            else
            {
                
                errorProvider.SetError(txtProducto, "El producto no existe registrado en el sistema.");
                txtProducto.Focus();
            }
        }
        
        //LISTO
        private void LimpiarControlesProducto()
        {
            txtCantidad.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtid.Text = string.Empty;
           
            txtCostoNeto.Text = string.Empty;
            txtCodigo.Focus();
        }

        //LISTO
        private bool ValidarDatosProducto()
        {
            bool result = true;

            errorProvider.Clear();

            if (String.IsNullOrEmpty(txtCodigo.Text))
            {
                errorProvider.SetError(txtCodigo, "Debe completar el campo código.");
                result = false;
            }

            if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                errorProvider.SetError(txtCantidad, "Debe completar el campo cantidad.");
                result = false;
            }

            if (String.IsNullOrEmpty(txtCosto.Text))
            {
                errorProvider.SetError(txtCosto, "Debe completar el campo costo.");
                result = false;
            }

            if (String.IsNullOrEmpty(txtCostoNeto.Text))
            {
                errorProvider.SetError(txtCostoNeto, "Debe completar el campo costo neto.");
                result = false;
            }

            return result;
        }
       
        //REVISAR
        private void CalcularTotal()
        {
            Double ingBrutos = Proveedores.GetIngBrutosPorId(Convert.ToInt32(cmbProveedor.SelectedValue));
            lblSubtotal.Text = string.Empty;
            decimal total = 0;
            foreach (DataGridViewRow dr in dgvDetalle.Rows)
            {
                total = total + Convert.ToDecimal(dr.Cells[6].Value);

            }

            lblSubtotal.Text = total.ToString();
            Double iva = 1.21;
            lblIva.Text = Math.Round(((Convert.ToDouble(lblSubtotal.Text) * iva) - Convert.ToDouble(lblSubtotal.Text)), 2).ToString();
            if (ingBrutos != 1)
            {
                lblIngBrutos.Text = Math.Round((Convert.ToDouble(lblSubtotal.Text) * ingBrutos) - Convert.ToDouble(lblSubtotal.Text), 2).ToString();
            }
            else
            {
                lblIngBrutos.Text = "0.00";
            }
            lblTotal.Text = (Convert.ToDouble(lblSubtotal.Text) + Convert.ToDouble(lblIva.Text) + Convert.ToDouble(lblIngBrutos.Text)).ToString(); ;

        }

        //LISTO
        private void CalcularMetros()
        {
            lblMetros.Text = string.Empty;
            decimal metros = 0;
            foreach (DataGridViewRow dr in dgvDetalle.Rows)
            {
                metros = metros + Convert.ToDecimal(dr.Cells["metros"].Value);

            }
            lblMetros.Text = metros.ToString();
        }

        //LISTO
        private Boolean ValidarDatos()
        {
            bool result = true;
            bool res = true;

            if (dgvDetalle.Rows.Count == 0)
            {
                errorProvider.SetError(btnAgregar, "Debe seleccionar al menos un producto.");
                result = false;
            }

            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow dr in dgvDetalle.Rows)
                {
                    if (Convert.ToInt32(dr.Cells[9].Value) <= 0)
                    {
                        res = false;
                        break;
                    }
                }
                if (res != true)
                {
                    errorProvider.SetError(dgvDetalle, "Debe seleccionar la sucursal de entrega.");
                    result = false;
                }
            }

            return result;
        }

        //LISTO
        private void InsertarOrdenCompra()
        {
            try
            {
                // inserto la orden de compra
                OrdenCompra ordencompra = new OrdenCompra();
                ordencompra.estid = 1;
                ordencompra.odcfecha = dtpFecha.Value;
                ordencompra.odcimporte = Convert.ToDecimal(lblSubtotal.Text);
                ordencompra.proid = Convert.ToInt32(cmbProveedor.SelectedValue);
                ordencompra.odcobservacion = txtObservacion.Text;
                ordencompra.Detalle = listado;
                ordencompra = OrdenesCompra.Create(ordencompra);
                if (ordencompra != null)
                {
                    ordencompra = OrdenesCompra.GetDatosPorId(ordencompra);
                   
                    MessageBox.Show("La orden de compra se registro con el número: " + ordencompra.odcnumero, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //CREO EL REPORTE
                    //DataTable dt = new DataTable();
                    //dt.Clear();
                    //dt = OrdenesCompraDetalle.GetOrdencompraDetalleDatosPodId(ordencompra.odcid);

                    //ReportViewer  rpt = new ReportViewer();
                    //rpt.Clear();
                    //rpt.LocalReport.DataSources.Clear();
                    //rpt.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    //rpt.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\_reporteOrdenCompra.rdl";
                    //rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                    
                    DialogResult result = MessageBox.Show("Desea enviar la orden de compra por email automaticamente?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        ProgressBar1.Visible = true;
                     
                        ProgressBar1.Style = ProgressBarStyle.Marquee;
                        ProgressBar1.MarqueeAnimationSpeed = 100;
                      

                        backgroundWorker1.RunWorkerAsync(ordencompra);
                        ////LO EXPORTO A PDF
                        //string pathadjunto = Utils.GenerarPdf.ExportReportViewer2Pdf(rpt, ordencompra);

                        ////ENVIO EL EMAIL
                        //Utils.Email.EnviarOrdenEmail(ordencompra, pathadjunto);

                        //MessageBox.Show("La orden de compra " + ordencompra.odcnumero + " fue enviada por email exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dgvDetalle.Rows.Clear();
                        IniciarControles();
                        LimpiarControles();

                        //genero el pdf
                        string path = GenerarPdf(ordencompra);

                        frmReporteOrdenCompra frm = new frmReporteOrdenCompra(ordencompra.odcid);
                        frm.MdiParent = this.MdiParent;
                        frm.Text = "REPORTE DE ORDEN DE COMPRA N° " + ordencompra.odcnumero;
                        frm.Show();
                    }
                    
                    dgvDetalle.Rows.Clear();
                    IniciarControles();
                    LimpiarControles();

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //LISTO
        private void Actualizar()
        {
            try
            {
                //actualizo la orden de compra
                OrdenCompra ordencompra = new OrdenCompra();
                ordencompra.odcid = Convert.ToInt32(txtIdOrden.Text);
                ordencompra.estid = 1;
                ordencompra.odcfecha = dtpFecha.Value;
                ordencompra.odcimporte = Convert.ToDecimal(lblSubtotal.Text);
                ordencompra.proid = Convert.ToInt32(cmbProveedor.SelectedValue);
                ordencompra.odcobservacion = txtObservacion.Text;
                ordencompra.Detalle = listado;


                bool resultado = OrdenesCompra.Update(ordencompra);
                if (resultado != false)
                {
                    MessageBox.Show("La orden de compra se modifico correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniciarControlesModificar();
                    dgvDetalle.Rows.Clear();
                    LimpiarControles();
                    txtOrden.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //LISTO
        private void frmNuevaOrdenCompra_Resize(object sender, EventArgs e)
        {
            
            //groupBox2.Width = this.Width - 40;
          
            //lblTotal.Location = new Point(this.Width - 130, this.Height - 170);
            //label5.Location = new Point(this.Width - 180, this.Height - 165);
            ////lblMetros.Location = new Point(this.Width - 130, this.Height - 140);
            //label9.Location = new Point(this.Width - 190, this.Height - 135);

        }

        //LISTO
        private void PersonalizarGridModificar()
        {
            dgvDetalle.Columns[0].Visible = false;
            dgvDetalle.Columns[1].Visible = false;
            dgvDetalle.Columns[2].HeaderText = "N° ORDEN COMPRA";
            dgvDetalle.Columns[3].HeaderText = "FECHA";
            dgvDetalle.Columns[4].HeaderText = "PROVEEDOR";
            dgvDetalle.Columns[5].Visible = false;
            dgvDetalle.Columns[6].Visible = false;
            dgvDetalle.Columns[7].Visible = false;
            dgvDetalle.Columns[8].Visible = false;
            dgvDetalle.Columns[9].HeaderText = "CANTIDAD";
            dgvDetalle.Columns[10].HeaderText = "CÓDIGO";
            dgvDetalle.Columns[11].HeaderText = "PRODUCTO";
            dgvDetalle.Columns[12].HeaderText = "IMPORTE UNIT";
            dgvDetalle.Columns[13].Visible = false;
            dgvDetalle.Columns[14].HeaderText = "SUCURSAL";
            dgvDetalle.Columns[12].DefaultCellStyle.Format = "c";

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        //LISTO
        private void BuscarDatosOrdenCompra(int odcid)
        {
            OrdenCompra ordencompra = new OrdenCompra();
            ordencompra.odcid = odcid;

            ordencompra = OrdenesCompra.GetDatosPorId(ordencompra);
            if (ordencompra != null)
            {
                
                cmbProveedor.Enabled = false;
                cmbProveedor.Text = ordencompra.proveedor.pronombre;
                dtpFecha.Value = ordencompra.odcfecha;
                lblTotal.Text = ordencompra.odcimporte.ToString();
                txtObservacion.Text = ordencompra.odcobservacion;

                ordencompra.Detalle = OrdenesCompraDetalle.GetPorIdOrden(ordencompra);

                if (ordencompra.Detalle.Count > 0)
                {
 
                    foreach(OrdenCompraDetalle fila in ordencompra.Detalle)
                    {
                        dgvDetalle.Rows.Add(fila.ocdid, fila.ocdid, fila.producto.prdcodigo, fila.producto.prddenominacion, fila.ocdimporteunit, fila.ocdcantidad, (fila.ocdcantidad * fila.ocdimporteunit), fila.prdid, (fila.ocdcantidad * fila.producto.prdmetros), fila.sucid);
                    }
                    CalcularTotal();
                    CalcularMetros();
                }
         
            }

        }

        //LISTO
        private void dgvDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4) //Column ColB
            {
                if (e.Value != null)
                {
                    e.CellStyle.Format = "C";
                }
            }
        }
       
        //LISTO
        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tipoMovimiento == "NUEVO")
            //{
            //      DialogResult result = MessageBox.Show("Va a cambiar el proveedor, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //      if (result == System.Windows.Forms.DialogResult.Yes)
            //      {
            //          dgvDetalle.Rows.Clear();
            //      }
            //      else
            //      {
            //          cmbProveedor.SelectedIndex = indexproveedor;
            //      }
            //}
        }

        private void btnBuscarOrdenCompra_Click(object sender, EventArgs e)
        {
            dlgOrdenCompra dlg = new dlgOrdenCompra();
            dlg.Text = "ORDEN COMPRA - LISTADO DE ORDENES DE COMPRA";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.odcid != 0)
            {

                txtIdOrden.Text = dlg.odcid.ToString();
                txtOrden.Text = dlg.odcnumero.ToString();

            }
        }

        private void txtCodigo_TextChanged_1(object sender, EventArgs e)
        {
            if (txtCodigo.Text != string.Empty && string.IsNullOrEmpty(txtid.Text) && txtCodigo.TextLength == 6)
            {
                ObtenerProducto(Convert.ToInt32(txtCodigo.Text));
                ObtenerBonificacionesProducto(Convert.ToInt32(txtCodigo.Text));
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            errorProvider.Clear();
            decimal metros = 0;

            if (ValidarDatosProducto() == true)
            {
                metros = 0;
                metros = Math.Round((Convert.ToDecimal(txtMetros.Text) * Convert.ToInt32(txtCantidad.Text)), 2);

                dgvDetalle.Rows.Add(txtIdOrden.Text, 0, txtCodigo.Text, txtProducto.Text, Convert.ToDecimal(txtCostoNeto.Text), txtCantidad.Text, (Convert.ToDecimal(txtCostoNeto.Text) * Convert.ToInt32(txtCantidad.Text)), txtid.Text, metros);

                LimpiarControlesProducto();
                
                ckbCosto.CheckState = CheckState.Unchecked;

                indexproveedor = cmbProveedor.SelectedIndex;

                CalcularTotal();
                CalcularMetros();
            }
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (tipoMovimiento == "NUEVO")
            {

                if (ValidarDatos() == true)
                {

                    DialogResult result = MessageBox.Show("Se va a generar una orden de compra, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        listado.Clear();
                        foreach (DataGridViewRow dr in dgvDetalle.Rows)
                        {
                            OrdenCompraDetalle detalle = new OrdenCompraDetalle();
                            detalle.ecdid = 1;
                            detalle.ocdcantidad = Convert.ToInt32(dr.Cells["ocdcantidad"].Value);
                            detalle.ocdimporteunit = Convert.ToDecimal(dr.Cells["odcimporteunit"].Value);
                            detalle.prdid = Convert.ToInt32(dr.Cells["prdid"].Value);
                            detalle.sucid = Convert.ToInt32(dr.Cells["sucid"].Value);
                            listado.Add(detalle);
                        }

                        InsertarOrdenCompra();

                    }
                }
            }
            else
            {


                DialogResult resul = MessageBox.Show("Se va a modificar la orden de compra, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resul == System.Windows.Forms.DialogResult.Yes)
                {
                    if (ValidarDatos() == true)
                    {
                        listado.Clear();
                        foreach (DataGridViewRow dr in dgvDetalle.Rows)
                        {
                            OrdenCompraDetalle detalle = new OrdenCompraDetalle();
                            detalle.ecdid = 1;
                            detalle.ocdcantidad = Convert.ToInt32(dr.Cells["ocdcantidad"].Value);
                            detalle.ocdimporteunit = Convert.ToDecimal(dr.Cells["odcimporteunit"].Value);
                            if (String.IsNullOrEmpty(dr.Cells["ocdid"].Value.ToString()))
                            {
                                dr.Cells["ocdid"].Value = 0;
                            }
                            detalle.ocdid = Convert.ToInt32(dr.Cells["ocdid"].Value);
                            detalle.prdid = Convert.ToInt32(dr.Cells["prdid"].Value);
                            detalle.sucid = Convert.ToInt32(dr.Cells["sucid"].Value);
                            listado.Add(detalle);
                        }

                        Actualizar();

                    }

                }

            }
        }

        private void dgvDetalle_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (tipoMovimiento == "NUEVO")
            {
                if (dgvDetalle.Rows.Count > 0)
                {
                    if (dgvDetalle.Columns[e.ColumnIndex].Name == "btnEliminar")
                    {
                        int fila = dgvDetalle.CurrentRow.Index;
                        dgvDetalle.Rows.RemoveAt(fila);

                        txtCodigo.Focus();
                    }
                }

                CalcularTotal();
                CalcularMetros();
            }
            else
            {
                if (tipoMovimiento == "MODIFICAR")
                {
                    if (dgvDetalle.Columns[e.ColumnIndex].Name == "btnEliminar")
                    {
                        try
                        {
                            DataGridViewRow fil = dgvDetalle.CurrentRow;
                            int fila = dgvDetalle.CurrentRow.Index;

                            DialogResult result = MessageBox.Show("Se va a eliminar el producto del detalle, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (Convert.ToInt32(fil.Cells[1].Value) != 0)
                                {
                                    OrdenCompraDetalle ordencompradetalle = new OrdenCompraDetalle();
                                    ordencompradetalle.ocdid = Convert.ToInt32(fil.Cells["ocdid"].Value);

                                    OrdenCompraPendiente ordencomprapendiente = new OrdenCompraPendiente();
                                    ordencomprapendiente.odcid = Convert.ToInt32(txtIdOrden.Text);
                                    ordencomprapendiente.ocdcantidad = Convert.ToInt32(fil.Cells["ocdcantidad"].Value);
                                    ordencomprapendiente.prdid = Convert.ToInt32(fil.Cells["prdid"].Value);
                                    ordencomprapendiente.proid = Convert.ToInt32(cmbProveedor.SelectedValue);
                                    ordencomprapendiente.sucid = Convert.ToInt32(fil.Cells["sucid"].Value);

                                    try
                                    {
                                        bool resultado = OrdenesCompraDetalle.DeleteProducto(ordencompradetalle, ordencomprapendiente);

                                        if (resultado == true)
                                        {
                                            dgvDetalle.Rows.RemoveAt(fila);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ocurrio un error al eliminar de la lista el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                {
                                    dgvDetalle.Rows.RemoveAt(fila);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    CalcularTotal();
                    CalcularMetros();
                }
            }
        }

        private void ckbCosto_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ckbCosto.Checked == true)
            {
                txtCostoNeto.Enabled = true;
            }
            else
            {
                txtCostoNeto.Enabled = false;
            }
        }

        private void cmbProducto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            string str = e.KeyChar.ToString().ToUpper();
            char[] ch = str.ToCharArray();
            e.KeyChar = ch[0];
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {

                errorProvider.SetError(txtCosto, "Solo se permiten números en el campo costo.");
                e.Handled = true;
                txtCosto.Focus();
                return;
            }
        }

        private void txtid_TextChanged_1(object sender, EventArgs e)
        {
            if (txtid.Text != string.Empty)
            {
                ObtenerProducto(Convert.ToInt32(txtid.Text));
            }
        }

        private void txtIdOrden_TextChanged_1(object sender, EventArgs e)
        {
            dgvDetalle.Rows.Clear();
            if (txtIdOrden.Text != string.Empty)
            {

                BuscarDatosOrdenCompra(Convert.ToInt32(txtIdOrden.Text));

            }
        }

        private void txtCostoNeto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            errorProvider.Clear();
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || char.IsControl(e.KeyChar)
                )
            {

                e.Handled = false;
            }

            else
            {
                errorProvider.SetError(ckbCosto, "Solo se permiten números en el campo costo neto.");
                e.Handled = true;
            }

        }

        private void txtCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            errorProvider.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                errorProvider.SetError(txtCantidad, "Solo se permiten números en el campo cantidad.");
                e.Handled = true;
                txtCantidad.Focus();
                return;
            }
        }

        private void txtCodigo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            errorProvider.Clear();
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || char.IsControl(e.KeyChar)
                )
            {

                e.Handled = false;
            }

            else
            {
                errorProvider.SetError(btnBuscar, "Solo se permiten números en el campo código.");
                e.Handled = true;
            }
        }

        private void cmbProveedor_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if (tipoMovimiento == "NUEVO")
            {
                DialogResult result = MessageBox.Show("Va a cambiar el proveedor, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    dgvDetalle.Rows.Clear();
                }
                else
                {
                    cmbProveedor.SelectedIndex = indexproveedor;
                }
            }
        }

        private void cmbProducto_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtProducto.Text = string.Empty;
          
            txtCostoNeto.Text = string.Empty;
            errorProvider.Clear();

            dlgProducto dlg = new dlgProducto(Convert.ToInt32(cmbProveedor.SelectedValue));
            dlg.Text = "PRODUCTOS - LISTADO DE PRODUCTOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.prdid != 0)
            {
                txtid.Text = dlg.prdid.ToString();
                txtCodigo.Text = dlg.prdcodigo.ToString();

            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (tipoMovimiento == "NUEVO")
            {

                if (ValidarDatos() == true)
                {

                    DialogResult result = MessageBox.Show("Se va a generar una orden de compra, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        listado.Clear();
                        foreach (DataGridViewRow dr in dgvDetalle.Rows)
                        {
                            OrdenCompraDetalle detalle = new OrdenCompraDetalle();
                            detalle.ecdid = 1;
                            detalle.ocdcantidad = Convert.ToInt32(dr.Cells["ocdcantidad"].Value);
                            detalle.ocdimporteunit = Convert.ToDecimal(dr.Cells["odcimporteunit"].Value);
                            detalle.prdid = Convert.ToInt32(dr.Cells["prdid"].Value);
                            detalle.sucid = Convert.ToInt32(dr.Cells["sucid"].Value);
                            listado.Add(detalle);
                        }

                        InsertarOrdenCompra();

                    }
                }
            }
            else
            {

                DialogResult resul = MessageBox.Show("Se va a modificar la orden de compra, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resul == System.Windows.Forms.DialogResult.Yes)
                {
                    if (ValidarDatos() == true)
                    {
                        listado.Clear();
                        foreach (DataGridViewRow dr in dgvDetalle.Rows)
                        {
                            OrdenCompraDetalle detalle = new OrdenCompraDetalle();
                            detalle.ecdid = 1;
                            detalle.ocdcantidad = Convert.ToInt32(dr.Cells["ocdcantidad"].Value);
                            detalle.ocdimporteunit = Convert.ToDecimal(dr.Cells["odcimporteunit"].Value);
                            if (String.IsNullOrEmpty(dr.Cells["ocdid"].Value.ToString()))
                            {
                                dr.Cells["ocdid"].Value = 0;
                            }
                            detalle.ocdid = Convert.ToInt32(dr.Cells["ocdid"].Value);
                            detalle.prdid = Convert.ToInt32(dr.Cells["prdid"].Value);
                            detalle.sucid = Convert.ToInt32(dr.Cells["sucid"].Value);
                            listado.Add(detalle);
                        }

                        Actualizar();

                    }

                }

            }
        }

        private void btnCancelar_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            OrdenCompra orden = new OrdenCompra();
            orden = (OrdenCompra)e.Argument;

            //GENERO EL PDF
            string pathadjunto = GenerarPdf(orden);

            //ENVIO EL EMAIL
            Utils.Email.EnviarOrdenEmail(orden, pathadjunto);

            e.Result = orden;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OrdenCompra or =  e.Result as OrdenCompra;
            
            MessageBox.Show("La orden de compra " + or.odcnumero + " fue enviada por email exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProgressBar1.MarqueeAnimationSpeed = 0;
            ProgressBar1.Visible = false;
           
            //abro el formulario de reporte

            frmReporteOrdenCompra frm = new frmReporteOrdenCompra(or.odcid);
            frm.MdiParent = this.MdiParent;
            frm.Text = "REPORTE DE ORDEN DE COMPRA N° " + or.odcnumero;
            frm.Show();
        }


        private static String GenerarPdf(OrdenCompra orden)
        {
            DataTable dt = new DataTable();
            dt.Clear();

            dt = OrdenesCompraDetalle.GetOrdencompraDetalleDatosPodId(orden.odcid);
            //CREO EL REPORTE
            ReportViewer rpt = new ReportViewer();
            rpt.Clear();
            rpt.LocalReport.DataSources.Clear();
            rpt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            rpt.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\_reporteOrdenCompra.rdl";
            rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));

            //GENERO EL PDF
            string pathadjunto = Utils.GenerarPdf.ExportReportViewer2Pdf(rpt, orden);

            return pathadjunto;
        }

        private void obtenerdatos()
        {
            IList<Producto> datos = Productos.FindAll();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



    }
}
