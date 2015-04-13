using Entidad;
using Negocio;
using REAL.Utils;
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
    public partial class frmNuevoRemito : Form
    {
        private int cambios = 0;
        public string movimiento { get; set; }
        private List<RemitoDetalle> listado = new List<RemitoDetalle>();
        private List<CobroRemitoContado> listacontado = new List<CobroRemitoContado>();
        private List<CobroRemitoCredito> listacredito = new List<CobroRemitoCredito>();

        public frmNuevoRemito()
        {
            InitializeComponent();
        }

        public frmNuevoRemito(string mov)
        {
            movimiento = mov;
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtIdCliente.Visible = false;
            txtIdProducto.Visible = false;
            txtRazonSocial.Enabled = false;
            txtCalle.Enabled = false;
            txtNumero.Enabled = false;
            
            txtDocumento.Enabled = false;
            txtTipoCliente.Enabled = false;
            txtBarrio.Enabled = false;
            txtCiudad.Enabled = false;
            txtDescripcion.Enabled = false;
            lblImporte.Text = string.Empty;

            txtIdRemito.Visible = false;
            dgvCobros.DataSource = null;
            dgvCobros.Rows.Clear();

            txtPrecio.Text = "0.00";
            txtPrecio.Enabled = false;

            lblRemito.Visible = false;
            txtRemito.Visible = false;
            btnBuscar.Visible = false;
            //dgvCobros.Enabled = false;
            label21.Visible = false;
            cmbTipo.Visible = false;
            dtpFec.Value = DateTime.Today.Date;

            cmbVendedor.SelectedIndex = -1;
            cmbVendedor.Text = "SELECCIONE VENDEDOR";
        }

        private void IniciarControlesModificar()
        {
            btnRegistrar.Text = "Modificar Remito";
            txtIdCliente.Visible = false;
            txtIdProducto.Visible = false;
            txtRazonSocial.Enabled = false;
            txtCalle.Enabled = false;
            txtNumero.Enabled = false;

            txtDocumento.Enabled = false;
            txtTipoCliente.Enabled = false;
            txtBarrio.Enabled = false;
            txtCiudad.Enabled = false;
            txtDescripcion.Enabled = false;
            lblImporte.Text = string.Empty;

            dgvCobros.DataSource = null;
            dgvCobros.Rows.Clear();

            txtPrecio.Text = "0.00";
            txtPrecio.Enabled = false;

            lblRemito.Visible = true;
            txtRemito.Visible = true;
            btnBuscar.Visible = true;
            //dgvCobros.Enabled = false;
            txtIdRemito.Visible = false;
            label21.Visible = false;
            cmbTipo.Visible = false;
            dtpFec.Value = DateTime.Today.Date;
            txtRemito.Text = string.Empty;

            cmbVendedor.SelectedIndex = -1;
            cmbVendedor.SelectedText = "SELECCIONE VENDEDOR";
        }

        private void CargarComboSucursal()
        {
            
            cmbSucursal.ComboBox.ValueMember = "sucid";
            cmbSucursal.ComboBox.DisplayMember = "sucnombre";
            cmbSucursal.ComboBox.DataSource = Sucursales.GetTodos();
        }

        private void CargarComboMovimiento()
        {
            cmbMovimiento.ValueMember = "movid";
            cmbMovimiento.DisplayMember = "movnombre";
            cmbMovimiento.DataSource = Movimientos.GetTodos();
        }

        private void CargarComboMovimientoTipo()
        {
            cmbTipo.ValueMember = "tmoid";
            cmbTipo.DisplayMember = "tmotipo";
            cmbTipo.DataSource = TiposMovimiento.GetTodos();
        }

        private void CargarComboTipoComprobante()
        {
            cmbTipoComprobante.ValueMember = "tipocomprobante_id";
            cmbTipoComprobante.DisplayMember = "tipocomprobante_denominacion";
            cmbTipoComprobante.DataSource = TiposComprobante.GetTodos();
        }

        private void CargarComboVendedor()
        {
            
            cmbVendedor.ComboBox.ValueMember = "vendedor_id";
            cmbVendedor.ComboBox.DisplayMember = "vendedor_nombre";
            cmbVendedor.ComboBox.DataSource = Vendedores.GetTodos();
            
        }

        private void CargarComboEstado()
        {
            cmbEstado.ValueMember = "estadocomprobante_id";
            cmbEstado.DisplayMember = "estadocomprobante_denominacion";
            cmbEstado.DataSource = EstadosComprobante.GetTodo();
        }

        private void frmNuevoRemito_Load(object sender, EventArgs e)
        {                    
            CargarComboSucursal();
            CargarComboMovimiento();
            CargarComboMovimientoTipo();
            CargarComboTipoComprobante();
            CargarComboVendedor();
            CargarComboEstado();

            cmbTipo.SelectedIndex = 1;

            cmbTipo.Enabled = false;

            if (movimiento == "NUEVO")
            {
               
                IniciarControles();



                cmbTipo.SelectedIndex = 1;
                cmbTipo.Enabled = false;

                //CalcularTotal();
            }
            else
            {
                IniciarControlesModificar();
                //MODIFICAR

            }

        }

        private void BuscarCliente(int cliid)
        {
            errorProvider1.Clear();

            Cliente cliente = new Cliente();
            cliente.cliid = cliid;
            cliente = Clientes.GetPorId(cliente);
            if (cliente != null)
            {
                txtIdCliente.Text = cliente.cliid.ToString();
                txtRazonSocial.Text = cliente.clinombre;
                txtDocumento.Text = cliente.clidocumento;
                txtCalle.Text = cliente.clicalle;
                txtNumero.Text = cliente.clinumero;
                txtTipoCliente.Text = cliente.tipoiva.tpitipo;
                txtBarrio.Text = cliente.clibarrio;
                txtCiudad.Text = cliente.ciudad.ciunombre;

            }         
            else
            {
                LimpiarControlesCliente();
                errorProvider1.SetError(btnBuscarCliente, "El cliente no se encuentra registrado.");
            }
        }

        private void LimpiarControlesCliente()
        {
            txtTipoCliente.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtBarrio.Text = string.Empty;
            txtCodigoCliente.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtCalle.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtCiudad.Text = string.Empty;
        }

        private void BuscarProductoPorCodigo(int prdid)
        {
            errorProvider1.Clear();
            Producto producto = new Producto();

            producto = Productos.GetPorId(prdid);
            if (producto != null)
            {            
                txtCodigoProducto.Text = String.Format("{0:000000}", producto.prdid);
                txtIdProducto.Text = producto.prdid.ToString();
                txtDescripcion.Text = producto.prddenominacion;
              
                txtPrecio.Text = "0.00";
                txtPrecio.Enabled = false;              
            }           
            else
            {
                LimpiarControlesProducto();
                errorProvider1.SetError(btnBuscarProducto, "El producto no se encuentra registrado.");
            }
        }

        private void LimpiarControles()
        {
            txtNumeroRemito.Text = string.Empty;
            txtNumeroFactura.Text = string.Empty;
            cmbSucursal.SelectedIndex = 0;
            cmbMovimiento.SelectedIndex = 0;
            cmbTipo.SelectedIndex = 0;
            cmbTipoComprobante.SelectedIndex = 0;
            dgvCobros.DataSource = null;
            dgvCobros.Rows.Clear();
            dgvDetalle.Rows.Clear();


            CalcularTotal();
        }
  
        private void LimpiarControlesProducto()
        {
            txtCodigoProducto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtPrecio.Text = "0.00";
            txtIdProducto.Text = string.Empty;
            txtCodigoProducto.Focus();
        }

        private Boolean ValidarControlesProducto()
        {
            bool resultado = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtCodigoProducto.Text))
            {
                resultado = false;
                errorProvider1.SetError(btnBuscarProducto, "Debe seleccionar el producto.");
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtDescripcion, "Debe seleccionar el producto.");
            }
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtCantidad, "Debe indicar una cantidad.");
            }
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtPrecio, "Debe completar el campo precio.");
            }

            return resultado;
        }

        private void CrearRemito()
        {
            Remito remito = new Remito();
            remito.cliente = new Cliente();
            remito.estadocomprobante = new EstadoComprobante();

            remito.remito_numero = txtNumeroRemito.Text;
            remito.cliente.cliid = Convert.ToInt32(txtCodigoCliente.Text);
            remito.movimiento = (Movimiento)cmbMovimiento.SelectedItem;
            remito.tipomovimiento = (TipoMovimiento)cmbTipo.SelectedItem;
            remito.remito_fecha = dtpFec.Value;
            remito.remito_importe = Convert.ToDouble(txtImporte.Text);
            remito.remito_numerofactura = txtNumeroFactura.Text;
            remito.sucursal = (Sucursal)cmbSucursal.SelectedItem;
            remito.tipocomprobante = (TipoComprobante)cmbTipoComprobante.SelectedItem;
            remito.tipomovimiento = (TipoMovimiento)cmbTipo.SelectedItem;
            remito.vendedor = (Vendedor)cmbVendedor.SelectedItem;
            remito.estadocomprobante = (EstadoComprobante)cmbEstado.SelectedItem;

            remito.detalle = listado;
            remito.cobrocontado = listacontado;
            remito.cobrocredito = listacredito;

            try
            {
                bool resultado = Remitos.Existe(remito);
                if (resultado == false)
                {
                    remito = Remitos.Crear(remito);

                    if (remito != null)
                    {
                        MessageBox.Show("El remito se registro correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //limpiar controles
                        LimpiarControlesCliente();
                        LimpiarControlesProducto();
                        LimpiarControles();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al registrar el remito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimpiarControlesCliente();
                        LimpiarControlesProducto();
                        LimpiarControles();
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNumero, "El remito ya se encuentra registrado");                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarCobros(List<CobroRemitoContado> listacontado, List<CobroRemitoCredito> listcredito)
        {
            dgvCobros.Rows.Clear();

            foreach (CobroRemitoContado fila in listacontado)
            {
                dgvCobros.Rows.Add("", "", "CONTADO", "", "", "", "", Convert.ToDouble(fila.cobroremito_importe));
            }

            foreach (CobroRemitoCredito fila in listcredito)
            {
                dgvCobros.Rows.Add("", "", "CREDITO", "", fila.plan.tarjetacredito.tarnombre, fila.plan.plan_id, fila.plan.plan_denominacion, Convert.ToDouble(fila.cobroremito_importe));
            }

            if (dgvCobros.Rows.Count > 0)
            {
                dgvCobros.CurrentRow.Selected = false;
            }

        }

        private void CalcularTotal()
        {         
            double total = 0;
            foreach (DataGridViewRow dr in dgvDetalle.Rows)
            {
                total = total + Convert.ToDouble(dr.Cells["remitodetalle_importetotal"].Value);
            }
            lblImporte.Text = total.ToString();
        }

        private Boolean ValidarControles()
        {
            bool resultado = true;
            errorProvider1.Clear();
            
            if (cmbVendedor.SelectedIndex < 0)
            {
                resultado = false;
                errorProvider1.SetError(btnRegistrar, "Debe seleccionar un vendedor");
            }

            if (String.IsNullOrEmpty(txtCodigoCliente.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtCodigoCliente, "Debe seleccionar un cliente");
            }

            if(String.IsNullOrEmpty(txtRazonSocial.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtCodigoCliente, "Debe seleccionar un cliente");
            }

            if (dgvCobros.Rows.Count == 0 && cmbMovimiento.Text == "VENTA")
            {
                resultado = false;
                errorProvider1.SetError(btnFormaPago, "Debe seleccionar los pagos de la operación");
            }

            if (dgvDetalle.Rows.Count == 0)
            {
                resultado = false;
                errorProvider1.SetError(btnBuscarProducto, "Debe seleccionar al menos un producto");
            }

            if (string.IsNullOrEmpty(txtNumeroRemito.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtNumeroRemito, "El campo número de remito no puede ser vacio");
            }

            if (string.IsNullOrEmpty(txtNumeroFactura.Text) && cmbMovimiento.Text == "VENTA")
            {
                resultado = false;
                errorProvider1.SetError(txtNumeroFactura, "El campo número de factura no puede ser vacio");
            }
            if(CalcularTotalCobros() != Convert.ToDouble(txtImporte.Text) || txtImporte.Text == string.Empty)
            {
                resultado = false;
                errorProvider1.SetError(btnFormaPago, "No coincide el importe del documento con los pagos asignados");
            }

            if (string.IsNullOrEmpty(txtImporte.Text))
            {
                resultado = false;
                errorProvider1.SetError(btnFormaPago, "Debe completar el campo importe");
            }

            return resultado;
        }

        private Double CalcularTotalCobros()
        {
            double total = 0;
            foreach (DataGridViewRow dr in dgvCobros.Rows)
            {
                total = total + Convert.ToDouble(dr.Cells["formapago_importe"].Value);
            }
            return total;
        }

        private void frmNuevoRemito_Resize(object sender, EventArgs e)
        {
           
       
            btnCancelar.Location = new Point((this.Width - 350) - btnCancelar.Width, this.Height - 120);
            btnGenerar.Location = new Point((this.Width - 350) - btnGenerar.Width, this.Height - 150);
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigoCliente.Text != String.Empty && txtCodigoCliente.TextLength == 6)
            {
                BuscarCliente(Convert.ToInt32(txtCodigoCliente.Text));
            }
        }

        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text != string.Empty && txtCodigoProducto.TextLength == 6)
            {
                BuscarProductoPorCodigo(Convert.ToInt32(txtCodigoProducto.Text));
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarControlesProducto() == true)
            {
                dgvDetalle.Rows.Add(0, txtIdProducto.Text, txtCodigoProducto.Text, txtDescripcion.Text, Convert.ToDouble("0.00"), txtCantidad.Text, (Convert.ToDouble(txtPrecio.Text) * Convert.ToInt32(txtCantidad.Text)));
                LimpiarControlesProducto();
            }
            //CalcularTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //VALIDAR CONTROLES

            //VALIDAR SI EXISTE REGISTRADO EL REMITO

            if (ValidarControles() == true)
            {
                if (movimiento == "NUEVO")
                {
                    DialogResult result = MessageBox.Show("Se va a registrar el remito, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        listado.Clear();
                        foreach (DataGridViewRow dr in dgvDetalle.Rows)
                        {
                            RemitoDetalle detalle = new RemitoDetalle();
                            detalle.producto = new Producto();

                            detalle.remitodetalle_id = Convert.ToInt32(dr.Cells["remitodetalle_id"].Value);
                            detalle.producto.prdid = Convert.ToInt32(dr.Cells["producto_id"].Value);
                            detalle.remitodetalle_cantidad = Convert.ToInt32(dr.Cells["remitodetalle_cantidad"].Value);
                            detalle.remitodetalle_importeunitario = Convert.ToDouble(dr.Cells["remitodetalle_importeunitario"].Value);

                            listado.Add(detalle);
                        }

                        CrearRemito();
                    }
                }
                else
                {
                     DialogResult result = MessageBox.Show("Se va a modificar el remito, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (result == System.Windows.Forms.DialogResult.Yes)
                     {
                         listado.Clear();
                         foreach (DataGridViewRow dr in dgvDetalle.Rows)
                         {
                             RemitoDetalle detalle = new RemitoDetalle();
                             detalle.producto = new Producto();

                             detalle.remitodetalle_id = Convert.ToInt32(dr.Cells["remitodetalle_id"].Value);
                             detalle.producto.prdid = Convert.ToInt32(dr.Cells["producto_id"].Value);
                             detalle.remitodetalle_cantidad = Convert.ToInt32(dr.Cells["remitodetalle_cantidad"].Value);
                             detalle.remitodetalle_importeunitario = Convert.ToDouble(dr.Cells["remitodetalle_importeunitario"].Value);

                             listado.Add(detalle);
                         }

                         ModificarRemito();
                     }
                }
            }
        }

        //revisar
        private void ModificarRemito()
        {

            Remito remito = new Remito();
            remito.cliente = new Cliente();
            remito.estadocomprobante = new EstadoComprobante();

            remito.remito_id = Convert.ToInt32(txtIdRemito.Text);
            remito.remito_numero = txtNumeroRemito.Text;
            remito.cliente.cliid = Convert.ToInt32(txtCodigoCliente.Text);
            remito.movimiento = (Movimiento)cmbMovimiento.SelectedItem;
            remito.tipomovimiento = (TipoMovimiento)cmbTipo.SelectedItem;
            remito.remito_fecha = dtpFec.Value;
            remito.remito_importe = Convert.ToDouble(txtImporte.Text);
            remito.remito_numerofactura = txtNumeroFactura.Text;
            remito.sucursal = (Sucursal)cmbSucursal.SelectedItem;
            remito.tipocomprobante = (TipoComprobante)cmbTipoComprobante.SelectedItem;
            remito.tipomovimiento = (TipoMovimiento)cmbTipo.SelectedItem;
            remito.vendedor = (Vendedor)cmbVendedor.SelectedItem;
            remito.estadocomprobante = (EstadoComprobante)cmbEstado.SelectedItem;

            remito.detalle = listado;
            remito.cobrocontado = listacontado;
            remito.cobrocredito = listacredito;

            try
            {
                bool resultado = Remitos.Modificar(remito);
                if (resultado == true)
                {
                    MessageBox.Show("El remito se modifico con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControlesCliente();
                    LimpiarControlesProducto();
                    LimpiarControles();
                    IniciarControlesModificar();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al modificar el remito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFormaPago_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                if (txtImporte.Text != string.Empty)
                {
                    if (movimiento == "NUEVO")
                    {
                      
                        frmFormaPago dlg = new frmFormaPago(Convert.ToDouble(txtImporte.Text));
                        dlg.Text = "FORMA DE PAGO";

                        DialogResult result = dlg.ShowDialog();
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            listacontado = dlg.listacontado;
                            listacredito = dlg.listacredito;

                            CargarCobros(listacontado, listacredito);
                        }
                    }
                    else
                    {
                        frmFormaPago dlg = new frmFormaPago(Convert.ToInt32(txtIdRemito.Text));
                        dlg.Text = "FORMA DE PAGO";

                        listacontado.Clear();
                        listacredito.Clear();

                        DialogResult result = dlg.ShowDialog();
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            listacontado = dlg.listacontado;
                            listacredito = dlg.listacredito;

                            CargarCobros(listacontado, listacredito);
                            cambios = cambios + 1;
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtImporte, "Debe indicar el importe de la venta");
                }
                
            }
            else
            {
                errorProvider1.SetError(btnFormaPago, "Debe seleccionar al menos un producto");
            }
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                if (dgvDetalle.Columns[e.ColumnIndex].Name == "eliminar" && movimiento != "MODIFICAR")
                {
                    int fila = dgvDetalle.CurrentRow.Index;
                    dgvDetalle.Rows.RemoveAt(fila);
                }
                else
                {
                    if (dgvDetalle.Columns[e.ColumnIndex].Name == "eliminar")
                    {
                        DialogResult result = MessageBox.Show("Se va a eliminar el producto del detalle, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            int fila = dgvDetalle.CurrentRow.Index;
                            DataGridViewRow f = dgvDetalle.CurrentRow;

                            bool resultado = Remitos.EliminarDetalle(Convert.ToInt32(f.Cells["remitodetalle_id"].Value));
                            if (resultado == true)
                            {
                                MessageBox.Show("El producto se elimino con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvDetalle.Rows.RemoveAt(fila);
                                cambios = cambios + 1;
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error al eliminar el producto del detalle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cambios = cambios + 1;
                            }

                        }
                    }
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            LimpiarControlesProducto();
            dlgProducto dlg = new dlgProducto();
            dlg.Text = "PRODUCTOS - LISTADO DE PRODUCTOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.prdid != 0)
            {
                txtCodigoProducto.Text = String.Format("{0:000000}", dlg.prdid);

            }
        }

        private void txtNumeroRemito_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                errorProvider1.SetError(txtNumeroRemito, "Solo se permiten números en el campo número remito.");
                e.Handled = true;
                txtNumeroRemito.Focus();
                return;
            }
        }

        private void txtNumeroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                errorProvider1.SetError(txtNumeroFactura, "Solo se permiten números en el campo número factura.");
                e.Handled = true;
                txtNumeroFactura.Focus();
                return;
            }
        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                errorProvider1.SetError(txtCodigoCliente, "Solo se permiten números en el campo código cliente.");
                e.Handled = true;
                txtCodigoCliente.Focus();
                return;
            }
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                errorProvider1.SetError(txtCodigoProducto, "Solo se permiten números en el campo número remito.");
                e.Handled = true;
                txtCodigoProducto.Focus();
                return;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                errorProvider1.SetError(txtCantidad, "Solo se permiten números en el campo cantidad.");
                e.Handled = true;
                txtCantidad.Focus();
                return;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || char.IsControl(e.KeyChar)
                )
            {

                e.Handled = false;
            }

            else
            {
                errorProvider1.SetError(txtPrecio, "Solo se permiten números en el campo precio venta.");
                e.Handled = true;
            }
        }

        private void cmbMovimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbMovimiento.Text != "VENTA")
            {
                txtPrecio.Text = "0.00";
                txtPrecio.Enabled = false;
                txtNumeroFactura.Enabled = false;
                txtNumeroFactura.Text = "000000000000";
                txtImporte.Text = "0.00";
                txtImporte.Enabled = false;
            }
            else
            {
                txtPrecio.Text = "0.00";
                txtPrecio.Enabled = false;
                txtNumeroFactura.Enabled = true;
                txtNumeroFactura.Text = string.Empty;
                txtImporte.Text = string.Empty;
                txtImporte.Enabled = true;
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            LimpiarControlesCliente();
            dlgCliente dlg = new dlgCliente();
            dlg.Text = "CLIENTES - LISTADO DE CLIENTES REGISTRADOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.cliid != 0)
            {
                txtCodigoCliente.Text = String.Format("{0:000000}", dlg.cliid);

            }
        }        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || char.IsControl(e.KeyChar)
                )
            {
                e.Handled = false;
            }

            else
            {
                errorProvider1.SetError(txtImporte, "Solo se permiten números en el campo importe.");
                e.Handled = true;
            }
        }

        private void txtNumeroRemito_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                errorProvider1.SetError(txtNumeroRemito, "Solo se permiten números en el campo número remito.");
                e.Handled = true;
                txtNumeroRemito.Focus();
                return;
            }
        }

        private void txtNumeroFactura_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                errorProvider1.SetError(txtNumeroFactura, "Solo se permiten números en el campo número factura.");
                e.Handled = true;
                txtNumeroFactura.Focus();
                return;
            }
        }

        private void cmbMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dlgRemitos dlg = new dlgRemitos();
            dlg.Text = "VENTAS - LISTADO DE REMITOS REGISTRADOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.remito.remito_id != 0)
            {
                Remito remito = new Remito();
                remito = dlg.remito;

                txtRemito.Text = remito.remito_numero;
                txtIdRemito.Text = remito.remito_id.ToString();

                ObtenerDatosRemito(remito);

            }

        }

        private void ObtenerDatosRemito(Remito remito)
        {

            try
            {
                remito = Remitos.GetPorId(remito.remito_id);
                if (remito != null)
                {
                    cmbTipoComprobante.Text = remito.tipocomprobante.tipocomprobante_denominacion;
                    txtNumeroRemito.Text = remito.remito_numero;
                    txtNumeroFactura.Text = remito.remito_numerofactura;
                    txtRazonSocial.Text = remito.cliente.clinombre;
                    txtCalle.Text = remito.cliente.clicalle;
                    txtDocumento.Text = remito.cliente.clidocumento;
                    txtTipoCliente.Text = remito.cliente.tipoiva.tpitipo;
                    txtNumero.Text = remito.cliente.clinumero;
                    txtBarrio.Text = remito.cliente.clibarrio;
                    txtCiudad.Text = remito.cliente.ciudad.ciunombre;
                    txtCodigoCliente.Text = remito.cliente.clicodigo;
                    cmbMovimiento.Text = remito.movimiento.movnombre;
                    cmbEstado.Text = remito.estadocomprobante.estadocomprobante_denominacion;
                    dtpFec.Value = remito.remito_fecha;
                    txtImporte.Text = remito.remito_importe.ToString();

                    dgvDetalle.Rows.Clear();
                    foreach (RemitoDetalle detalle in remito.detalle)
                    {
                        dgvDetalle.Rows.Add(detalle.remitodetalle_id, detalle.producto.prdid, detalle.producto.prdcodigo, detalle.producto.prddenominacion, detalle.remitodetalle_importeunitario, detalle.remitodetalle_cantidad, Convert.ToDouble(detalle.remitodetalle_importeunitario * detalle.remitodetalle_cantidad));
                        
                    }

                    dgvCobros.Rows.Clear();
                    listacontado.Clear();
                    listacredito.Clear();
                    listacontado = remito.cobrocontado;
                    listacredito = remito.cobrocredito;
                    CargarCobros(remito.cobrocontado, remito.cobrocredito);

                }
                else
                {
                    errorProvider1.SetError(txtNumeroRemito, "El remito indicado no existe registrado en el sistema");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmNuevoRemito_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (movimiento == "MODIFICAR" && cambios > 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(btnRegistrar, "Debe guardar los cambios en el remito");                               
            }

        }

    }
}
