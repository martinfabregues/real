using DAL;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmNuevoProducto : Form
    {
        public string tmov { get; set; }
        public frmNuevoProducto(string tM)
        {
            tmov = tM;
            InitializeComponent();
        }

        private void LimpiarControles()
        {
            txtCodigo.Text = string.Empty;
            
            txtCosto.Text = string.Empty;
            txtDenominacion.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtGarantia.Text = string.Empty;
            txtMargen.Text = string.Empty;
            txtIva.Text = string.Empty;
            
            txtIva.Text = string.Empty;
            txtMargen.Text = string.Empty;
           
            txtPrecioVenta.Text = string.Empty;
            txtPrecioVenta.Enabled = false;
            txtNeto.Text = string.Empty;
            txtMetros.Text = string.Empty;

        }

        private void IniciarControlesModificar()
        {
            Bitmap img = new Bitmap(Properties.Resources.search, new Size(16, 16));
            btnBuscar.Image = img;
            txtCodigo.Visible = true;
            btnBuscar.Visible = true;
         
            btnAceptar.Text = "Modificar";
            cmbProveedor.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
           
            txtMetros.Text = "1.00";
            txtPrecioVenta.Enabled = false;
            txtNeto.Enabled = false;

            txtIngBrutos.Text = string.Empty;
            txtFlete.Text = string.Empty;
            txtNeto.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            txtMetros.Text = string.Empty;

          
            txtId.Visible = false;          
            LimpiarControles();
        }

        private void IniciarControles()
        {
            txtCosto.Text = string.Empty;
            txtDenominacion.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtGarantia.Text = string.Empty;
            txtMargen.Text = string.Empty;
            txtIva.Text = string.Empty;
           
            txtIva.Text = string.Empty;
            txtMargen.Text = string.Empty;
            txtNeto.Enabled = true;

            cmbProveedor.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            txtMargen.Text = "1.00";

            txtCosto.Text = string.Empty;
            txtMetros.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;

            txtIva.Text = "1.21";
          
            txtMetros.Text = "1.00";


            txtCodigo.Enabled = false;
            
            
            btnBuscar.Enabled = false;
            txtId.Visible = false;

            txtFlete.Text = string.Empty;
            txtIngBrutos.Text = string.Empty;
        }

        private void CargarComboListaPrecio(Proveedor proveedor)
        {
            cmbListaPrecio.DataSource = null;

            cmbListaPrecio.ValueMember = "listaprecio_id";
            cmbListaPrecio.DisplayMember = "listaprecio_denominacion";
            List<ListaPrecio> list = ListasPrecio.GetTodosPorIdProveedorVigenteActiva(proveedor, DateTime.Now);
            if (list.Count > 0)
            {
                cmbListaPrecio.DataSource = list;
            }
            else
            {
                cmbListaPrecio.Items.Add("NO HAY LISTAS ASOCIADAS AL PROVEEDOR");
                cmbListaPrecio.SelectedIndex = 0;
            }
        }

        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetTodos();
            cmbProveedor.SelectedIndex = 0;
        }

        private void CargarComboBoxCategoria()
        {
            cmbCategoria.ValueMember = "catid";
            cmbCategoria.DisplayMember = "catnombre";
            cmbCategoria.DataSource = Categorias.GetTodos();
            cmbCategoria.SelectedIndex = 0;
        }

        private void CargarComboBoxMarca(int proid)
        {
            cmbMarca.ValueMember = "marid";
            cmbMarca.DisplayMember = "mardenominacion";
            cmbMarca.DataSource = Marcas.GetPorIdProveedor(proid);
            cmbMarca.SelectedIndex = 0;

        }

        private void CargarComboBoxEstado()
        {
            cmbEstado.ValueMember = "estid";
            cmbEstado.DisplayMember = "estestado";
            cmbEstado.DataSource = Estados.GetTodos();
            cmbEstado.SelectedIndex = 0;
        }

        private void frmNuevoProducto_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;

            CargarComboBoxCategoria();
            CargarComboBoxEstado();
            CargarComboBoxProveedor();
       

            if (tmov == "ALTA")
            {
                IniciarControles();
            }
            else
            {
                if (tmov == "MODIFICAR")
                {
                    IniciarControlesModificar();
                }
            }
            
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbProveedor.SelectedIndex > -1)
            {
                CargarComboBoxMarca(Convert.ToInt32(cmbProveedor.SelectedValue));

                Proveedor proveedor = (Proveedor)cmbProveedor.SelectedItem;
                CargarComboListaPrecio(proveedor);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean ValidarDatos()
        {
            bool result = true;
            errorProvider1.Clear();

            if (String.IsNullOrEmpty(txtDenominacion.Text))
            {
                result = false;
                errorProvider1.SetError(txtDenominacion, "Debe completar el campo denominación.");
               
                txtDenominacion.Focus();
            }

            if (string.IsNullOrEmpty(txtGarantia.Text))
            {
                result = false;
                errorProvider1.SetError(txtGarantia, "Debe completar el campo garantia.");
                
                txtGarantia.Focus();
            }

            if (string.IsNullOrEmpty(txtCosto.Text))
            {
                result = false;
                errorProvider1.SetError(txtCosto, "Debe completar el campo costo.");
              
                txtCosto.Focus();
            }

            if (string.IsNullOrEmpty(txtMargen.Text))
            {
                result = false;
                errorProvider1.SetError(txtMargen, "Debe completar el campo margen.");
               
                txtMargen.Focus();
            }

            if (string.IsNullOrEmpty(txtIva.Text))
            {
                result = false;
                errorProvider1.SetError(txtIva, "Debe completar el campo iva.");
               
                txtIva.Focus();
            }

            if (String.IsNullOrEmpty(txtNeto.Text))
            {
                result = false;
                errorProvider1.SetError(txtNeto, "Debe completar el campo costo neto.");
            }

            if ((ListaPrecio)cmbListaPrecio.SelectedItem == null)
            {
                result = false;
                errorProvider1.SetError(cmbListaPrecio, "Debe seleccionar una lista de precio.");
            }

            if (string.IsNullOrEmpty(txtFlete.Text))
            {
                result = false;
                errorProvider1.SetError(txtFlete, "Debe completar el campo flete.");
            }
            if (string.IsNullOrEmpty(txtIngBrutos.Text))
            {
                result = false;
                errorProvider1.SetError(txtIngBrutos, "Debe completar el campo ing. brutos.");
            }


            return result;
        }

        private void InsertarProducto()
        {
            try
            {
                Producto producto = new Producto();
                producto.catid = Convert.ToInt32(cmbCategoria.SelectedValue);
                producto.estid = Convert.ToInt32(cmbEstado.SelectedValue);
                producto.marid = Convert.ToInt32(cmbMarca.SelectedValue);
                producto.prdcosto = Convert.ToDecimal(txtCosto.Text);
                producto.prddenominacion = txtDenominacion.Text;
                producto.prddescripcion = txtDescripcion.Text;
                producto.prdfecharegistro = DateTime.Today.Date;
                producto.prdgarantia = Convert.ToInt32(txtGarantia.Text);
                producto.prdmargen = Convert.ToDecimal(txtMargen.Text);
                producto.proid = Convert.ToInt32(cmbProveedor.SelectedValue);
                producto.prdiva = Convert.ToDecimal(txtIva.Text);

                if (!string.IsNullOrEmpty(txtMetros.Text))
                    producto.prdmetros = Convert.ToDecimal(txtMetros.Text);
                else
                    producto.prdmetros = (Decimal)1.00;

                producto.proveedor = Proveedores.GetPorId(Convert.ToInt32(cmbProveedor.SelectedValue));
                producto.estado = Estados.GetPorId(Convert.ToInt32(cmbEstado.SelectedValue));
                producto.categoria = CategoriaDAL.GetPorId(Convert.ToInt32(cmbCategoria.SelectedValue));
                producto.marca = MarcaDAL.GetPorId(Convert.ToInt32(cmbMarca.SelectedValue));

                producto.prdflete = Convert.ToDouble(txtFlete.Text);
                producto.prdingbrutos = Convert.ToDouble(txtIngBrutos.Text);

                ListaPrecioProducto listaproducto = new ListaPrecioProducto();
                listaproducto.listaprecio = (ListaPrecio)cmbListaPrecio.SelectedItem;
                listaproducto.listaprecioproducto_costobruto = Convert.ToDouble(txtCosto.Text);
                listaproducto.listaprecioproducto_costoneto = Convert.ToDouble(txtNeto.Text);
                listaproducto.listaprecioproducto_precioventa = Convert.ToDouble(txtPrecioVenta.Text);

                //INSERTAR PRODUCTO / VER LISTA DE PRECIO   

                producto = Productos.Create(producto, listaproducto);
                if (producto != null)
                {
                    string fmt = "000000.##";
                    MessageBox.Show("El producto se registro con exito, con el código: " + producto.prdid.ToString(fmt), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniciarControles();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al registrar el producto.", "Imformación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IniciarControles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
      
        private void ModificarProducto()
        {
            try
            {

                Producto producto = new Producto();
                producto.prdid = Convert.ToInt32(txtId.Text);
                producto.catid = Convert.ToInt32(cmbCategoria.SelectedValue);
                producto.estid = Convert.ToInt32(cmbEstado.SelectedValue);
                producto.marid = Convert.ToInt32(cmbMarca.SelectedValue);
                producto.prdcosto = Convert.ToDecimal(txtCosto.Text);
                producto.prddenominacion = txtDenominacion.Text;
                producto.prddescripcion = txtDescripcion.Text;
                producto.prdfecharegistro = DateTime.Today.Date;
                producto.prdgarantia = Convert.ToInt32(txtGarantia.Text);
                producto.prdmargen = Convert.ToDecimal(txtMargen.Text);
                producto.proid = Convert.ToInt32(cmbProveedor.SelectedValue);
                producto.prdiva = Convert.ToDecimal(txtIva.Text);
                producto.prdmetros = Convert.ToDecimal(txtMetros.Text);

                producto.prdflete = Convert.ToDouble(txtFlete.Text);
                producto.prdingbrutos = Convert.ToDouble(txtIngBrutos.Text);

                producto.proveedor = Proveedores.GetPorId(Convert.ToInt32(cmbProveedor.SelectedValue));
                producto.estado = Estados.GetPorId(Convert.ToInt32(cmbEstado.SelectedValue));
                producto.categoria = CategoriaDAL.GetPorId(Convert.ToInt32(cmbCategoria.SelectedValue));
                producto.marca = MarcaDAL.GetPorId(Convert.ToInt32(cmbMarca.SelectedValue));

                ListaPrecioProducto listaproducto = new ListaPrecioProducto();
                listaproducto.listaprecio = (ListaPrecio)cmbListaPrecio.SelectedItem;
                listaproducto.listaprecioproducto_costobruto = Convert.ToDouble(txtCosto.Text);
                listaproducto.listaprecioproducto_costoneto = Convert.ToDouble(txtNeto.Text);
                listaproducto.listaprecioproducto_precioventa = Convert.ToDouble(txtPrecioVenta.Text);


                bool resultado;
                resultado = Productos.Update(producto, listaproducto);
                if (resultado != false)
                {
                    string fmt = "000000.##";
                    MessageBox.Show("El producto " + producto.prdid.ToString(fmt) + " se actualizo con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniciarControlesModificar();
                    LimpiarControles();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al actualizar el producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IniciarControlesModificar();
                    LimpiarControles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == true)
            {
                if (tmov == "ALTA")
                {
                    DialogResult result = MessageBox.Show("Se va a registrar el producto, esta seguro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        InsertarProducto();
                    }
                }
                else
                {

                    DialogResult result = MessageBox.Show("Se va a modificar el producto, esta seguro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        ModificarProducto();
                    }

                }
            }
        }

        private void txtGarantia_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
               
                errorProvider1.SetError(txtGarantia, "Solo se permiten números en el campo garantía.");
                e.Handled = true;
                txtGarantia.Focus();
                return;
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                
                errorProvider1.SetError(txtCosto, "Solo se permiten números en el campo costo.");
                e.Handled = true;
                txtCosto.Focus();
                return;
            }
        }

        private void txtMargen_KeyPress(object sender, KeyPressEventArgs e)
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
                errorProvider1.SetError(txtMargen, "Solo se permiten números en el campo margen.");
                e.Handled = true;
            }
        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
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
                errorProvider1.SetError(txtMargen, "Solo se permiten números en el campo iva.");
                e.Handled = true;
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbProducto.SelectedIndex > -1)
            //{
            //    txtId.Text = cmbProducto.SelectedValue.ToString();
            //}
        }

        private void cmbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = e.KeyChar.ToString().ToUpper();
            char[] ch = str.ToCharArray();
            e.KeyChar = ch[0];
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LimpiarControles();

            dlgProducto dlg = new dlgProducto(Convert.ToInt32(cmbProveedor.SelectedValue));
            dlg.Text = "PRODUCTOS - LISTADO DE PRODUCTOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.prdid != 0 && dlg.prdcodigo != null)
            {
                txtId.Text = dlg.prdid.ToString();
                txtCodigo.Text = dlg.prdcodigo.ToString();

            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                ObtenerProductoPorCodigo(txtCodigo.Text);
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            {
                ObtenerProducto(Convert.ToInt32(txtId.Text));
            }
        }

        private void ObtenerProductoPorCodigo(string prdcodigo)
        {
           
            errorProvider1.Clear();           

            Producto producto = Productos.GetPorCodigo(prdcodigo);
            if (producto != null)
            {
                txtId.Text = producto.prdid.ToString(); ;
                if (string.IsNullOrEmpty(txtMetros.Text))
                {
                    txtMetros.Text = "1.00";
                }

                

            }
            else
            {
               
                errorProvider1.SetError(btnBuscar, "El producto no existe registrado en el sistema.");
            }
            
           
        }

        //LISTO
        private void ObtenerProducto(int prdid)
        {
            errorProvider1.Clear();           
            Producto producto = new Producto();
            producto = Productos.GetPorId(prdid);
            if (producto != null)
            {
                cmbProveedor.Text = producto.proveedor.pronombre;
                cmbCategoria.Text = producto.categoria.catnombre;
                cmbMarca.Text = producto.marca.mardenominacion;
                txtDenominacion.Text = producto.prddenominacion;
                txtDescripcion.Text = producto.prddescripcion;
                txtGarantia.Text = producto.prdgarantia.ToString();
                //txtCosto.Text = producto.prdcosto.ToString();
                txtMargen.Text = producto.prdmargen.ToString();
                txtIva.Text = producto.prdiva.ToString();
                txtMetros.Text = producto.prdmetros.ToString();
                cmbEstado.Text = producto.estado.estestado;
                txtFlete.Text = producto.prdflete.ToString();
                txtIngBrutos.Text = producto.prdingbrutos.ToString();

                if (txtMetros.Text == string.Empty)
                {
                    txtMetros.Text = "1.00";
                }

                ObtenerCostoProducto(producto, (ListaPrecio)cmbListaPrecio.SelectedItem);

                ObtenerBonificacionesPorProducto(Convert.ToInt32(txtId.Text));


             
            }
            else
            {
                errorProvider1.SetError(btnBuscar, "El producto no se encuentra registrado en el sistema.");
            }
          
        }

        private void ObtenerCostoProducto(Producto producto, ListaPrecio listaprecio)
        {
            try
            {
                ListaPrecioProducto listaproducto = ListasPrecioProducto.GetListaProducto(listaprecio, producto);
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
        private void ObtenerBonificacionesPorProducto(int prdid)
        {
           
            try
            {
                List<BonificacionProducto> list = BonificacionesProducto.GetPorProducto(prdid);
               
                if (list.Count > 0)
                {
                    double total = Convert.ToDouble(txtCosto.Text);
                    foreach (BonificacionProducto bonificacionproducto in list)
                    {
                      
                        total = Math.Round(total * Convert.ToDouble(bonificacionproducto.bonificacion.bondescuento), 2);
                    }

                    txtNeto.Text = total.ToString();
                }
                else
                {
                    txtNeto.Text = txtCosto.Text;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmNuevoProducto_Resize(object sender, EventArgs e)
        {
            //groupBox1.Width = this.Width - 40;
            //groupBox2.Width = this.Width - 40;
            //groupBox2.Height = this.Height - 500;
            //btnAceptar.Location = new Point(20, this.Height - 100);
            //btnCancelar.Location = new Point(this.Width - 110, this.Height - 100);
        }

        //SOLO NUMEROS Y PUNTO DECIMAL
        private void txtMetros_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
               
                errorProvider1.SetError(txtMetros, "Solo se permiten números en el campo metros.");
                e.Handled = true;
                txtMetros.Focus();
                return;
            }
        }

        private void cmbProducto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void CalcularPrecioVenta()
        {
            if (txtNeto.Text != string.Empty && txtIva.Text != string.Empty && txtMargen.Text != string.Empty && txtFlete.Text != string.Empty && txtIngBrutos.Text != string.Empty)
            {
                txtPrecioVenta.Text = Math.Round(((Convert.ToDouble(txtNeto.Text) * Convert.ToDouble(txtIva.Text)) * Convert.ToDouble(txtMargen.Text)) * Convert.ToDouble(txtFlete.Text) * Convert.ToDouble(txtIngBrutos.Text), 0).ToString();
            }
        }

        private void cmbProveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void txtNeto_TextChanged(object sender, EventArgs e)
        {
            if (txtNeto.Text != string.Empty)
            {
                CalcularPrecioVenta();
            }
        }

        private void txtIva_TextChanged(object sender, EventArgs e)
        {
            if (txtIva.Text != string.Empty && txtNeto.Text != string.Empty)
            {
                CalcularPrecioVenta();
            }
        }

        private void txtMargen_TextChanged(object sender, EventArgs e)
        {
            if (txtNeto.Text != string.Empty && txtIva.Text != string.Empty && txtMargen.Text != string.Empty && txtFlete.Text != string.Empty && txtIngBrutos.Text != string.Empty)
            {
                CalcularPrecioVenta();
            }
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            //if (txtCosto.Text != string.Empty && txtId.Text != string.Empty)
            //{
            //    ObtenerBonificacionesPorProducto(Convert.ToInt32(txtId.Text));
            //}
        }

        private void txtNeto_KeyPress(object sender, KeyPressEventArgs e)
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
                errorProvider1.SetError(txtNeto, "Solo se permiten números en el campo costo neto.");
                e.Handled = true;
            }
        }

        private void txtCosto_Leave(object sender, EventArgs e)
        {
            if (txtCosto.Text != string.Empty && txtId.Text != string.Empty)
            {
                ObtenerBonificacionesPorProducto(Convert.ToInt32(txtId.Text));
            }
            if (txtCosto.Text != string.Empty && txtId.Text == string.Empty)
            {
                txtNeto.Text = txtCosto.Text;
            }
        }

        private void txtFlete_TextChanged(object sender, EventArgs e)
        {
            if (txtNeto.Text != string.Empty && txtIva.Text != string.Empty && txtMargen.Text != string.Empty && txtFlete.Text != string.Empty && txtIngBrutos.Text != string.Empty)
            {
                CalcularPrecioVenta();
            }
        }

        private void txtIngBrutos_TextChanged(object sender, EventArgs e)
        {
            if (txtNeto.Text != string.Empty && txtIva.Text != string.Empty && txtMargen.Text != string.Empty && txtFlete.Text != string.Empty && txtIngBrutos.Text != string.Empty)
            {
                CalcularPrecioVenta();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



    }
}
