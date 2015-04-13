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
using System.Windows.Forms;

namespace REAL
{
    public partial class frmNuevoPlan : Form
    {
        public string movimiento { get; set; }
        public frmNuevoPlan()
        {
            InitializeComponent();
        }

        public frmNuevoPlan(string mov)
        {
            movimiento = mov;

            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IniciarControles()
        {
            txtDenominacion.Text = string.Empty;
            cmbTarjeta.SelectedIndex = 0;
            txtCostoFinanciero.Text = string.Empty;
            txtMargenFinanciero.Text = string.Empty;
            txtCodigo.Visible = false;
            label7.Visible = false;
            txtCInflacionario.Text = string.Empty;
            txtComision.Text = string.Empty;
        }

        private void IniciarControlesModificar()
        {
            txtDenominacion.Text = string.Empty;
            cmbTarjeta.SelectedIndex = 0;
            txtCostoFinanciero.Text = string.Empty;
            txtMargenFinanciero.Text = string.Empty;
            txtCodigo.Visible = true;
            label7.Visible = true;
            txtCInflacionario.Text = string.Empty;
            txtComision.Text = string.Empty;
        }

        private void CargarComboTarjeta()
        {
            cmbTarjeta.DataSource = null;

            cmbTarjeta.ValueMember = "tarid";
            cmbTarjeta.DisplayMember = "tarnombre";
            List<TarjetaCredito> list  = TarjetasCredito.GetTodos();
            if (list.Count > 0)
            {
                cmbTarjeta.DataSource = list;
            }
            else
            {
                cmbTarjeta.Items.Add("NO EXISTEN TARJETAS REGISTRADAS");
                cmbTarjeta.SelectedIndex = 0;
            }
        }

        private void frmNuevoPlan_Load(object sender, EventArgs e)
        {

            CargarComboTarjeta();
            if (movimiento == "NUEVO")
            {
                IniciarControles();
            }
            else
            {
                IniciarControlesModificar();
            }
            
        }

        private Boolean ValidarDatos()
        {
            bool resultado = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtDenominacion.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtDenominacion, "El campo denominación no puede ser vacio");
            }
            if (string.IsNullOrEmpty(txtCostoFinanciero.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtCostoFinanciero, "El campo costo financiero no puede ser vacio");
            }
            if (string.IsNullOrEmpty(txtMargenFinanciero.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtMargenFinanciero, "El campo margen financiero no puede ser vacio");
            }
            if (string.IsNullOrEmpty(txtComision.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtComision, "El campo comisión no puede ser vacio");
            }
            if (string.IsNullOrEmpty(txtCInflacionario.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtCInflacionario, "El campo margen c.inflacionario no puede ser vacio");
            }
            return resultado;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == true)
            {
                if (movimiento == "NUEVO")
                {
                    Insertar();
                }
                else
                {
                    Actualizar();
                }
            }
        }


        private void ObetenerDatosPlan(int plan_id)
        {
            errorProvider1.Clear();

            try
            {
                Plan plan = Planes.GetPorId(plan_id);
                if (plan != null)
                {
                    txtCodigo.Text = String.Format("{0:000}", plan.plan_id);
                    txtDenominacion.Text = plan.plan_denominacion;
                    cmbTarjeta.Text = plan.tarjetacredito.tarnombre;
                    txtCostoFinanciero.Text = plan.plan_costofinanciero.ToString();
                    txtComision.Text = plan.plan_comision.ToString();
                    txtCInflacionario.Text = plan.plan_costoinflacionario.ToString();
                    txtMargenFinanciero.Text = plan.plan_margenfinanciero.ToString();
                }
                else
                {
                    errorProvider1.SetError(txtCodigo, "El plan no se encuentra registrado en el sistema");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Insertar()
        {
            try
            {
                Plan plan = new Plan();
                plan.plan_costofinanciero = Convert.ToDouble(txtCostoFinanciero.Text);
                plan.plan_denominacion = txtDenominacion.Text;
                plan.plan_margenfinanciero = Convert.ToDouble(txtMargenFinanciero.Text);
                plan.tarjetacredito = (TarjetaCredito)cmbTarjeta.SelectedItem;
                plan.plan_comision = Convert.ToDouble(txtComision.Text);
                plan.plan_costoinflacionario = Convert.ToDouble(txtCInflacionario.Text);

                plan = Planes.Crear(plan);
                if (plan != null)
                {
                    MessageBox.Show("El plan se registro con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniciarControles();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al registrar el plan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Plan plan = new Plan();
                plan.plan_costofinanciero = Convert.ToDouble(txtCostoFinanciero.Text);
                plan.plan_denominacion = txtDenominacion.Text;
                plan.plan_margenfinanciero = Convert.ToDouble(txtMargenFinanciero.Text);
                plan.tarjetacredito = (TarjetaCredito)cmbTarjeta.SelectedItem;
                plan.plan_comision = Convert.ToDouble(txtComision.Text);
                plan.plan_costoinflacionario = Convert.ToDouble(txtCInflacionario.Text);
                plan.plan_id = Convert.ToInt32(txtCodigo.Text);

                bool resultado = Planes.Actualizar(plan);
                if (resultado == true)
                {
                    MessageBox.Show("El plan se actualizo con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniciarControlesModificar();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al actualizar el plan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IniciarControlesModificar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void txtCostoFinanciero_KeyPress(object sender, KeyPressEventArgs e)
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
                errorProvider1.SetError(txtCostoFinanciero, "Solo se permiten números en el campo costo financiero.");
                e.Handled = true;
            }
        }

        private void txtMargenFinanciero_KeyPress(object sender, KeyPressEventArgs e)
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
                errorProvider1.SetError(txtMargenFinanciero, "Solo se permiten números en el campo margen financiero.");
                e.Handled = true;
            }
        }

        private void txtComision_KeyPress(object sender, KeyPressEventArgs e)
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
                errorProvider1.SetError(txtComision, "Solo se permiten números en el campo comisión.");
                e.Handled = true;
            }
        }

        private void txtCInflacionario_KeyPress(object sender, KeyPressEventArgs e)
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
                errorProvider1.SetError(txtCInflacionario, "Solo se permiten números en el campo c.inflacionario.");
                e.Handled = true;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != string.Empty && txtCodigo.TextLength == 3 && Convert.ToInt32(txtCodigo.Text) != 0)
            {
                ObetenerDatosPlan(Convert.ToInt32(txtCodigo.Text));
            }
            else
            {
                errorProvider1.SetError(txtCodigo, "El código ingresado es incorrecto");
                LimpiarControles();
            }
        }

        private void LimpiarControles()
        {
            txtCInflacionario.Text = string.Empty;
            txtComision.Text = string.Empty;
            txtCostoFinanciero.Text = string.Empty;
            txtDenominacion.Text = string.Empty;
            txtMargenFinanciero.Text = string.Empty;
            cmbTarjeta.SelectedIndex = 0;
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
                errorProvider1.SetError(txtCodigo, "Solo se permiten números en el campo código.");
                e.Handled = true;
            }
        }

    }
}
