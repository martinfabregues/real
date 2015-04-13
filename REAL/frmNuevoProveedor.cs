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
using System.Windows.Forms;

namespace REAL
{
    public partial class frmNuevoProveedor : Form
    {
        public string tipomovimiento { get; set; }
        public frmNuevoProveedor(string tm)
        {
            tipomovimiento = tm;
            InitializeComponent();
            
        }

        //LISTO
        private void IniciarControles()
        {
            txtCalle.Text = string.Empty;
            txtCodPos.Text = string.Empty;
            txtCuit.Text = string.Empty;
            txtDenominacion.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtIngBrutos.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtBarrio.Text = string.Empty;
            txtPorcentaje.Text = string.Empty;
            txtRazonSocial.Focus();

            //CargarComboBoxBarrio();
            cmbActividad.SelectedIndex = 0;
            cmbCiudad.SelectedIndex = 0;
            cmbTipoIva.SelectedIndex = 0;
          
            groupBox3.Enabled = false;
            txtId.Visible = false;
        }

        //LISTO
        private void IniciarControlesModificar()
        {
            txtCalle.Text = string.Empty;
            txtCodPos.Text = string.Empty;
            txtCuit.Text = string.Empty;
            txtDenominacion.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtIngBrutos.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtBarrio.Text = string.Empty;
            txtId.Visible = false;
            txtRazonSocial.Focus();
            txtPorcentaje.Text = string.Empty;
            //CargarComboBoxBarrio();
            cmbActividad.SelectedIndex = 0;
            cmbCiudad.SelectedIndex = 0;
            cmbTipoIva.SelectedIndex = 0;

            groupBox3.Visible = true;

            btnAceptar.Text = "Modificar";

            Bitmap img = new Bitmap(Properties.Resources.search, new Size(16, 16));
            btnBuscar.Image = img;
           
        }

        //LISTO
        private void CargarComboBoxActividad()
        {
            cmbActividad.ValueMember = "actid";
            cmbActividad.DisplayMember = "actnombre";
            cmbActividad.DataSource = Actividades.GetTodo();
            cmbActividad.SelectedIndex = 0;
        }

        //LISTO
        private void CargarComboBoxTipoIva()
        {
            cmbTipoIva.ValueMember = "tpiid";
            cmbTipoIva.DisplayMember = "tpitipo";
            cmbTipoIva.DataSource = TiposIva.GetTodos();
            cmbTipoIva.SelectedIndex = 0;
        }

        //LISTO
        private void CargarComboBoxCiudad()
        {
            cmbCiudad.ValueMember = "ciuid";
            cmbCiudad.DisplayMember = "ciunombre";
            cmbCiudad.DataSource = Ciudades.GetTodo();
            cmbCiudad.SelectedIndex = 0;
        }

        //LISTO
        private void frmNuevoProveedor_Load(object sender, EventArgs e)
        {
            CargarComboBoxActividad();
            CargarComboBoxCiudad();
            CargarComboBoxTipoIva();

            if (tipomovimiento == "NUEVO")
            {
                IniciarControles();

            }
            else
            {
                if (tipomovimiento == "MODIFICAR")
                {
                    IniciarControlesModificar();


                }
            }
        }

        //LISTO
        private Boolean ValidarDatos()
        {
            bool resultado = true;

            if (string.IsNullOrEmpty(txtDenominacion.Text))
            {
             
                errorProvider1.SetError(txtDenominacion, "Debe completar el campo denominación.");
                resultado = false;
                txtDenominacion.Focus();
            }

            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
               
                errorProvider1.SetError(txtRazonSocial, "Debe completar el campo razón social.");
                resultado = false;
                txtRazonSocial.Focus();
            }

            if (string.IsNullOrEmpty(txtCuit.Text))
            {
              
                errorProvider1.SetError(txtCuit, "Debe completar el campo cuit.");
                resultado = false;
                txtCuit.Focus();
            }

            if (string.IsNullOrEmpty(txtIngBrutos.Text))
            {
              
                errorProvider1.SetError(txtIngBrutos, "Debe completar el campo ing. brutos.");
                resultado = false;
                txtIngBrutos.Focus();
            }

            if (string.IsNullOrEmpty(txtBarrio.Text))
            {
              
                errorProvider1.SetError(txtBarrio, "Debe completar el campo barrio.");
                resultado = false;
                txtBarrio.Focus();
            }

            if (string.IsNullOrEmpty(txtCalle.Text))
            {
               
                errorProvider1.SetError(txtCalle, "Debe completar el campo calle.");
                resultado = false;
                txtCalle.Focus();
            }

            if (string.IsNullOrEmpty(txtNumero.Text))
            {
           
                errorProvider1.SetError(txtNumero, "Debe completar el campo número.");
                resultado = false;
                txtNumero.Focus();
            }

            if (string.IsNullOrEmpty(txtCodPos.Text))
            {
             
                errorProvider1.SetError(txtCodPos, "Debe completar el campo código postal.");
                resultado = false;
                txtCodPos.Focus();
            }

            if (string.IsNullOrEmpty(txtTel.Text))
            {
             
                errorProvider1.SetError(txtTel, "Debe completar el campo teléfono.");
                resultado = false;
                txtTel.Focus();
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
               
                errorProvider1.SetError(txtEmail, "Debe completar el campo email.");
                resultado = false;
                txtEmail.Focus();
            }

            if (string.IsNullOrEmpty(txtPorcentaje.Text))
            {
              
                errorProvider1.SetError(txtPorcentaje, "Debe completar el campo porcentaje.");
                resultado = false;
                txtPorcentaje.Focus();
            }
            
            return resultado;
        }

