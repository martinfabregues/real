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
    public partial class frmListaPrecio : Form
    {
        public string tipomovimiento { get; set; }
        
        public frmListaPrecio()
        {
            InitializeComponent();
        }

        public frmListaPrecio(string tm)
        {
            tipomovimiento = tm;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void IniciarControles()
        {
            txtDenominacion.Text = string.Empty;
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
            cmbEstado.SelectedIndex = 0;
            cmbProveedor.SelectedIndex = 0;
            label6.Visible = false;
            txtCodigo.Visible = false;
            btnBuscar.Visible = false;
            lblStatus.Visible = false;
            pgbar1.Visible = false;
        }

        private void IniciarControlesModificar()
        {
            txtDenominacion.Text = string.Empty;
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
            cmbEstado.SelectedIndex = 0;
            cmbProveedor.SelectedIndex = 0;
            label6.Visible = true;
            txtCodigo.Visible = true;
            btnBuscar.Visible = true;
            txtCodigo.Text = string.Empty;
            lblStatus.Visible = false;
            pgbar1.Visible = false;
        }

        private void frmListaPrecio_Load(object sender, EventArgs e)
        {
            CargarComboProveedor();
            CargarComboEstado();

            if (tipomovimiento == "NUEVO")
            {

                IniciarControles();
            }
            else
            {
                IniciarControlesModificar();
            }

        }

        private void CargarComboProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetTodos();
        }

        private void CargarComboEstado()
        {
            cmbEstado.ValueMember = "estid";
            cmbEstado.DisplayMember = "estestado";
            cmbEstado.DataSource = Estados.GetTodos();
        }

        private Boolean ValidarDatos()
        {
            bool resultado = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtDenominacion.Text))
            {
                errorProvider1.SetError(txtDenominacion, "El campo denominación no puede ser vacio");
                resultado = false;
            }

            if (dtpHasta.Value <= dtpDesde.Value)
            {
                resultado = false;
                errorProvider1.SetError(dtpHasta, "La fecha de fin no puede ser menor o igual a la de inicio");
            }

            return resultado;
        }


        private void Insertar()
        {
            try
            {
                ListaPrecio listaprecio = new ListaPrecio();
                listaprecio.estado = (Estado)cmbEstado.SelectedItem;
                listaprecio.listaprecio_denominacion = txtDenominacion.Text;
                listaprecio.listaprecio_fechacreacion = DateTime.Now;
                listaprecio.listaprecio_fechafin = dtpHasta.Value;
                listaprecio.listaprecio_fechainicio = dtpDesde.Value;
                listaprecio.proveedor = (Proveedor)cmbProveedor.SelectedItem;

                pgbar1.Visible = true;
                lblStatus.Visible = true;
                pgbar1.Style = ProgressBarStyle.Marquee;
                pgbar1.MarqueeAnimationSpeed = 100;
                lblStatus.Text = "Generando Lista de Precio: ";
                //MANDAR AL BACKGROUNDWORKER

                backgroundWorker1.RunWorkerAsync(listaprecio);

                //CONTROLO EN EL COMPLETE DEL BACKGROUNDWORKER
                //if (listaprecio != null)
                //{
                //    MessageBox.Show("La lista de precio se registro correctamente", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    IniciarControles();
                //}
                //else
                //{
                //    MessageBox.Show("Ocurrio un error al registrar la lista de precios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    IniciarControles();
                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void Modificar()
        {
            try
            {
                ListaPrecio listaprecio = new ListaPrecio();
                listaprecio.estado = (Estado)cmbEstado.SelectedItem;
                listaprecio.listaprecio_denominacion = txtDenominacion.Text;
                listaprecio.listaprecio_fechacreacion = DateTime.Now;
                listaprecio.listaprecio_fechafin = dtpHasta.Value;
                listaprecio.listaprecio_fechainicio = dtpDesde.Value;
                listaprecio.proveedor = (Proveedor)cmbProveedor.SelectedItem;
                listaprecio.listaprecio_id = Convert.ToInt32(txtCodigo.Text);

                //MODIFICAR
                bool resultado = ListasPrecio.Modificar(listaprecio);
                if (resultado == true)
                {
                    MessageBox.Show("La lista de precio se modifico correctamente", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    IniciarControlesModificar();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al modificar la lista de precios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    IniciarControlesModificar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ObtenerDatosLista(int listaprecio_id)
        {
            errorProvider1.Clear();
            ListaPrecio listaprecio = ListasPrecio.GetPorId(listaprecio_id);
            if (listaprecio.listaprecio_id != 0)
            {
           
                txtCodigo.Text = String.Format("{0:0000}",listaprecio.listaprecio_id);
                txtDenominacion.Text = listaprecio.listaprecio_denominacion;
                cmbEstado.Text = listaprecio.estado.estestado;
                cmbProveedor.Text = listaprecio.proveedor.pronombre;
                dtpDesde.Value = listaprecio.listaprecio_fechainicio;
                dtpHasta.Value = listaprecio.listaprecio_fechafin;
            }
            else
            {
                errorProvider1.SetError(btnBuscar, "La lista de precio no se encuentra registrada en el sistema.");
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(ValidarDatos() == true)
            {
                if (tipomovimiento == "NUEVO")
                {
                    Insertar();
                }
                else
                {
                    Modificar();
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != string.Empty && txtCodigo.TextLength == 4 && Convert.ToInt32(txtCodigo.Text) != 0)
            {
                ObtenerDatosLista(Convert.ToInt32(txtCodigo.Text));
            }
            else
            {
                errorProvider1.SetError(btnBuscar, "El código ingresado es incorrecto");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                ListaPrecio listaprecio = (ListaPrecio)e.Argument;
                listaprecio = ListasPrecio.Crear(listaprecio);

                e.Result = listaprecio;
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result as ListaPrecio != null)
            {
                pgbar1.MarqueeAnimationSpeed = 0;
                pgbar1.Visible = false;
                lblStatus.Visible = false;

                MessageBox.Show("La lista de precio se registro correctamente", "Infomación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IniciarControles();
            }
            else
            {
                pgbar1.MarqueeAnimationSpeed = 0;
                pgbar1.Visible = false;
                lblStatus.Visible = false;
                MessageBox.Show("Ocurrio un error al registrar la lista de precios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IniciarControles();
            }
    
        }




    }
}
