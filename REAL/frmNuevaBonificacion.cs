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
    public partial class frmNuevaBonificacion : Form
    {
        public string tipoMovimiento { get; set; }

        public frmNuevaBonificacion(string tM)
        {
            tipoMovimiento = tM;
            InitializeComponent();
        }

        //LISTO
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //LISTO
        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetTodos();
            cmbProveedor.SelectedIndex = 0;
        }

        //LISTO
        private void CargarComboBoxEstado()
        {
            cmbEstado.ValueMember = "estid";
            cmbEstado.DisplayMember = "estestado";
            cmbEstado.DataSource = Estados.GetTodos();
            cmbEstado.SelectedIndex = 0;
        }

        //LISTO
        private void frmNuevaBonificacion_Load(object sender, EventArgs e)
        {
            


            if (tipoMovimiento == "NUEVO")
            {
                CargarComboBoxEstado();
                CargarComboBoxProveedor();
                IniciarControles();
            }
            else
            {
                IniciarControlesModificar();

            }
        }

        //LISTO
        private void IniciarControlesModificar()
        {
            lblTitulo.Text = "Modificar Bonificación";
            cmbProveedor.Enabled = false;
            txtNombre.Enabled = false;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;
            txtBonificacion.Enabled = false;
            cmbEstado.Enabled = false;
            CargarComboBoxEstado();
            CargarComboBoxProveedor();
            txtNombre.Focus();
            helpProvider1.SetShowHelp(txtBonificacion, true);
            helpProvider1.SetHelpString(txtBonificacion, "Ingresar Bonificación con el siguiente formato: 0.00");
            helpProvider1.SetShowHelp(txtBonificacion, true);

            txtBonificacion.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }

        //LISTO
        private void txtBonificacion_KeyPress(object sender, KeyPressEventArgs e)
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
                errorProvider1.SetError(txtBonificacion, "Solo se permiten numeros en el campo costo neto.");
                e.Handled = true;
            }
        }

        //LISTO
        private Boolean ValidarDatos()
        {
            errorProvider1.Clear();

            bool resultado = true;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Debe completar el campo nombre.");
                resultado = false;
                txtNombre.Focus();
            }

            if (string.IsNullOrEmpty(txtBonificacion.Text))
            {
                errorProvider1.SetError(txtBonificacion, "Debe completar el campo bonificación.");
                resultado = false;
                txtBonificacion.Focus();
            }

            if (dtpHasta.Value.Date < dtpDesde.Value.Date)
            {
                errorProvider1.SetError(dtpDesde, "La fecha de inicio no puede ser mayor a la final.");
                resultado = false;
                dtpDesde.Focus();
            }

            return resultado;
        }

        //LISTO
        private void IniciarControles()
        {
            cmbEstado.SelectedIndex = 0;
            cmbProveedor.SelectedIndex = 0;
            txtBonificacion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            dtpDesde.Value = DateTime.Today.Date;
            dtpHasta.Value = DateTime.Today.Date;
            txtNombre.Focus();
            helpProvider1.SetShowHelp(txtBonificacion, true);
            helpProvider1.SetHelpString(txtBonificacion, "Ingresar Bonificación con el siguiente formato: 0.00");
            txtIdBonif.Visible = false;
            btnBuscar.Visible = false;
            label7.Visible = false;

            cmbEstado.SelectedIndex = 0;
            cmbProveedor.SelectedIndex = 0;
        }

        //LISTO
        private void CrearBonificacion()
        {
            int mes = DateTime.Today.Month;
            int ano = DateTime.Today.Year;

            Bonificacion bonificacion = new Bonificacion();
            try
            {
                bonificacion.proveedor.proid = Convert.ToInt32(cmbProveedor.SelectedValue);
                bonificacion.bonnombre = txtNombre.Text + " - (" + mes + "/" + ano + ")";
                bonificacion.bonfechacreacion = DateTime.Today.Date;
                bonificacion.bonfechainicio = dtpDesde.Value;
                bonificacion.bonfechafin = dtpHasta.Value;
                bonificacion.bondescuento = Convert.ToDecimal(txtBonificacion.Text);
                bonificacion.estado.estid = Convert.ToInt32(cmbEstado.SelectedValue);

                bonificacion = Bonificaciones.Create(bonificacion);
                if (bonificacion != null)
                {
                    MessageBox.Show("La Bonificación se registro con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniciarControles();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al registrar la bonificación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IniciarControles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //LISTO
        private void UpdateBonificacion()
        {
            int mes = DateTime.Today.Month;
            int ano = DateTime.Today.Year;
            Bonificacion bonificacion = new Bonificacion();
            try
            {

                bonificacion.bonid = Convert.ToInt32(txtIdBonif.Text);
                bonificacion.proid = Convert.ToInt32(cmbProveedor.SelectedValue);
                bonificacion.bonnombre = txtNombre.Text;
                bonificacion.bonfechacreacion = DateTime.Today.Date;
                bonificacion.bonfechainicio = dtpDesde.Value;
                bonificacion.bonfechafin = dtpHasta.Value;
                bonificacion.bondescuento = Convert.ToDecimal(txtBonificacion.Text);
                bonificacion.estid = Convert.ToInt32(cmbEstado.SelectedValue);

                bool resultado = Bonificaciones.Update(bonificacion);
                if (resultado != false)
                {
                    MessageBox.Show("La bonificación se modifico con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniciarControlesModificar();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al modificar la bonificación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IniciarControlesModificar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //LISTO
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == true)
            {
                if (tipoMovimiento == "NUEVO")
                {
                     DialogResult result = MessageBox.Show("Se va a registrar la bonificación, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (result == System.Windows.Forms.DialogResult.Yes)
                     {

                         CrearBonificacion();

                     }
                }
                else
                {

                    //MODIFICAR
                        DialogResult result = MessageBox.Show("Se va a modificar la bonificación, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {

                            UpdateBonificacion();  
                          
                        }
                }

            }
        }

        //LISTO
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dlgBonificaciones dlg = new dlgBonificaciones();
            dlg.Text = "BONIFICACIONES - LISTADO DE BONIFICACIONES REGISTRADAS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK || dlg.bonid != 0)
            {
                txtIdBonif.Text = dlg.bonid.ToString();
            }
        }

        //LISTO
        private void txtIdBonif_TextChanged(object sender, EventArgs e)
        {
            if (txtIdBonif.Text != string.Empty)
            {
                ObtenerDatosBonificacionPorId(Convert.ToInt32(txtIdBonif.Text));
            }
        }

        //LISTO
        private void HabilitarControles()
        {
            cmbProveedor.Enabled = true;
            txtNombre.Enabled = true;
            dtpDesde.Enabled = true;
            dtpHasta.Enabled = true;
            txtBonificacion.Enabled = true;
            cmbEstado.Enabled = true;
        }

        private void ObtenerDatosBonificacionPorId(int bonid)
        {
            try
            {
                DataTable dt = Bonificaciones.GetBonificacionDatosPorId(Convert.ToInt32(txtIdBonif.Text));
                if (dt.Rows.Count > 0)
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor = Proveedores.GetPorId(Convert.ToInt32(dt.Rows[0]["proid"]));

                    Estado estado = new Estado();
                    estado = Estados.GetPorId(Convert.ToInt32(dt.Rows[0]["estid"]));

                    cmbProveedor.Text = proveedor.pronombre;
                    txtNombre.Text = dt.Rows[0]["bonnombre"].ToString();
                    dtpDesde.Value = Convert.ToDateTime(dt.Rows[0]["bonfechainicio"]);
                    dtpHasta.Value = Convert.ToDateTime(dt.Rows[0]["bonfechafin"]);
                    txtBonificacion.Text = dt.Rows[0]["bondescuento"].ToString();
                    cmbEstado.Text = estado.estestado ;
                    HabilitarControles();
                }
                else
                {
                    //no existe la bonificacion

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
