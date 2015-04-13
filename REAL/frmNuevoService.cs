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
using System.Transactions;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmNuevoService : Form
    {
        public frmNuevoService()
        {
            InitializeComponent();
           
        }

        private void IniciarControles()
        {
            txtidCliente.Visible = false;
            txtidProd.Visible = false;

            txtCalle.Text = string.Empty;
            txtidCliente.Text = string.Empty;
            txtCodigoCliente.Text = string.Empty;
            txtDepto.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMotivo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtPiso.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtRemito.Text = string.Empty;
            txtTelCelular.Text = string.Empty;
            txtTelFijo.Text = string.Empty;
            txtBarrio.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtNombreProd.Text = string.Empty;
            txtidProd.Text = string.Empty;

            txtDepto.Enabled = false;
            txtDocumento.Enabled = false;
            txtEmail.Enabled = false;
            txtNombre.Enabled = false;
            txtNumero.Enabled = false;
            txtPiso.Enabled = false;
            txtTelCelular.Enabled = false;
            txtTelFijo.Enabled = false;
            txtCalle.Enabled = false;
            txtBarrio.Enabled = false;
            txtCiudad.Enabled = false;
            txtNombreProd.Enabled = false;

            CargargarComboBoxSucursal();
            CargarComboBoxProveedor();
            //CargarComboBoxBarrio();
            //CargarComboBoxCiudad();
            cmbProveedor.Focus();
            dgvDetalle.Rows.Clear();
            tabControl1.SelectedIndex = 0;
            ckbFabricacion.CheckState = CheckState.Unchecked;
            ckbFactura.CheckState = CheckState.Unchecked;
            ckbGarantia.CheckState = CheckState.Unchecked;
            ckbRemito.CheckState = CheckState.Unchecked;
            
        }

        private void CargargarComboBoxSucursal()
        {
            cmbSucursal.ValueMember = "sucid";
            cmbSucursal.DisplayMember = "sucnombre";
            cmbSucursal.DataSource = Sucursales.SucursalObtenerTodo();
            cmbSucursal.SelectedIndex = 0;
        }

        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetProveedoresDatos();
            cmbProveedor.SelectedIndex = 0;

        }

        private void BuscarDatosCliente(int cliid)
        {
            DataTable dt = new DataTable();
            dt = Clientes.GetClienteDatosPodId(cliid);
            if (dt.Rows.Count > 0)
            {
                lblValidacion.Text = string.Empty;
                txtNombre.Text = dt.Rows[0].ItemArray[0].ToString();
                txtDocumento.Text = dt.Rows[0].ItemArray[1].ToString();
                txtBarrio.Text = dt.Rows[0].ItemArray[2].ToString();
                txtCiudad.Text = dt.Rows[0].ItemArray[3].ToString();
                txtCalle.Text = dt.Rows[0].ItemArray[4].ToString();
                txtNumero.Text = dt.Rows[0].ItemArray[5].ToString();
                txtPiso.Text = dt.Rows[0].ItemArray[6].ToString();
                txtDepto.Text = dt.Rows[0].ItemArray[7].ToString();
                txtTelFijo.Text = dt.Rows[0].ItemArray[8].ToString();
                txtTelCelular.Text = dt.Rows[0].ItemArray[9].ToString();
                txtEmail.Text = dt.Rows[0].ItemArray[10].ToString();
            }
            else
            {
                lblValidacion.Text = "NO EXISTE NINGUN CLIENTE REGISTRADO CON EL CÓDIGO: " + txtCodigoCliente.Text;
            }
        }


     

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dlgCliente dlg = new dlgCliente();
            dlg.Text = "CLIENTES - LISTADO DE CLIENTES";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtidCliente.Text = dlg.cliid.ToString();
                txtCodigoCliente.Text = dlg.clicodigo.ToString();

            }

        }

        private void ObtenerProducto(int prdid)
        {
            DataTable dt = new DataTable();
            dt = Productos.GetProductoNombrePorId(prdid);
            if (dt.Rows.Count > 0)
            {
                txtNombreProd.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                lblValidacion.Text = "EL PRODUCTO NO EXISTE REGISTRADO EN EL SISTEMA.";
                txtProducto.Focus();
            }
        }


        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigoCliente.Text != string.Empty)
            {
                BuscarDatosCliente(Convert.ToInt32(txtCodigoCliente.Text));
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            dlgProducto dlg = new dlgProducto(Convert.ToInt32(cmbProveedor.SelectedValue));
            dlg.Text = "PRODUCTOS - LISTADO DE PRODUCTOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtidProd.Text = dlg.prdid.ToString();
                txtProducto.Text = dlg.prdcodigo.ToString();
                

            }
        }

        private Boolean ValidarDatos()
        {
            bool res = false;
            if (txtRemito.Text != string.Empty)
            {
                if (txtNombre.Text != string.Empty)
                {
                    if (dgvDetalle.Rows.Count > 0)
                    {
                        if (txtRemito.TextLength == 8)
                        {
                            res = true;
                        }
                        else
                        {
                            res = false;
                            lblValidacion.Text = "FORMATO DE N° DE REMITO INVALIDO.";
                            txtRemito.Focus();
                        }
                        
                    }
                    else
                    {
                        res = false;
                        lblValidacion.Text = "DEBE SELECCIONAR AL MENOS UN PRODUCTO.";
                        txtProducto.Focus();
                    }


                }
                else
                {
                    res = false;
                    lblValidacion.Text = "DEBE SELECCIONAR EL CLIENTE.";
                    txtCodigoCliente.Focus();
                }
            }
            else
            {
                res = false;
                lblValidacion.Text = "DEBE COMPLETAR EL CAMPO NÚMERO DE REMITO.";
                txtRemito.Focus();
            }
            return res;
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text != string.Empty)
            {
                ObtenerProducto(Convert.ToInt32(txtidProd.Text));
            }
        }

        private void frmNuevoService_Load(object sender, EventArgs e)
        {
            IniciarControles();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    if (ValidarDatos() == true)
                    {
                        Service ser = new Service();
                        //ser.cliid = Convert.ToInt32(txtidCliente.Text);
                        //ser.essid = 1;
                        //ser.proid = Convert.ToInt32(cmbProveedor.SelectedValue);
                        //ser.serremito = txtRemito.Text;
                        //ser.sucid = Convert.ToInt32(cmbSucursal.SelectedValue);
                        ser.serfecha = DateTime.Today.Date;
                        ser.serfechacompra = dtpFechaCompra.Value;

                        if (ckbRemito.Checked == true)
                        {
                            ser.serfotocopiaremito = "SI";
                        }
                        else
                        {
                            ser.serfotocopiaremito = "NO";
                        }
                        if (ckbFactura.Checked == true)
                        {
                            ser.serfotocopiafactura = "SI";
                        }
                        else
                        {
                            ser.serfotocopiafactura = "NO";
                        }
                        if (ckbGarantia.Checked == true)
                        {
                            ser.serfajagarantia = "SI";
                        }
                        else
                        {
                            ser.serfajagarantia = "NO";
                        }
                        if (ckbFabricacion.Checked == true)
                        {
                            ser.sercertfabricacion = "SI";
                        }
                        else
                        {
                            ser.sercertfabricacion = "NO";
                        }

                        int resultado = 0;
                        //resultado = Services.ServiceInsertar(ser);
                        ser.serid = resultado;
                        if (resultado > 0)
                        {
                            ServiceDetalle sde = new ServiceDetalle();
                            sde.serid = ser.serid;
                            bool res = false;
                            int resdet = 0;
                            foreach (DataGridViewRow dr in dgvDetalle.Rows)
                            {
                                sde.prdid = Convert.ToInt32(dr.Cells[0].Value);
                                sde.sdecantidad = Convert.ToInt32(dr.Cells[3].Value);
                                sde.sdemotivo = dr.Cells[4].Value.ToString();
                                resdet = ServicesDetalle.ServiceDetalleInsertar(sde);
                                if (resdet == 0)
                                {
                                    res = true;
                                    break;
                                }

                            }
                            if (res != true)
                            {

                                scope.Complete();
                                MessageBox.Show("REGISTRADO CORRECTAMENTE.", "SERVICES - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                frmReporteService frm = new frmReporteService(ser.serid);
                                string fmt = "000000.##";
                                frm.Text = "REPORTE - REPORTE DE SERVICE N° " + ser.serid.ToString(fmt);
                                frm.ShowDialog();
                                IniciarControles();

                            }
                            else
                            {
                                MessageBox.Show("OCURRIO UN ERROR AL REGISTRAR EL SERVICE.", "SERVICE - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                IniciarControles();
                            }

                        }
                        else
                        {

                        }


                        

                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void LimpiarControlesProducto()
        {
            txtProducto.Text = string.Empty;
            txtNombreProd.Text = string.Empty;
            txtMotivo.Text = string.Empty;
            txtCantidad.Text = string.Empty;

            txtProducto.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombreProd.Text != string.Empty)
            {
                if (txtCantidad.Text != string.Empty)
                {
                    if (txtProducto.Text != string.Empty)
                    {
                        if (txtMotivo.Text != string.Empty)
                        {

                            dgvDetalle.Rows.Add(txtidProd.Text, txtProducto.Text, txtNombreProd.Text, txtCantidad.Text, txtMotivo.Text);
                            LimpiarControlesProducto();
                        }
                        else
                        {
                            lblValidacion.Text = "DEBE INDICAR LA FALLA DEL PRODUCTO.";
                            txtMotivo.Focus();
                        }
                        
                    }
                    else
                    {
                        lblValidacion.Text = "DEBE INDICAR EL CÓDIGO DE PRODUCTO.";
                        txtProducto.Focus();
                    }
                }
                else
                {
                    lblValidacion.Text = "DEBE INDICAR LA CANTIDAD.";
                    txtCantidad.Focus();
                }
            }
            else
            {
                lblValidacion.Text = "DEBE SELECCIONAR AL MENOS UN PRODUCTO.";
                txtNombreProd.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO CANTIDAD.";
                e.Handled = true;
                txtCantidad.Focus();
                return;
            }
        }

        private void txtRemito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO N° REMITO.";
                e.Handled = true;
                txtRemito.Focus();
                return;
            }
        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO CODIGO CLIENTE.";
                e.Handled = true;
                txtCodigoCliente.Focus();
                return;
            }
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO PRODUCTO.";
                e.Handled = true;
                txtProducto.Focus();
                return;
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dlgCliente dlg = new dlgCliente();
            dlg.Text = "CLIENTES - LISTADO DE CLIENTES";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtidCliente.Text = dlg.cliid.ToString();
                txtCodigoCliente.Text = dlg.clicodigo.ToString();

            }
        }

        private void btnBuscar_Click_2(object sender, EventArgs e)
        {
            dlgCliente dlg = new dlgCliente();
            dlg.Text = "CLIENTES - LISTADO DE CLIENTES";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtidCliente.Text = dlg.cliid.ToString();
                txtCodigoCliente.Text = dlg.clicodigo.ToString();

            }
        }

        private void txtCodigoCliente_TextChanged_1(object sender, EventArgs e)
        {
            if (txtCodigoCliente.Text != string.Empty)
            {
                BuscarDatosCliente(Convert.ToInt32(txtCodigoCliente.Text));
            }
        }
    }
}
