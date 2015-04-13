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
    public partial class frmNuevoCliente : Form
    {
        private string tipomovimiento;

        public frmNuevoCliente()
        {
            InitializeComponent();          
        }

        public frmNuevoCliente(string tm)
        {
            tipomovimiento = tm;
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtCalle.Text = string.Empty;
            txtDepto.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtPiso.Text = string.Empty;
            txtTelefonoCelular.Text = string.Empty;
            txtTelefonoFijo.Text = string.Empty;
            txtBarrio.Text = string.Empty;
            cmbCiudad.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            cmbTipoIva.SelectedIndex = 0;
            txtCodigo.Visible = false;
            btnBuscar.Visible = false;
            label14.Visible = false;
        }

        private void IniciarControlesModificar()
        {
            txtCalle.Text = string.Empty;
            txtDepto.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtPiso.Text = string.Empty;
            txtTelefonoCelular.Text = string.Empty;
            txtTelefonoFijo.Text = string.Empty;
            txtBarrio.Text = string.Empty;
            cmbCiudad.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            cmbTipoIva.SelectedIndex = 0;
            txtCodigo.Text = string.Empty;
            lblTitulo.Text = "MODIFICAR DATOS DE CLIENTE";

        }

        private void CargarComboBoxEstado()
        {
            cmbEstado.ValueMember = "estid";
            cmbEstado.DisplayMember = "estestado";
            cmbEstado.DataSource = Estados.GetTodos();
            cmbEstado.SelectedIndex = 0;
        }

        private void CargarComboBoxTipoIva()
        {
            cmbTipoIva.ValueMember = "tpiid";
            cmbTipoIva.DisplayMember = "tpitipo";
            cmbTipoIva.DataSource = TiposIva.GetTodos();
            cmbTipoIva.SelectedIndex = 0;
        }

        private void CargarComboBoxCiudad()
        {
            cmbCiudad.ValueMember = "ciuid";
            cmbCiudad.DisplayMember = "ciunombre";
            cmbCiudad.DataSource = Ciudades.GetTodo();
            cmbCiudad.SelectedIndex = 0;
        }

        private void frmNuevoCliente_Load(object sender, EventArgs e)
        {
          
            CargarComboBoxEstado();
            CargarComboBoxTipoIva();
            CargarComboBoxCiudad();

            if (tipomovimiento == "NUEVO")
            {
                IniciarControles();
            }
            else
            {
                IniciarControlesModificar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean ValidarControles()
        {
            bool resultado = true;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtNombre, "El campo nombre no puede estar vacio");
            }            
            if (string.IsNullOrEmpty(txtDocumento.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtDocumento, "El campo cuit/cuil/dni no puede estar vacio");
            }
            if (tipomovimiento == "MODIFICAR" && txtCodigo.Text == string.Empty)
            {
                resultado = false;
                errorProvider1.SetError(btnBuscar, "Debe seleccionar un cliente para modificar.");
            }

            return resultado;
        }

        private void InsertarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.clibarrio = txtBarrio.Text;
            cliente.ciudad = (Ciudad)cmbCiudad.SelectedItem;
            cliente.clicalle = txtCalle.Text;
            cliente.clidepto = txtDepto.Text;
            cliente.clidocumento = txtDocumento.Text;
            cliente.cliemail = txtEmail.Text;
            cliente.clifecha = DateTime.Today.Date;
            cliente.clinombre = txtNombre.Text;
            cliente.clinumero = txtNumero.Text;
            cliente.clipiso = txtPiso.Text;
            cliente.clitelefonocelular = txtTelefonoCelular.Text;
            cliente.clitelefonofijo = txtTelefonoFijo.Text;
            cliente.estado = (Estado)cmbEstado.SelectedItem;
            cliente.tipoiva = (TipoIva)cmbTipoIva.SelectedItem;

            cliente = Clientes.Crear(cliente);

            if (cliente != null)
            {
                string fmt = "00000000.##";
                MessageBox.Show("El cliente se registro con exito, con el código: " + cliente.cliid.ToString(fmt), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IniciarControles();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al registrar el cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IniciarControles();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarControles() == true)
            {
                if (tipomovimiento == "NUEVO")
                {
                    InsertarCliente();
                }
                else
                {
                    Modificar();
                }
            }

        }

        private void Modificar()
        {
            Cliente cliente = new Cliente();
            cliente.clibarrio = txtBarrio.Text;
            cliente.ciudad = (Ciudad)cmbCiudad.SelectedItem;
            cliente.clicalle = txtCalle.Text;
            cliente.clidepto = txtDepto.Text;
            cliente.clidocumento = txtDocumento.Text;
            cliente.cliemail = txtEmail.Text;
            cliente.clifecha = DateTime.Today.Date;
            cliente.clinombre = txtNombre.Text;
            cliente.clinumero = txtNumero.Text;
            cliente.clipiso = txtPiso.Text;
            cliente.clitelefonocelular = txtTelefonoCelular.Text;
            cliente.clitelefonofijo = txtTelefonoFijo.Text;
            cliente.estado = (Estado)cmbEstado.SelectedItem;
            cliente.tipoiva = (TipoIva)cmbTipoIva.SelectedItem;
            cliente.cliid = Convert.ToInt32(txtCodigo.Text);

            try
            {
                bool resultado = Clientes.Modificar(cliente);
                if(resultado == true)
                {
                    MessageBox.Show("El cliente se modifico con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniciarControlesModificar();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al modificar el cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IniciarControlesModificar();
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
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || char.IsControl(e.KeyChar)
                )
            {

                e.Handled = false;
            }

            else
            {
                errorProvider1.SetError(btnBuscar, "Solo se permiten números en el campo código.");
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dlgCliente dlg = new dlgCliente();
            dlg.Text = "CLIENTES - CLIENTES REGISTRADOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.cliid != 0)
            {
                txtCodigo.Text = String.Format("{0:00000000}", dlg.cliid);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != string.Empty && txtCodigo.TextLength == 8 && Convert.ToInt32(txtCodigo.TextLength) != 0)
            {
                BuscarClientePorId(Convert.ToInt32(txtCodigo.Text));
            }
        }

        private void BuscarClientePorId(int cliente_id)
        {
            errorProvider1.Clear();

            try
            {
                Cliente cliente = new Cliente();
                cliente.cliid = cliente_id;
                cliente = Clientes.GetPorId(cliente);

                if (cliente.clicodigo != string.Empty)
                {
                    txtBarrio.Text = cliente.clibarrio;
                    txtCalle.Text = cliente.clicalle;
                    txtCodigo.Text = String.Format("{0:00000000}", cliente.cliid);
                    txtDepto.Text = cliente.clidepto;
                    txtDocumento.Text = cliente.clidocumento;
                    txtEmail.Text = cliente.cliemail;
                    txtNombre.Text = cliente.clinombre;
                    txtNumero.Text = cliente.clinumero;
                    txtPiso.Text = cliente.clipiso;
                    txtTelefonoCelular.Text = cliente.clitelefonocelular;
                    txtTelefonoFijo.Text = cliente.clitelefonofijo;
                    cmbCiudad.Text = cliente.ciudad.ciunombre;
                    cmbEstado.Text = cliente.estado.estestado;
                    cmbTipoIva.Text = cliente.tipoiva.tpitipo;
                }
                else
                {
                    errorProvider1.SetError(btnBuscar, "El cliente no se encuentra registrado en el sistema.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
