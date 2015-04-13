using Entidad;
using Negocio;
using REAL.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmIngresoProveedor : Form
    {
        public List<FacturaProveedorDetalle> detalle = new List<FacturaProveedorDetalle>();
        public List<RemitoProveedor> remitos = new List<RemitoProveedor>();
        public List<RemitoProveedorDetalle> detalleremito = new List<RemitoProveedorDetalle>();
        public frmIngresoProveedor()
        {
            
            InitializeComponent();
        }

        private void frmIngresoProveedor_Load(object sender, EventArgs e)
        {
            GetProveedores();
            GetDepositos();
            IniciarControles();
        }


        private void GetDepositos()
        {
            cmbSucursal.ValueMember = "sucid";
            cmbSucursal.DisplayMember = "sucnombre";
            cmbSucursal.DataSource = Sucursales.GetTodos();
        }

        private void GetProveedores()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.FindAll();
        }

      

        private void IniciarControles()
        {
            txtRemito.Enabled = false;         
            txtid.Visible = false;       
            txtIdIngreso.Visible = false;
            txtCosto.Enabled = false;
            txtProducto.Enabled = false;
            txtSubtotal.Enabled = false;
            txtSubtotal.Text = "0.00";
            txtIva.Text = "0.00";
            txtIngBrutos.Text = "0.00";
            txtTotal.Enabled = false;
            txtRemito.Enabled = false;
            cmbSucursal.Enabled = false;
            txtIdOrden.Visible = false;
            txtNroOrden.Visible = false;
            txtFecha.Visible = false;

            dgvDetalle.Columns[8].Visible = false;
            dgvDetalle.Columns[9].Visible = false;

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRemitos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void ckbRemito_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {

            if (ckbRemito.CheckState == CheckState.Unchecked)
            {
                txtCodigo.Text = string.Empty;
                txtCosto.Text = string.Empty;
                txtProducto.Text = string.Empty;
                txtCantidad.Text = string.Empty;

                errorProvider1.Clear();

                dlgProducto dlg = new dlgProducto(Convert.ToInt32(cmbProveedor.SelectedValue));
                dlg.Text = "Productos - Selector de Producto";
                DialogResult result = dlg.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK && dlg.prdid != 0)
                {
                    txtid.Text = dlg.prdid.ToString();
                    txtCodigo.Text = dlg.prdcodigo.ToString();

                }
            }
            else
            {
                txtCodigo.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                txtNroOrden.Text = string.Empty;
                txtIdOrden.Text = string.Empty;
                txtProducto.Text = string.Empty;
                errorProvider1.Clear();

                dlgPendientesEntrega dlg = new dlgPendientesEntrega(Convert.ToInt32(cmbProveedor.SelectedValue), Convert.ToInt32(cmbSucursal.SelectedValue));
                dlg.Text = "Compras - Selector de Productos Pendientes de Entrega";
                DialogResult result = dlg.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    txtid.Text = dlg.prdid.ToString();
                    //txtid.Text = dlg.prdid.ToString();
                    //txtCodigo.Text = dlg.prdcodigo.ToString();
                    DataTable dt = Productos.GetProductoObtenerPorId(Convert.ToInt32(txtid.Text));
                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["proid"]) == Convert.ToInt32(cmbProveedor.SelectedValue))
                        {
                            txtCodigo.Text = dlg.prdcodigo.ToString();
                            txtIdOrden.Text = dlg.odcid.ToString();
                            txtNroOrden.Text = dlg.odcnumero.ToString();
                            txtFecha.Text = dlg.fecha.ToShortDateString();
                        }
                        else
                        {
                            errorProvider1.SetError(btnBuscarOrden, "El producto seleccionado no corresponde al proveedor.");                          
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(btnBuscarOrden, "El producto selecccionado no es correcto.");
                    }
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != string.Empty && string.IsNullOrEmpty(txtid.Text) && txtCodigo.TextLength == 6)
            {
                ObtenerProducto(Convert.ToInt32(txtCodigo.Text));
               
            }
        }

        private void ObtenerProducto(int prdid)
        {
            Producto producto = Productos.GetPorId(prdid);

            if (producto != null)
            {
                if (producto.proveedor.proid == Convert.ToInt32(cmbProveedor.SelectedValue))
                {
                    txtProducto.Text = producto.prddenominacion;

                    ObtenerCostoProducto(producto);

                    txtCosto.Text = producto.prdcosto.ToString();
                    txtCodigo.Text = producto.prdcodigo;
                    //txtMetros.Text = producto.prdmetros.ToString();
                    //txtCoeficiente.Text = (CalcularBonificaciones(producto).ToString());
                    //txtCostoNeto.Text = (CalcularBonificaciones(producto).ToString());


                }
            }
            else
            {

                errorProvider1.SetError(txtProducto, "El producto no existe registrado en el sistema.");
                txtProducto.Focus();
            }
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

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (txtid.Text != string.Empty)
            {
                ObtenerProducto(Convert.ToInt32(txtid.Text));
            }
        }

        private void ckbCosto_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbCosto.CheckState == CheckState.Checked)
            {
                txtCosto.Enabled = true;
            }
            else
            {
                txtCosto.Enabled = false;
            }
        }

        private Boolean ValidarAgregar()
        {
            bool resultado = true;
            errorProvider1.Clear();

            if(string.IsNullOrEmpty(txtCodigo.Text))
            {
                resultado = false;
                errorProvider1.SetError(btnBuscarOrden, "Debe seleccionar un producto.");
                return resultado;
            }

            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtCantidad, "Debe indicar una cantidad.");
                return resultado;
            }

            if (string.IsNullOrEmpty(txtCosto.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtCosto, "Debe indicar el costo del producto.");
                return resultado;
            }

            return resultado;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarAgregar() == true)
            {
                if (ckbRemito.CheckState == CheckState.Unchecked)
                {
                    dgvDetalle.Rows.Add(txtid.Text, txtCodigo.Text, txtProducto.Text, Convert.ToDouble(txtCosto.Text), txtCantidad.Text, (Convert.ToDouble(txtCosto.Text) * Convert.ToInt32(txtCantidad.Text)), "");
                    LimpiarControlesAgregar();
                    CalcularSubtotal();
                }
                else
                {
                    dgvDetalle.Rows.Add(txtid.Text, txtCodigo.Text, txtProducto.Text, Convert.ToDouble(txtCosto.Text), txtCantidad.Text, (Convert.ToDouble(txtCosto.Text) * Convert.ToInt32(txtCantidad.Text)), "", txtIdOrden.Text, txtNroOrden.Text, txtFecha.Text);
                    LimpiarControlesAgregar();
                    CalcularSubtotal();
                }
            }
        }


        private void LimpiarControlesAgregar()
        {
            txtCodigo.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtid.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtIdOrden.Text = string.Empty;
            txtNroOrden.Text = string.Empty;
            txtFecha.Text = string.Empty;
        }

        private void CalcularSubtotal()
        {
            double subtotal = 0;
            foreach(DataGridViewRow fila in dgvDetalle.Rows)
            {
                subtotal = subtotal + Convert.ToDouble(fila.Cells[5].Value);
            }
            txtSubtotal.Text = subtotal.ToString();
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIva.Text))
            {
                if (!string.IsNullOrEmpty(txtIngBrutos.Text))
                {
                    CalcularTotal();
                }
            }
        }

        private void CalcularTotal()
        {
            double total = 0;
            total = Convert.ToDouble(txtSubtotal.Text) + Convert.ToDouble(txtIva.Text) + Convert.ToDouble(txtIngBrutos.Text);
            txtTotal.Text = total.ToString();
        }

        private void txtIva_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSubtotal.Text))
            {
                if (!string.IsNullOrEmpty(txtIngBrutos.Text))
                {
                    CalcularTotal();
                }
            }
        }

        private void txtIngBrutos_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSubtotal.Text))
            {
                if (!string.IsNullOrEmpty(txtIva.Text))
                {
                    CalcularTotal();
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarRemito_Click(object sender, EventArgs e)
        {
            frmRemitoSelector frm = new frmRemitoSelector();
            DialogResult result = frm.ShowDialog();
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                remitos.Clear();
                remitos = frm.remitos;
                foreach(RemitoProveedor row in remitos)
                {
                    dgvRemitos.Rows.Add(row.id, row.numero, row.fechaemision.ToShortDateString());
                }
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(FacturasProveedor.VerificarFactura(txtFactura.Text) == 0)
            {
                if (ckbRemito.CheckState == CheckState.Checked)
                {
                    if(ValidarConRemito() == true)
                    {
                        InsertarFacturaConRemito();
                    }
                }
                else
                {
                    if (ValidarSoloFactura() == true)
                    {
                        InsertarFactura();
                    }
                }
            }
            else
            {
                MessageBox.Show("La factura " + txtFactura.Text + " ya se encuentra registrada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void CrearDetalle()
        {
            detalle.Clear();

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                FacturaProveedorDetalle fila = new FacturaProveedorDetalle();
                fila.fpdcantidad = Convert.ToInt32(row.Cells[4].Value);
                fila.fpdimporteunit = Convert.ToInt32(row.Cells[3].Value);
                fila.prdid = Convert.ToInt32(row.Cells[0].Value);
                fila.odcid = Convert.ToInt32(row.Cells[7].Value);

                detalle.Add(fila);
            }
        }

        private void CrearDetalleRemito()
        {
            detalleremito.Clear();

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                RemitoProveedorDetalle fila = new RemitoProveedorDetalle();
                fila.cantidad = Convert.ToInt32(row.Cells[4].Value);
                fila.orden_id = Convert.ToInt32(row.Cells[7].Value); 
                fila.producto_id = Convert.ToInt32(row.Cells[0].Value);

                detalleremito.Add(fila);
            }
        }


        private Boolean ValidarSoloFactura()
        {
            bool resultado = true;
            errorProvider1.Clear();

            if(txtFactura.MaskFull == false)
            {
                resultado = false;
                errorProvider1.SetError(txtFactura, "Debe completar el campo Nro. Factura.");
                return resultado;
            }

            if(string.IsNullOrEmpty(txtIva.Text) && Convert.ToInt32(txtIva.Text) != 0)
            {
                resultado = false;
                errorProvider1.SetError(txtIva, "Debe completar el campo I.V.A.");
                return resultado;
            }

            if(string.IsNullOrEmpty(txtIngBrutos.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtIngBrutos, "Debe completar el campo Ing. Brutos.");
                return resultado;
            }

            if(dgvDetalle.Rows.Count == 0)
            {
                resultado = false;
                errorProvider1.SetError(btnBuscarOrden, "Debe agregar un detalle a la Factura.");
                return resultado;
            }

            if(dgvRemitos.Rows.Count == 0)
            {
                resultado = false;
                tabControl1.SelectTab(1);
                errorProvider1.SetError(btnBuscarRemito, "Debe seleccionar al menos un Remito.");
                return resultado;
            }
            return resultado;
        }


        private void InsertarFactura()
        {
            FacturaProveedor factura = new FacturaProveedor();
            factura.activo = 1;
            factura.fecha = dtpFechaFactura.Value;
            factura.fecharecepcion = dtpFechaRecepcion.Value;
            factura.importe = Convert.ToDecimal(txtTotal.Text);
            factura.numero = txtFactura.Text;
            factura.observaciones = txtObservacion.Text;
            factura.proveedor_id = Convert.ToInt32(cmbProveedor.SelectedValue);   
            
            //ver
            factura.sucursal_id = Convert.ToInt32(cmbSucursal.SelectedValue);
            CrearDetalle();
            factura.detalle = detalle;
            factura.remitos = remitos;

            int resultado = FacturasProveedor.add(factura);
            if(resultado > 0)
            {
                MessageBox.Show("Los datos se registraron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al registrar los datos. Intente Nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarFacturaConRemito()
        {

            //creo la factura
            FacturaProveedor factura = new FacturaProveedor();
            factura.activo = 1;
            factura.fecha = dtpFechaFactura.Value;
            factura.fecharecepcion = dtpFechaRecepcion.Value;
            factura.importe = Convert.ToDecimal(txtTotal.Text);
            factura.numero = txtFactura.Text;
            factura.observaciones = txtObservacion.Text;
            factura.proveedor_id = Convert.ToInt32(cmbProveedor.SelectedValue);

            //ver
            factura.sucursal_id = Convert.ToInt32(cmbSucursal.SelectedValue);
            CrearDetalle();
            factura.detalle = detalle;
            factura.remitos = remitos;


            //creo el remito

            RemitoProveedor remito = new RemitoProveedor();
            remito.activo = 1;
            remito.fechaemision = dtpFechaFactura.Value;
            remito.fecharecepcion = dtpFechaRecepcion.Value;
            remito.numero = txtRemito.Text;
            remito.observaciones = txtObservacion.Text;
            remito.proveedor_id = Convert.ToInt32(cmbProveedor.SelectedValue);
            remito.sucursal_id = Convert.ToInt32(cmbSucursal.SelectedValue);

            CrearDetalleRemito();
            remito.detalle = detalleremito;

            int resultado = FacturasProveedor.AddFacturaConRemito(factura, remito);
            if(resultado > 0)
            {
                MessageBox.Show("Los datos se registraron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al registrar los datos. Intente Nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void LimpiarControles()
        {
            txtFactura.Text = string.Empty;
            txtIngBrutos.Text = "0.00";
            txtIva.Text = "0.00";
            txtTotal.Text = "0.00";
            txtSubtotal.Text = "0.00";
            txtRemito.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            cmbProveedor.SelectedIndex = 0;
            cmbSucursal.SelectedIndex = 0;

            dgvDetalle.Rows.Clear();
            dgvRemitos.Rows.Clear();

            tabControl1.SelectTab(0);
        }




        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDetalle.Columns[e.ColumnIndex].Name == "eliminar")
            {                
                DialogResult result = MessageBox.Show("Desea quitar del detalle el producto: " + dgvDetalle.CurrentRow.Cells[1].Value.ToString() + " - " + dgvDetalle.CurrentRow.Cells[2].Value.ToString() + " ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    int fila = dgvDetalle.CurrentRow.Index;
                    dgvDetalle.Rows.RemoveAt(fila);
                    CalcularSubtotal();
                }
            }
        }

        private void ckbRemito_CheckedChanged_1(object sender, EventArgs e)
        {
            if(ckbRemito.CheckState == CheckState.Checked)
            {
                cmbSucursal.Enabled = true;
                txtRemito.Enabled = true;           
                dgvDetalle.Columns[8].Visible = true;
                dgvDetalle.Columns[9].Visible = true;
                btnBuscarRemito.Enabled = false;
            }
            else
            {
                cmbSucursal.Enabled = false;
                txtRemito.Enabled = false;
                dgvDetalle.Columns[8].Visible = false;
                dgvDetalle.Columns[9].Visible = false;
                btnBuscarRemito.Enabled = true;
            }
        }


        private Boolean ValidarConRemito()
        {
            bool resultado = true;

            errorProvider1.Clear();

            if (txtFactura.MaskFull == false)
            {
                resultado = false;
                errorProvider1.SetError(txtFactura, "Debe completar el campo Nro. Factura.");
                return resultado;
            }

            if (string.IsNullOrEmpty(txtIva.Text) && Convert.ToInt32(txtIva.Text) != 0)
            {
                resultado = false;
                errorProvider1.SetError(txtIva, "Debe completar el campo I.V.A.");
                return resultado;
            }

            if (string.IsNullOrEmpty(txtIngBrutos.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtIngBrutos, "Debe completar el campo Ing. Brutos.");
                return resultado;
            }

            if (dgvDetalle.Rows.Count == 0)
            {
                resultado = false;
                errorProvider1.SetError(btnBuscarOrden, "Debe agregar un detalle a la Factura.");
                return resultado;
            }

            if(txtRemito.MaskFull == false)
            {
                resultado = false;
                errorProvider1.SetError(txtRemito, "Debe completar el campo Remito.");
                return resultado;
            }

            return resultado;
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



    }

       

}
