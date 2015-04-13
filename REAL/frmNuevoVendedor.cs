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
    public partial class frmNuevoVendedor : Form
    {
        public string tipomovimiento { get; set; }

        public frmNuevoVendedor()
        {
            InitializeComponent();
        }

        public frmNuevoVendedor(string mov)
        {
            tipomovimiento = mov;

            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefonoCelular.Text = string.Empty;
            txtTelefonoFijo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbEstado.SelectedIndex = 0;

            txtCodigo.Visible = false;
            label7.Visible = false;
        }

        private void IniciarModificar()
        {
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefonoCelular.Text = string.Empty;
            txtTelefonoFijo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbEstado.SelectedIndex = 0;

           
        }

        private void CargarComboEstado()
        {
            cmbEstado.ValueMember = "estid";
            cmbEstado.DisplayMember = "estestado";
            cmbEstado.DataSource = Estados.GetTodos();
        }

        private Boolean ValidarControles()
        {
            bool resultado = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtNombre, "Debe completar el campo nombre y apellido.");
            }

            return resultado;
        }


        private void frmNuevoVendedor_Load(object sender, EventArgs e)
        {
            CargarComboEstado();
            IniciarControles();

            if (tipomovimiento == "MODIFICAR")
            {
                txtCodigo.Visible = true;
                label7.Visible = true;
                txtCodigo.Focus();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarControles() == true)
            {
                if (tipomovimiento == "NUEVO")
                {
                    Insertar();
                }
                else
                {
                    Actualizar();
                }
                
            }
        }

        private void Insertar()
        {
            try
            {
                Vendedor vendedor = new Vendedor();
                vendedor.estado = (Estado)cmbEstado.SelectedItem;
                vendedor.vendedor_direccion = txtDireccion.Text;
                vendedor.vendedor_email = txtEmail.Text;
                vendedor.vendedor_nombre = txtNombre.Text;
                vendedor.vendedor_telefonocelular = txtTelefonoCelular.Text;
                vendedor.vendedor_telefonofijo = txtTelefonoFijo.Text;

                vendedor = Vendedores.Crear(vendedor);
                if (vendedor != null)
                {
                    MessageBox.Show("El vendedor se registro con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniciarControles();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al registrar el vendedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IniciarControles();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Actualizar()
        {
            try
            {
                Vendedor vendedor = new Vendedor();
                vendedor.vendedor_id = Convert.ToInt32(txtCodigo.Text);
                vendedor.vendedor_nombre = txtNombre.Text;
                vendedor.vendedor_direccion = txtDireccion.Text;
                vendedor.vendedor_email = txtEmail.Text;
                vendedor.vendedor_telefonocelular = txtTelefonoCelular.Text;
                vendedor.vendedor_telefonofijo = txtTelefonoFijo.Text;
                vendedor.estado = (Estado)cmbEstado.SelectedItem;

                bool resultado = Vendedores.Actualizar(vendedor);
                if (resultado == true)
                {
                    MessageBox.Show("El vendedor se actualizo con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                    IniciarModificar();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al actualizar el vendedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarControles();
                    IniciarModificar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ObtenerDatosVendedor(int vendedor_id)
        {
            errorProvider1.Clear();
            try
            {
                Vendedor vendedor = new Vendedor();
                vendedor = Vendedores.GetPorId(vendedor_id);
                if (vendedor != null)
                {
                    txtCodigo.Text = String.Format("{0:000}", vendedor.vendedor_id);
                    txtNombre.Text = vendedor.vendedor_nombre;
                    txtDireccion.Text = vendedor.vendedor_direccion;
                    txtTelefonoFijo.Text = vendedor.vendedor_telefonofijo;
                    txtTelefonoCelular.Text = vendedor.vendedor_telefonocelular;
                    txtEmail.Text = vendedor.vendedor_email;
                    cmbEstado.Text = vendedor.estado.estestado;
                }
                else
                {
                    errorProvider1.SetError(txtCodigo, "El vendedor no existe registrado en el sistema");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                errorProvider1.SetError(txtCodigo, "Solo se permiten números en el campo código");              
                e.Handled = true;
                return;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != string.Empty && txtCodigo.TextLength == 3 && Convert.ToInt32(txtCodigo.Text) != 0)
            {
                ObtenerDatosVendedor(Convert.ToInt32(txtCodigo.Text));
            }
            else
            {
                errorProvider1.SetError(txtCodigo, "El código ingresado es incorrecto");
                LimpiarControles();
            }
        }

        private void LimpiarControles()
        {
            txtDireccion.Text = string.Empty;
            txtTelefonoFijo.Text = string.Empty;
            txtTelefonoCelular.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbEstado.SelectedIndex = 0;
            txtNombre.Text = string.Empty;
        }
    }
}
