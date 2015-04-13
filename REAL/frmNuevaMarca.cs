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
    public partial class frmNuevaMarca : Form
    {
        public frmNuevaMarca()
        {
            InitializeComponent();
           
        }

        //LISTO
        private void IniciarControles()
        {
            txtNombre.Text = string.Empty;
            txtNombre.Focus();

            cmbProveedor.SelectedIndex = 0;
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
        private void LimpiarControles()
        {
            txtNombre.Text = string.Empty;
            cmbProveedor.SelectedIndex = 0;
        }


        private void frmNuevaMarca_Load(object sender, EventArgs e)
        {
            CargarComboBoxProveedor();
            IniciarControles();
        }

        //LISTO
        private Boolean ValidarDatos()
        {
            bool resultado = true;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El campo denominación no puede ser vacio.");
                resultado = false;
                txtNombre.Focus();
            }

            return resultado;
        }

        //LISTO
        private void CrearMarca()
        {
            Marca marca = new Marca();
            marca.proid = Convert.ToInt32(cmbProveedor.SelectedValue);
            marca.mardenominacion = txtNombre.Text;

            marca = Marcas.Create(marca);
            if (marca != null)
            {
                MessageBox.Show("La marca de registro con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al registrar la marca.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarControles();
            }

        }

        //LISTO
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (ValidarDatos() == true)
            {
                CrearMarca();
            }
                                
        }

        //LISTO
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
