using Entidad;
using Microsoft.Reporting.WinForms;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmOrdenCompraTest : Form
    {
        private int orden_id;
        private string operacion;
        private List<OrdenCompraDetalle> _detalleL = new List<OrdenCompraDetalle>();
        private int indexproveedor;


        public frmOrdenCompraTest()
        {
            InitializeComponent();
        }

        public frmOrdenCompraTest(string _operacion, int _orden_id)
        {
            orden_id = _orden_id;
            operacion = _operacion;
            InitializeComponent();
        }

        private void IniciarControles()
        {
            Bitmap img = new Bitmap(Properties.Resources.search, new Size(16, 16));
            btnBuscar.Image = img;

            txtOrden.Visible = false;
            txtIdOrden.Visible = false;
            txtNumero.Visible = false;
            
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

            dgvDetalle.Columns[0].ReadOnly = true;
            dgvDetalle.Columns[1].ReadOnly = true;
            dgvDetalle.Columns[3].ReadOnly = true;
            dgvDetalle.Columns[6].ReadOnly = true;
            dgvDetalle.Columns[7].ReadOnly = true;

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgvDetalle.RowCount = 1;
        }

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
            txtNumero.Visible = false;

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

        private void LimpiarControles()
        {
            txtCodigo.Text = string.Empty;

            txtProducto.Text = string.Empty;
            txtCosto.Text = string.Empty;
            lblMetros.Text = "0.00";
            lblTotal.Text = "0.00";
            lblIngBrutos.Text = "0.00";
            lblIva.Text = "0.00";
            lblSubtotal.Text = "0.00";
            
            txtCostoNeto.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            dgvDetalle.Rows.Clear();

        }

        private void GetProveedores()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.FindAll();
        }

        private void GetDepositos()
        {
            deposito_id.ValueMember = "sucid";
            deposito_id.DisplayMember = "sucnombre";
            deposito_id.DataPropertyName = "sucid";
            deposito_id.DataSource = Sucursales.GetTodos();            
        }

        private void frmOrdenCompraTest_Load(object sender, EventArgs e)
        {


            if(string.IsNullOrEmpty(operacion))
            {
                GetDepositos();
                GetProveedores();
                IniciarControles();
            }
            else
            {
                GetDepositos();
                GetProveedores();
                IniciarControlesModificar();

                FindOrdenCompraById(orden_id);

                CalcularMetros();
                CalcularTotal();
            }

            
            
        }

        private void AgregarFilaDetalle(OrdenCompraDetalle fila)
        {
            _detalleL.Add(fila);
        }

        private void EliminarFilaDetalle(int fila)
        {
            _detalleL.RemoveAt(fila);
        }

        private void ModificarFilaDetalle(int pos, OrdenCompraDetalle fila)
        {
            _detalleL[pos] = fila;
        }

        private void FindOrdenCompraById(int orden_id)
        {
            OrdenCompra orden = OrdenesCompra.FindById(orden_id);
            if (orden != null)
            {
                cmbProveedor.Text = orden.proveedor.pronombre;
                dtpFecha.Value = orden.fecha;
                txtObservacion.Text = orden.observacion;
                lblSubtotal.Text = orden.importe.ToString();

                orden.Detalle = OrdenesCompra.FindDetalleByIdOrden(orden_id);

                dgvDetalle.Rows.Clear();
                foreach (var fila in orden.Detalle)
                {
                    AgregarFilaDetalle(fila);

                    dgvDetalle.Rows.Add(fila.id, fila.producto_id, fila.producto.prdcodigo,
                        fila.producto.prddenominacion, fila.importe_unitario, fila.cantidad,
                        fila.cantidad * fila.importe_unitario, Math.Round(fila.producto.prdmetros, 2), Math.Round((fila.producto.prdmetros * fila.cantidad), 2), fila.sucursal_id);
                }
            }
        }

        private void dgvDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (e.FormattedValue.ToString().Length <= 6)
                {
                    if (EsNumero(e.FormattedValue.ToString()) == true)
                    {
                        
                        dgvDetalle.Rows[e.RowIndex].ErrorText = string.Empty;
                        e.Cancel = false;
                    }
                    else
                    {
                        dgvDetalle.Rows[e.RowIndex].ErrorText = "Solo se permiten numeros en la celda Código.";
                        e.Cancel = true;
                    }
                }
                else
                {
                    dgvDetalle.Rows[e.RowIndex].ErrorText = "El Código debe ser de 6 caracteres.";
                    e.Cancel = true;
                }
            }
               
            if(e.ColumnIndex == 5)
            {
                if(EsNumero(e.FormattedValue.ToString()) == true)
                {

                    if (Convert.ToInt32(e.FormattedValue) > 0)
                    {
                        dgvDetalle.Rows[e.RowIndex].ErrorText = string.Empty;
                        e.Cancel = false;
                    }
                    else
                    {
                        dgvDetalle.Rows[e.RowIndex].ErrorText = "La Cantidad no puede ser 0.";
                        e.Cancel = true;
                    }
                }
                else
                {
                    dgvDetalle.Rows[e.RowIndex].ErrorText = "Solo se permiten numeros en el campo Cantidad.";
                    e.Cancel = true;
                }
            }

            if(e.ColumnIndex.Equals(4))
            {
                string numero = e.FormattedValue.ToString().Replace('$' , ' ');

                if(EsDecimal(numero) == true)
                {
                    dgvDetalle.Rows[e.RowIndex].ErrorText = string.Empty;
                    e.Cancel = false;
                }
                else
                {
                    dgvDetalle.Rows[e.RowIndex].ErrorText = "Debe ingresar un Importe.";
                    e.Cancel = true;
                }
            }
        }
        
        private Boolean EsNumero(string numero)
        {
            try
            {
                int resultado = int.Parse(numero);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Boolean EsDecimal(string numero)
        {
            try
            {
                decimal resultado = decimal.Parse(numero);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Producto FindProductoByCodigo(string codigo)
        {
            Producto producto = Productos.FindByCodigo(codigo);
            return producto;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex.Equals(2))
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress += new KeyPressEventHandler(Codigo_KeyPress);
            }

            if(dgvDetalle.CurrentCell.ColumnIndex.Equals(5))
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress += new KeyPressEventHandler(Cantidad_KeyPress);
            }

            if(dgvDetalle.CurrentCell.ColumnIndex.Equals(4))
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress += new KeyPressEventHandler(Costo_KeyPress);
            }
        }

        private void Costo_KeyPress(object sender, KeyPressEventArgs e)
        {            
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || char.IsControl(e.KeyChar)
                )           
                 e.Handled = false;           
            else
                e.Handled = true;            
        }

        private void Codigo_KeyPress(object sender, KeyPressEventArgs e)
        {          
            if(dgvDetalle.CurrentCell.ColumnIndex == 2)
            {
                TextBox tx = (TextBox)sender;
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {                    
                    e.Handled = true;
                    return;
                }
            }     
        }

        private void Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 5)
            {
                TextBox tx = (TextBox)sender;
                CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void frmOrdenCompraTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                dgvDetalle.Rows.Add();
            }
        }

        private Boolean ValidarForm()
        {
            bool resultado = true;
            bool sucursal = true;
            error.Clear();

            if (dgvDetalle.Rows.Count == 0)
            {
                resultado = false;
                error.SetError(btnBuscar, "Debe agregar Productos al detalle.");
                return resultado;
            }

            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow dr in dgvDetalle.Rows)
                {
                    if (Convert.ToInt32(dr.Cells[9].Value) <= 0)
                    {
                        sucursal = false;
                        break;
                    }
                }
                if (sucursal != true)
                {
                    error.SetError(dgvDetalle, "Debe seleccionar la sucursal de entrega.");
                    resultado = false;
                }
            }

            return resultado;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtProducto.Text = string.Empty;

            txtCostoNeto.Text = string.Empty;
            error.Clear();

            dlgProducto dlg = new dlgProducto(Convert.ToInt32(cmbProveedor.SelectedValue));
            dlg.Text = "Productos - Selector de Producto";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.prdid != 0)
            {
                txtid.Text = dlg.prdid.ToString();
                txtCodigo.Text = dlg.prdcodigo.ToString();

            }
        }
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

            error.Clear();

            if (String.IsNullOrEmpty(txtCodigo.Text))
            {
                error.SetError(txtCodigo, "Debe completar el campo código.");
                result = false;
            }

            if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                error.SetError(txtCantidad, "Debe completar el campo cantidad.");
                result = false;
            }

            if (String.IsNullOrEmpty(txtCosto.Text))
            {
                error.SetError(txtCosto, "Debe completar el campo costo.");
                result = false;
            }

            if (String.IsNullOrEmpty(txtCostoNeto.Text))
            {
                error.SetError(txtCostoNeto, "Debe completar el campo costo neto.");
                result = false;
            }

            return result;
        }

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
       
        private void CalcularMetros()
        {
            lblMetros.Text = string.Empty;
            decimal metros = 0;
            foreach (DataGridViewRow dr in dgvDetalle.Rows)
            {
                metros = Math.Round(metros + Convert.ToDecimal(dr.Cells["metros3_totales"].Value), 2);

            }

            lblMetros.Text = metros.ToString();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != string.Empty && string.IsNullOrEmpty(txtid.Text) && txtCodigo.TextLength == 6)
            {
                Producto producto = FindProductoByCodigo(txtCodigo.Text);
                txtProducto.Text = producto.prddenominacion;
                txtCostoNeto.Text = producto.prdcosto.ToString();
                txtMetros.Text = producto.prdmetros.ToString();
                txtCosto.Text = producto.prdcosto.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            error.Clear();
            decimal metros = 0;

            if (ValidarDatosProducto() == true)
            {
                metros = 0;
                metros = Math.Round((Convert.ToDecimal(txtMetros.Text) * Convert.ToInt32(txtCantidad.Text)), 2);

                dgvDetalle.Rows.Add(0, txtid.Text, txtCodigo.Text, txtProducto.Text, Convert.ToDecimal(txtCostoNeto.Text), txtCantidad.Text, (Convert.ToDecimal(txtCostoNeto.Text) * Convert.ToInt32(txtCantidad.Text)), metros);

                LimpiarControlesProducto();

                ckbCosto.CheckState = CheckState.Unchecked;

                indexproveedor = cmbProveedor.SelectedIndex;

                CalcularTotal();
                CalcularMetros();
            }
        }

        private void cmbProveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(operacion))
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

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (txtid.Text != string.Empty)
            {
                Producto producto = FindProductoById(Convert.ToInt32(txtid.Text));
                txtProducto.Text = producto.prddenominacion;
                txtCostoNeto.Text = producto.prdcosto.ToString();
                txtMetros.Text = producto.prdmetros.ToString();
                txtCosto.Text = producto.prdcosto.ToString();

                txtCostoNeto.Text = FindPrecioUltimaLista().ToString();
                txtCosto.Text = txtCostoNeto.Text;
            }
        }

        private Producto FindProductoById(int producto_id)
        {
            Producto producto = Productos.FindById(producto_id);
            return producto;
        }


        private double FindPrecioUltimaLista()
        {
            double importe = 0;

            try
            {
                var listaprecio_activa = ListasPrecio.FindUltimaActivaByProveedor(Convert.ToInt32(cmbProveedor.SelectedValue));

                importe = ListasPrecioProducto.FindImporteProducto(listaprecio_activa.listaprecio_id, Convert.ToInt32(txtid.Text));


            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return importe;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(ValidarForm() == true)
            {
                if(string.IsNullOrEmpty(operacion))
                {
                    DialogResult result = MessageBox.Show("Se va a generar una Orden de Compra, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        RegistrarOrden();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Se va a modificar la Orden de Compra, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        ModificarOrden();
                    }
                }
            }
        }


        private void ModificarOrden()
        {
            OrdenCompra ordencompra = new OrdenCompra();
            ordencompra = OrdenesCompra.FindById(orden_id);
            ordencompra.estado_id = 1;
            ordencompra.fecha = dtpFecha.Value;
            ordencompra.importe = Convert.ToDecimal(lblSubtotal.Text);
            ordencompra.proveedor_id = Convert.ToInt32(cmbProveedor.SelectedValue);
            ordencompra.observacion = txtObservacion.Text;

            CrearLista();
            ordencompra.Detalle = _detalleL;

            int resultado = OrdenesCompra.Modificar(ordencompra);
            if(resultado > 0)
            {
                MessageBox.Show("Los datos se modificaron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al modificar los datos. Intente Nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrarOrden()
        {
            OrdenCompra ordencompra = new OrdenCompra();
            ordencompra.estado_id = 1;
            ordencompra.fecha = dtpFecha.Value;
            ordencompra.importe = Convert.ToDecimal(lblSubtotal.Text);
            ordencompra.proveedor_id = Convert.ToInt32(cmbProveedor.SelectedValue);
            ordencompra.observacion = txtObservacion.Text;
            ordencompra.activo = 1;

            CrearLista();
            ordencompra.Detalle = _detalleL;

            int resultado = OrdenesCompra.Agregar(ordencompra);
            if(resultado > 0)
            {
                MessageBox.Show("Los datos se registraron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                DialogResult result = MessageBox.Show("Desea enviar la orden de compra por email automaticamente?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    ProgressBar1.Visible = true;

                    ProgressBar1.Style = ProgressBarStyle.Marquee;
                    ProgressBar1.MarqueeAnimationSpeed = 100;

                    backgroundWorker1.RunWorkerAsync(resultado);
                    
                }
                else
                {
                    dgvDetalle.Rows.Clear();
                    IniciarControles();
                    LimpiarControles();

                    //genero el pdf
                    string path = GenerarPdf(resultado);

                    frmReporteOrdenCompra frm = new frmReporteOrdenCompra(resultado);
                    frm.MdiParent = this.MdiParent;
                    frm.Text = "REPORTE DE ORDEN DE COMPRA N° " + ordencompra.numero;
                    frm.Show();
                }

            }
            else
            {
                MessageBox.Show("Ocurrio un error al registrar los datos. Intente Nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetalle_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex.Equals(2))
            {
                if (!string.IsNullOrEmpty(dgvDetalle.Rows[e.RowIndex].Cells[2].Value.ToString()))
                {
                    Producto producto = FindProductoByCodigo(dgvDetalle.Rows[e.RowIndex].Cells[2].Value.ToString());

                    if (producto != null)
                    {
                        dgvDetalle.Rows[e.RowIndex].Cells[1].Value = producto.prdid;
                        dgvDetalle.Rows[e.RowIndex].Cells[3].Value = producto.prddenominacion;
                        dgvDetalle.Rows[e.RowIndex].Cells[4].Value = producto.prdcosto;
                        dgvDetalle.Rows[e.RowIndex].Cells[7].Value = Math.Round(producto.prdmetros, 2);

                        //Limpio las demas celdas que completare
                        dgvDetalle.Rows[e.RowIndex].Cells[5].Value = "0";
                        dgvDetalle.Rows[e.RowIndex].Cells[6].Value = "0.00";
                        dgvDetalle.Rows[e.RowIndex].Cells[8].Value = "0.00";

                    }
                }
            }

            if(e.ColumnIndex.Equals(5))
            {
                decimal costo = Convert.ToDecimal(dgvDetalle.Rows[e.RowIndex].Cells[4].Value);
                int cantidad = Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells[5].Value);
                decimal m3 = Convert.ToDecimal(dgvDetalle.Rows[e.RowIndex].Cells[7].Value);

                dgvDetalle.Rows[e.RowIndex].Cells[6].Value = Math.Round((costo * cantidad), 2);
                dgvDetalle.Rows[e.RowIndex].Cells[8].Value = Math.Round((m3 * cantidad), 2);
            }

            if(e.ColumnIndex.Equals(4))
            {
                decimal costo = Convert.ToDecimal(dgvDetalle.Rows[e.RowIndex].Cells[4].Value);
                int cantidad = Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells[5].Value);
                decimal m3 = Convert.ToDecimal(dgvDetalle.Rows[e.RowIndex].Cells[7].Value);

                dgvDetalle.Rows[e.RowIndex].Cells[6].Value = Math.Round((costo * cantidad), 2);
                dgvDetalle.Rows[e.RowIndex].Cells[8].Value = Math.Round((m3 * cantidad), 2);
            }

            CalcularTotal();
            CalcularMetros();
        }
        
        private void dgvDetalle_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            bool resultado = true;
            string error = string.Empty;


            if (dgvDetalle.Rows[e.RowIndex].Cells[1].Value == null)
            {
                resultado = false;
                error = "Debe seleccionar un Producto.";
                dgvDetalle.Rows[e.RowIndex].ErrorText = error;
            }

            if (!string.IsNullOrEmpty(dgvDetalle.Rows[e.RowIndex].Cells[2].Value.ToString()))
            {
                resultado = false;
                error = "Debe seleccionar un Producto.";
                dgvDetalle.Rows[e.RowIndex].ErrorText = error;
            }

            if (!string.IsNullOrEmpty(dgvDetalle.Rows[e.RowIndex].Cells[3].Value.ToString()))
            {
                resultado = false;
                error = "Debe seleccionar un Producto.";
                dgvDetalle.Rows[e.RowIndex].ErrorText = error;
            }

            if (!string.IsNullOrEmpty(dgvDetalle.Rows[e.RowIndex].Cells[4].Value.ToString()))
            {
                resultado = false;
                error = "Debe indicar el Costo del Producto.";
                dgvDetalle.Rows[e.RowIndex].ErrorText = error;
            }

            if (!string.IsNullOrEmpty(dgvDetalle.Rows[e.RowIndex].Cells[5].Value.ToString()))
            {
                resultado = false;
                error = "Debe indicar una Cantidad.";
                dgvDetalle.Rows[e.RowIndex].ErrorText = error;
            }

            if(Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells[5].Value) <= 0)
            {
                resultado = false;
                error = "Debe indicar una Cantidad. El valor ingresado, no es valido.";
                dgvDetalle.Rows[e.RowIndex].ErrorText = error;
                return;
            }

            if (!string.IsNullOrEmpty(dgvDetalle.Rows[e.RowIndex].Cells[6].Value.ToString()))
            {
                resultado = false;
                error = "Debe completar el Total.";
                dgvDetalle.Rows[e.RowIndex].ErrorText = error;
            }

            if (!string.IsNullOrEmpty(dgvDetalle.Rows[e.RowIndex].Cells[7].Value.ToString()))
            {
                resultado = false;
                error = "Debe indicar los m3 del Producto.";
                dgvDetalle.Rows[e.RowIndex].ErrorText = error;
            }

            //if (!string.IsNullOrEmpty(dgvDetalle.Rows[e.RowIndex].Cells[8].Value.ToString()))
            //{
            //    resultado = false;
            //    error = "Debe indicar los m3 Tot. del Producto.";
            //    dgvDetalle.Rows[e.RowIndex].ErrorText = error;
            //}

            if (dgvDetalle.Rows[e.RowIndex].Cells[9].Value == null)
            {
                resultado = false;
                error = "Debe indicar el Depósito de Destino.";
                dgvDetalle.Rows[e.RowIndex].ErrorText = error;
            }

            e.Cancel = resultado;
            dgvDetalle.Rows[e.RowIndex].ErrorText = error;
        }

        private void CrearLista()
        {
            _detalleL.Clear();
    
            foreach(DataGridViewRow fila in dgvDetalle.Rows)
            {
                
                OrdenCompraDetalle item = new OrdenCompraDetalle();
                item.id = Convert.ToInt32(fila.Cells[0].Value);
                item.producto_id = Convert.ToInt32(fila.Cells[1].Value);
                item.cantidad = Convert.ToInt32(fila.Cells[5].Value);
                item.importe_unitario = Convert.ToDecimal(fila.Cells[4].Value);
                item.sucursal_id = Convert.ToInt32(fila.Cells[9].Value);
                item.estado_id = 1;
                item.observacion = string.Empty;

                _detalleL.Add(item);
            }
        }

        private static String GenerarPdf(int orden_id)
        {
            DataTable dt = new DataTable();
            dt.Clear();

            dt = OrdenesCompraDetalle.GetOrdencompraDetalleDatosPodId(orden_id);
            //CREO EL REPORTE
            ReportViewer rpt = new ReportViewer();
            rpt.Clear();
            rpt.LocalReport.DataSources.Clear();
            rpt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            rpt.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\ordencompra.rdl";
            rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));

            //GENERO EL PDF
            string pathadjunto = Utils.GenerarPdf.ExportReportViewer2Pdf(rpt, orden_id);

            return pathadjunto;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int orden_id = (int)e.Result;

            OrdenCompra or = OrdenesCompra.FindById(orden_id);

            MessageBox.Show("La orden de compra " + or.numero + " fue enviada por email exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProgressBar1.MarqueeAnimationSpeed = 0;
            ProgressBar1.Visible = false;

            //abro el formulario de reporte

            frmReporteOrdenCompra frm = new frmReporteOrdenCompra(or.id);
            frm.MdiParent = this.MdiParent;
            frm.Text = "REPORTE DE ORDEN DE COMPRA N° " + or.numero;
            frm.Show();

            LimpiarControles();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //OrdenCompra orden_id = new OrdenCompra();
            int orden_id = (int)e.Argument;

            //GENERO EL PDF
            string pathadjunto = GenerarPdf(orden_id);

            //ENVIO EL EMAIL
            Utils.Email.EnviarOrdenEmail(orden_id, pathadjunto);

            e.Result = orden_id;
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex; ;
            if (e.ColumnIndex.Equals(10))
            {
                DialogResult result = MessageBox.Show("Va a el producto del detalle, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    //no esta cargado en la db
                    if (Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells[0].Value) == 0)
                    {
                        dgvDetalle.Rows.RemoveAt(row);

                        CalcularMetros();
                        CalcularTotal();
                    }
                    else // esta cargado en la db
                    {
                        int resultado = OrdenesCompraDetalle.OrdenCompraDetalleEliminarFila(Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells[0].Value));
                        if(resultado > 0)
                        {
                            MessageBox.Show("Se elimino el producto del detalle con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDetalle.Rows.RemoveAt(row);

                            CalcularTotal();
                            CalcularMetros();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al eliminar el producto. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbCosto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCosto.CheckState == CheckState.Checked)
                txtCostoNeto.Enabled = true;
            else
                txtCostoNeto.Enabled = false;
        }



    }
}
