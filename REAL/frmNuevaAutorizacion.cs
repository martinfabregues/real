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
using System.Transactions;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmNuevaAutorizacion : Form
    {
        public int serid { get; set; }
        public string sernumero { get;set; }
        public frmNuevaAutorizacion(int sId, string sNu)
        {
            serid = sId;
            sernumero = sNu;
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtCliente.Enabled = false;
            txtFecha.Enabled = false;
            txtFechaComp.Enabled = false;
            txtidSer.Enabled = false;
            txtProveedor.Enabled = false;
            txtRemito.Enabled = false;
            txtService.Enabled = false;
            txtSucursal.Enabled = false;

            txtidSer.Visible = false;

        }

        private void frmNuevaAutorizacion_Load(object sender, EventArgs e)
        {
            IniciarControles();

            DataTable dt = new DataTable();
            //dt = Services.GetServiceDatosPodId(serid);
            if (dt.Rows.Count > 0)
            {
                txtService.Text = dt.Rows[0].ItemArray[1].ToString();
                txtidSer.Text = serid.ToString();
                txtFecha.Text = dt.Rows[0].ItemArray[2].ToString();
                txtProveedor.Text = dt.Rows[0].ItemArray[5].ToString();
                txtSucursal.Text = dt.Rows[0].ItemArray[6].ToString();
                txtRemito.Text = dt.Rows[0].ItemArray[4].ToString();
                txtFechaComp.Text = dt.Rows[0].ItemArray[3].ToString();
                txtCliente.Text = dt.Rows[0].ItemArray[7].ToString();
            }
        }

        Boolean ValidarDatos()
        {
            bool res = false;
            if (txtCobertura.Text != string.Empty)
            {
                if (txtMonto.Text != string.Empty)
                {
                    res = true;
                }
                else
                {
                    res = false;
                    lblValidacion.Text = "DEBE COMPLETAR EL CAMPO MONTO.";
                    txtMonto.Focus();
                }
            }
            else
            {
                res = false;
                lblValidacion.Text = "DEBE COMPLETAR EL CAMPO COBERTURA.";
                txtCobertura.Focus();
            }

            return res;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    if (ValidarDatos() == true)
                    {
                        ServiceAutorizacion sea = new ServiceAutorizacion();
                        sea.seacobertura = Convert.ToInt32(txtCobertura.Text);
                        sea.seafecha = dtpFecha.Value;
                        sea.seaimporte = Convert.ToDecimal(txtMonto.Text);
                        sea.serid = Convert.ToInt32(txtidSer.Text);
                        int resultado = 0;
                        resultado = ServicesAutorizacion.ServiceAutorizacionInsertar(sea);
                        if (resultado > 0)
                        {
                            int res = 0;
                            //res = Services.ServiceAutorizar(sea.serid);
                            if (res > 0)
                            {
                                MessageBox.Show("REGISTRADO CORRECTAMENTE.", "SERVICE - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                scope.Complete();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("OCURRIO UN ERROR AL REGISTRAR LA ENTREGA.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                        else
                        {

                        }
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
