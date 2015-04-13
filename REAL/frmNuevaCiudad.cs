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
    public partial class frmNuevaCiudad : Form
    {
        public frmNuevaCiudad()
        {
            InitializeComponent();
            IniciarControles();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IniciarControles()
        {
            txtCiudad.Text = string.Empty;
            txtCiudad.Focus();
            CargarComboBoxProvincias();
        }

        private void CargarComboBoxProvincias()
        {
            cmbProvincia.ValueMember = "prvid";
            cmbProvincia.DisplayMember = "prvnombre";
            cmbProvincia.DataSource = Provincias.ProvinciaObtenerTodo().DefaultView;
    
        }

        private Boolean ValidarDatos()
        {
            bool res = false;
            errorProvider1.Clear();
            if (txtCiudad.Text != string.Empty)
            {
                res = true;
            }
            else
            {
                lblValidacion.Text = "DEBE COMPLETAR EL CAMPO NOMBRE CIUDAD.";
                errorProvider1.SetError(txtCiudad, "DEBE COMPLETAR EL CAMPO NOMBRE CIUDAD");
                txtCiudad.Focus();
                res = false;
            }

            return res;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == true)
            {
                Ciudad ciu = new Ciudad();
                ciu.ciunombre = txtCiudad.Text;
                ciu.prvid = Convert.ToInt32(cmbProvincia.SelectedValue);
                int resultado = 0;
                resultado = Ciudades.CiudadInsertar(ciu);
                if (resultado > 0)
                {
                    MessageBox.Show("REGISTRADO CORRECTAMENTE", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniciarControles();
                }
                else
                {
                    MessageBox.Show("OCURRIO UN ERROR AL REGISTRAR LA CIUDAD", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IniciarControles();
                }
            }
            else
            {

            }
        }

        private void frmNuevaCiudad_Load(object sender, EventArgs e)
        {

        }

    }
}
