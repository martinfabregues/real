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
    public partial class frmNuevaTarjetaCredito : Form
    {
        public frmNuevaTarjetaCredito()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IniciarControles()
        {
            txtDenominacion.Text = string.Empty;
        }


        private void frmNuevaTarjetaCredito_Load(object sender, EventArgs e)
        {
            IniciarControles();
        }

        private Boolean ValidarDatos()
        {
            bool resultado = true;

            if (string.IsNullOrEmpty(txtDenominacion.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtDenominacion, "El campo denominación no puede ser vacio");
            }

            return resultado;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == true)
            {
                Insertar();
            }
        }


        private void Insertar()
        {
            try
            {
                TarjetaCredito tarjeta = new TarjetaCredito();
                tarjeta.tarnombre = txtDenominacion.Text;

                tarjeta = TarjetasCredito.Crear(tarjeta);
                if (tarjeta != null)
                {
                    MessageBox.Show("La tarjeta de credito se registro correctamente", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IniciarControles();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al registrar la tarjeta de credito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IniciarControles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
