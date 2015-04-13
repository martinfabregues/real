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
    public partial class frmNuevoBarrio : Form
    {
        public frmNuevoBarrio()
        {
            InitializeComponent();
            IniciarControles();
        }


        private void IniciarControles()
        {
            txtCosto.Enabled = false;
            txtBarrio.Text = string.Empty;
            txtCosto.Text = string.Empty;
            ckbCosto.Checked = false;
            CargarComboBoxCiudad();
        }

        private void CargarComboBoxCiudad()
        {
            cmbCiudad.ValueMember = "ciuid";
            cmbCiudad.DisplayMember = "ciunombre";
            cmbCiudad.DataSource = Ciudades.CiudadObtenerTodo().DefaultView;
            cmbCiudad.SelectedIndex = 0;
        }

        private void ckbCosto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCosto.Checked == true)
            {
                txtCosto.Enabled = true;
            }
            else
            {
                txtCosto.Enabled = false;   
            }
        }

        private Boolean ValidarDatos()
        {

            bool res = false;
            errorProvider1.Clear();
            if (txtBarrio.Text != string.Empty)
            {
                if (ckbCosto.Checked == true)
                {
                    if (txtCosto.Text != string.Empty)
                    {
                        res = true;

                    }
                    else
                    {
                        res = false;
                        errorProvider1.SetError(txtCosto, "DEBE COMPLETAR EL CAMPO COSTO");
                        txtCosto.Focus();
                    }
                }
                else
                {
                    res = true;
                }
            }
            else
            {
                res = false;
                txtBarrio.Focus();
                errorProvider1.SetError(txtBarrio, "DEBE COMPLETAR EL CAMPO BARRIO");
            }


            return res;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == true)
            {
                Barrio bar = new Barrio();
                bar.barnombre = txtBarrio.Text;
                bar.ciuid = Convert.ToInt32(cmbCiudad.SelectedValue);
                if (ckbCosto.Checked == true)
                {
                    bar.barcosto = Convert.ToDecimal(txtCosto.Text);
                }
                else
                {
                    bar.barcosto = 0;
                }
                int resultado = 0;
                resultado = Barrios.BarrioInsertar(bar);
                if (resultado > 0)
                {
                    MessageBox.Show("REGISTRADO CORRECTAMENTE", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniciarControles();
                }
                else
                {
                    MessageBox.Show("OCURRIO UN ERROR AL REGISTRAR EL BARRIO", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IniciarControles();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO COSTO.";
                errorProvider1.SetError(txtCosto, "SOLO SE PERMITEN NÚMEROS EN EL CAMPO COSTO");
                e.Handled = true;
                txtCosto.Focus();
                return;
            }
        }

        private void frmNuevoBarrio_Load(object sender, EventArgs e)
        {

        }

    }
}