        //LISTO
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        //LISTO
        private void CrearProveedor()
        {
            Proveedor proveedor = new Proveedor();
            proveedor.actid = Convert.ToInt32(cmbActividad.SelectedValue);
            proveedor.locid = 1;
            proveedor.probarrio = txtBarrio.Text;
            proveedor.procodigo = string.Empty;
            proveedor.procodpostal = txtCodPos.Text;
            proveedor.procuit = txtCuit.Text;
            proveedor.prodireccion = txtCalle.Text + " " + txtNumero.Text;
            proveedor.proemail = txtEmail.Text;
            proveedor.proingbrutos = txtIngBrutos.Text;
            proveedor.pronombre = txtDenominacion.Text;
            proveedor.prorazonsocial = txtRazonSocial.Text;
            proveedor.protelefono = txtTel.Text;
            proveedor.tpiid = Convert.ToInt32(cmbTipoIva.SelectedValue);
            proveedor.proingbrutostributo = ConvertirTributoCoeficiente(txtPorcentaje.Text);

            proveedor = Proveedores.Create(proveedor);
            if (proveedor != null)
            {
                string fmt = "0000.##";
                MessageBox.Show("El proveedor se registro con exito, con el código: " + proveedor.proid.ToString(fmt), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IniciarControles();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al registrar el proveedor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IniciarControles();
            }
        }

        //LISTO
        private void UpdateProveedor()
        {
            Proveedor proveedor = new Proveedor();
            proveedor.actid = Convert.ToInt32(cmbActividad.SelectedValue);
            proveedor.locid = 1;
            proveedor.probarrio = txtBarrio.Text;
            proveedor.procodigo = string.Empty;
            proveedor.procodpostal = txtCodPos.Text;
            proveedor.procuit = txtCuit.Text;
            proveedor.prodireccion = txtCalle.Text + " " + txtNumero.Text;
            proveedor.proemail = txtEmail.Text;
            proveedor.proingbrutos = txtIngBrutos.Text;
            proveedor.pronombre = txtDenominacion.Text;
            proveedor.prorazonsocial = txtRazonSocial.Text;
            proveedor.protelefono = txtTel.Text;
            proveedor.tpiid = Convert.ToInt32(cmbTipoIva.SelectedValue);
            proveedor.proid = Convert.ToInt32(txtId.Text);
            proveedor.proingbrutostributo = ConvertirTributoCoeficiente(txtPorcentaje.Text);

            bool resultado = Proveedores.Update(proveedor);
            if (resultado != false)
            {
                MessageBox.Show("El proveedor se modifico con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IniciarControlesModificar();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al modificar el proveedor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IniciarControlesModificar();
            }
        }

        //LISTO
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == true)
            {
                if (tipomovimiento == "NUEVO")
                {
                    CrearProveedor();
                }
                else
                {
                    UpdateProveedor();
                }
            }
        }

        //LISTO
        private void frmNuevoProveedor_Resize(object sender, EventArgs e)
        {
            groupBox1.Width = this.Width - 40;
            groupBox2.Width = this.Width - 40;
            btnAceptar.Location = new Point(20, this.Height - 100);
            btnCancelar.Location = new Point(this.Width - 110, this.Height - 100);
        }

        //LISTO
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
               
                errorProvider1.SetError(txtNumero, "SOLO SE PERMITEN NÚMEROS EN EL CAMPO NÚMERO");
                e.Handled = true;
                txtNumero.Focus();
                return;
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dlgProveedores dlg = new dlgProveedores();
            dlg.Text = "PROVEEDORES - LISTADO DE PROVEEDORES REGISTRADOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.proid != 0)
            {
                txtId.Text = dlg.proid.ToString();
            }
        }

        //LISTO
        private void BuscarDatosProveedorPorId(int proid)
        {
            Proveedor pro = new Proveedor();
            pro = Proveedores.GetPorId(proid);

            txtDenominacion.Text = pro.pronombre;
            txtRazonSocial.Text = pro.prorazonsocial;
            txtCuit.Text = pro.procuit;
            txtIngBrutos.Text = pro.proingbrutos;
            txtBarrio.Text = pro.probarrio;
            txtCalle.Text = pro.prodireccion;
            txtCodPos.Text = pro.procodpostal;
            txtTel.Text = pro.protelefono;
            txtEmail.Text = pro.proemail;
            txtCodigo.Text = pro.procodigo;
            txtPorcentaje.Text = Math.Round(ConvertirTributo(pro.proingbrutostributo), 2).ToString();


            Actividad act = new Actividad();
            act = Actividades.GetPorId(pro.actid);
            cmbActividad.Text = act.actnombre;

            TipoIva tpi = new TipoIva();
            tpi = TiposIva.GetPorId(pro.tpiid);
            cmbTipoIva.Text = tpi.tpitipo;

            Ciudad ciu = new Ciudad();
            ciu = Ciudades.GetPorId(pro.locid);
            cmbCiudad.Text = ciu.ciunombre;

        }

        //LISTO
        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            {
                BuscarDatosProveedorPorId(Convert.ToInt32(txtId.Text));
            }
        }

        //LISTO
        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                errorProvider1.SetError(txtPorcentaje, "Solo se permiten números en el campo porcentaje.");
             
                e.Handled = true;
                txtPorcentaje.Focus();
                return;
            }
        }

        //LISTO
        private Double ConvertirTributoCoeficiente(string tributo)
        {
            double res;
            res = ((100 + Convert.ToDouble(tributo)) / 100);
            return res;
        }

        //LISTO
        private Double ConvertirTributo(Double tributo)
        {
            double res;
            res = ((tributo * 100) - 100);
            return res;
        }

    }
}
