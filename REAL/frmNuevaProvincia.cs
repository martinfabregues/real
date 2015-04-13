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
    public partial class frmNuevaProvincia : Form
    {
        public frmNuevaProvincia()
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
            txtProvincia.Text = string.Empty;
            txtProvincia.Focus();
            lblValidacion.Text = string.Empty;
        }

          private Boolean ValidarDatos()
          {
              bool res = false;
              errorProvider1.Clear();
              if (txtProvincia.Text != string.Empty)
              {
                  res = true;
              }
              else
              {
                  res = false;
                  lblValidacion.Text = "DEBE COMPLETAR EL CAMPO NOMBRE PROVINCIA.";
                  errorProvider1.SetError(txtProvincia, "DEBE COMPLETAR EL CAMPO NOMBRE PROVINCIA");
                  txtProvincia.Focus();
              }


              return res;
          }

          private void btnAceptar_Click(object sender, EventArgs e)
          {
              if (ValidarDatos() == true)
              {
                  Provincia prv = new Provincia();
                  prv.prvnombre = txtProvincia.Text;
                  int resultado = 0;

                  resultado = Provincias.ProvinciaInsertar(prv);
                  if (resultado > 0)
                  {
                      MessageBox.Show("REGISTRADO CORRECTAMENTE", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      IniciarControles();
                  }
                  else
                  {
                      MessageBox.Show("OCURRIO UN ERROR AL REGISTRAR LA PROVINCIA", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      IniciarControles();
                  }
              }
          }

          private void frmNuevaProvincia_Load(object sender, EventArgs e)
          {

          }


    }
}
