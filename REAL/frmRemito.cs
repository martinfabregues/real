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
    public partial class frmRemito : Form
    {
        public List<RemitoProveedorDetalle> detalle = new List<RemitoProveedorDetalle>();
        public frmRemito()
        {
            InitializeComponent();
        }

        private void frmRemito_Load(object sender, EventArgs e)
        {
            IniciarControles();
            GetProveedores();
            GetDepositos();
        }

        private Boolean ValidarForm()
        {
            bool resultado = true;
            errorProvider1.Clear();
            string cadena = txtRemito.Text;
            cadena = cadena.Replace("-", "");

            if(txtRemito.MaskFull == false)
            {
                resultado = false;            
                errorProvider1.SetError(txtRemito, "Debe completar el campo Nro. Remito.");
                return resultado;
            }

            if(dgvDetalle.Rows.Count <= 0)
            {
                resultado = false;
                errorProvider1.SetError(btnBuscar, "Debe agregar un detalle al remito.");
                return resultado;
            }


            return resultado;
        }


        private void IniciarControles()
        {
            txtNroOrden.Enabled = false;
            txtIdOrden.Visible = false;
            txtid.Visible = false;
            txtProducto.Enabled = false;
            txtOrden.Visible = false;
            txtCoeficiente.Visible = false;
            txtMetros.Visible = false;
            txtFecha.Visible = false;

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void GetProveedores()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.FindAll();
        }

        private void GetDepositos()
        {
            cmbSucursal.ValueMember = "sucid";
            cmbSucursal.DisplayMember = "sucnombre";
            cmbSucursal.DataSource = Sucursales.GetTodos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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
                        errorProvider1.SetError(btnBuscar, "El producto seleccionado no corresponde al proveedor.");
                        txtOrden.Focus();
                    }
                }
                else
                {
                    errorProvider1.SetError(btnBuscar, "El producto selecccionado no es correcto.");
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                ObtenerProducto(Convert.ToInt32(txtCodigo.Text));
            }
        }


        private void ObtenerProducto(int prdid)
        {
            DataTable dt = new DataTable();
            dt = Productos.GetProductoObtenerPorId(prdid);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["proid"]) == Convert.ToInt32(cmbProveedor.SelectedValue))
                {
                    txtProducto.Text = dt.Rows[0].ItemArray[1].ToString();                   
                }
                else
                {
                    //errorProvider1.SetError(txtOrden, "EL PRODUCTO SELECCIONADO NO CORRESPONDE AL PROVEEDOR.");
                    txtOrden.Focus();
                }
            }
            else
            {

                txtProducto.Focus();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtCodigo.Text != string.Empty)
            {
                if (txtProducto.Text != string.Empty)
                {
                    if (txtCantidad.Text != string.Empty)
                    {
                        if (txtIdOrden.Text != string.Empty)
                        {

                            if (txtNroOrden.Text != string.Empty)
                            {

                                dgvDetalle.Rows.Add(txtid.Text, "", txtCodigo.Text, txtProducto.Text, txtCantidad.Text, txtNroOrden.Text, txtIdOrden.Text, txtFecha.Text, txtMetros.Text);
                                txtCodigo.Text = string.Empty;
                                txtCantidad.Text = string.Empty;
                                txtOrden.Text = string.Empty;
                                txtIdOrden.Text = string.Empty;
                                txtProducto.Text = string.Empty;
                            }
                            else
                            {
                                errorProvider1.SetError(btnBuscar, "Debe seleccionar una orden de compra");
                                txtOrden.Focus();
                            }

                        }
                        else
                        {
                            errorProvider1.SetError(btnBuscar, "Debe seleccionar una orden de compra");
                            txtOrden.Focus();
                        }
                       
                    }
                    else
                    {

                        errorProvider1.SetError(txtCantidad, "Debe completar el campo cantidad");
                        txtCantidad.Focus();
                    }
                }
                else
                {
                    errorProvider1.SetError(txtProducto, "Debe completar el campo producto");
                    txtProducto.Focus();
                }
            }
            else
            {
                errorProvider1.SetError(txtCodigo, "Debe completar el campo código");
                txtCodigo.Focus();
            }
        }


        private void CrearDetalle()
        {
            detalle.Clear();
          
            foreach(DataGridViewRow row in dgvDetalle.Rows)
            {
                RemitoProveedorDetalle fila = new RemitoProveedorDetalle();
                fila.producto_id = Convert.ToInt32(row.Cells[0].Value);
                fila.orden_id = Convert.ToInt32(row.Cells[6].Value);
                fila.cantidad = Convert.ToInt32(row.Cells[4].Value);
                detalle.Add(fila);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            InsertarRemito();
        }

        private void InsertarRemito()
        {
            if (ValidarForm() == true)
            {
                RemitoProveedor remito = new RemitoProveedor();
                remito.activo = 1;
                remito.fechaemision = dtpFecha.Value;
                remito.fecharecepcion = dtpRecepcion.Value;
                remito.numero = txtRemito.Text;
                remito.observaciones = txtObservacion.Text;
                remito.proveedor_id = Convert.ToInt32(cmbProveedor.SelectedValue);
                remito.sucursal_id = Convert.ToInt32(cmbSucursal.SelectedValue);
                CrearDetalle();
                remito.detalle = detalle;

                DialogResult result = MessageBox.Show("Se va a registrar el remito, corrobore los datos.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    int resultado = RemitosProveedor.AddRemito(remito);
                    if (resultado > 0)
                    {
                        MessageBox.Show("El remito se registro correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarControles();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al registrar el remito. Intente Nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LimpiarControles()
        {
            txtFecha.Text = string.Empty;
            txtid.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtCoeficiente.Text = string.Empty;
            txtIdOrden.Text = string.Empty;
            txtMetros.Text = string.Empty;
            txtNroOrden.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            txtOrden.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtRemito.Text = string.Empty;
            detalle.Clear();
            dgvDetalle.Rows.Clear();
            cmbProveedor.SelectedIndex = 0;
            cmbSucursal.SelectedIndex = 0;
        }

    }
}
