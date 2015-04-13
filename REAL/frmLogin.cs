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
    public partial class frmLogin : Form
    {
     
        public frmLogin()
        {
            InitializeComponent();
            IniciarControles();
            txtUsuario.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private Boolean ValidarControles()
        {
            bool res = false;
            if (txtUsuario.Text != string.Empty)
            {
                if (txtClave.Text != string.Empty)
                {
                    res = true;
                }
                else
                {
                    res = false;
                    lblValidacion.Text = "DEBE COMPLETAR EL CAMPO CLAVE.";
                    txtClave.Focus();
                }
            }
            else
            {
                res = false;
                lblValidacion.Text = "DEBE COMPLETAR EL CAMPO USUARIO.";
                txtUsuario.Focus();
            }
            return res;
        }

        private void LimpiarControles()
        {
            txtUsuario.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtUsuario.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarControles() == true)
            {



                DataTable dt = new DataTable();
                dt = Usuarios.GetLogin(txtUsuario.Text, txtClave.Text);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) > 0)
                    {

                        frmInicio frm = new frmInicio(txtUsuario.Text);
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        lblValidacion.Text = "USUARIO O CONTRASEÑA INCORRECTOS.";
                        LimpiarControles();
                    }
                    
                }
                else
                {
                    lblValidacion.Text = "USUARIO O CONTRASEÑA INCORRECTOS.";
                    LimpiarControles();
                }


            }
        }

        private void IniciarControles()
        {
            txtClave.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtUsuario.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            IniciarControles();
            txtUsuario.Focus();
            this.ActiveControl = txtUsuario;
        }

    }
}
