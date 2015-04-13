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
    public partial class frmNuevaDevolucion : Form
    {
        public frmNuevaDevolucion()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtCliente.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtFechaComp.Text = string.Empty;
            txtidSer.Text = string.Empty;
            //txtObservacion.Text = string.Empty;
            txtProveedor.Text = string.Empty;
            txtService.Text = string.Empty;
            txtSucursal.Text = string.Empty;
            txtRemito.Text = string.Empty;


            txtCliente.Enabled = false;
            txtFecha.Enabled = false;
            txtFechaComp.Enabled = false;
            txtidSer.Enabled = false;
            txtProveedor.Enabled = false;
            txtRemito.Enabled = false;
            txtService.Enabled = false;
            txtSucursal.Enabled = false;
            txtObservacion.Text = string.Empty;

            txtidSer.Visible = false;
            //dgvDevoluciones.DataSource = null;
        }

        private void frmNuevaDevolucion_Load(object sender, EventArgs e)
        {
            IniciarControles();
            CrearGrilla();
        }

        private void CrearGrilla()
        {
            DataGridViewButtonColumn Eliminar = new DataGridViewButtonColumn();
            Eliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Eliminar.HeaderText = "Eliminar";
            Eliminar.Name = "btnEliminar";
            Eliminar.Text = "Eliminar del Detalle";
            Eliminar.UseColumnTextForButtonValue = true;

            dgvDevoluciones.Columns.Add(Eliminar);
        }


        private void BuscarDatosService(int serid)
        {
            DataTable dt = new DataTable();
            //dt = Services.GetServiceDatosPodId(serid);
            if (dt.Rows.Count > 0)
            {
                txtService.Text = dt.Rows[0].ItemArray[1].ToString();
                txtidSer.Text = serid.ToString();
                txtFecha.Text = Convert.ToDateTime(dt.Rows[0].ItemArray[2]).ToShortDateString();
                txtProveedor.Text = dt.Rows[0].ItemArray[5].ToString();
                txtSucursal.Text = dt.Rows[0].ItemArray[6].ToString();
                txtRemito.Text = dt.Rows[0].ItemArray[4].ToString();
                txtFechaComp.Text = Convert.ToDateTime(dt.Rows[0].ItemArray[3]).ToShortDateString();
                txtCliente.Text = dt.Rows[0].ItemArray[7].ToString();
            }
        
        }

        private void btnBuscarService_Click(object sender, EventArgs e)
        {
            dlgServices dlg = new dlgServices();
            dlg.Text = "SERVICE - LISTADO DE SERVICE";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtidSer.Text = dlg.serId.ToString();
                txtService.Text = dlg.serCodigo.ToString();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtService_TextChanged(object sender, EventArgs e)
        {
            if (txtService.Text != string.Empty)
            {
                BuscarDatosService(Convert.ToInt32(txtidSer.Text));
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (txtService.Text != string.Empty)
            {
                if (txtCliente.Text != string.Empty)
                {
                    dgvDevoluciones.Rows.Add(txtidSer.Text, txtService.Text, txtFecha.Text, txtCliente.Text);
                    IniciarControles();
                }
                else
                {
                  
                    txtService.Focus();
                }
            }
            else
            {
              
                txtService.Focus();
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvDevoluciones.Rows.Count > 0)
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        ServiceDevolucion sde = new ServiceDevolucion();
                        sde.sedfecha = dtpFechaDev.Value;
                        sde.sedobservacion = txtObservacion.Text;

                        int res = ServicesDevolucion.ServiceDevolucionInsertar(sde);
                        if (res > 0)
                        {
                            ServiceDevolucionDetalle sdet = new ServiceDevolucionDetalle();
                            bool r = false;
                            foreach(DataGridViewRow dr in dgvDevoluciones.Rows)
                            {
                                sdet.sedid = res;
                                sdet.serid = Convert.ToInt32(dr.Cells[0].Value);
                                int resdet = ServicesDevolucionDetalle.ServiceDevolucionDetalleInsertar(sdet);
                                if (resdet == 0)
                                {
                                    r = true;
                                    break;
                                }
                            }
                            if (r != true)
                            {
                                scope.Complete();
                                IniciarControles();
                                dgvDevoluciones.Rows.Clear();
                                txtObservacion.Text = string.Empty;
                                MessageBox.Show("DEVOLUCIÓN REGISTRADA CORRECTAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                MessageBox.Show("OCURRIO UN ERROR AL REGISTRAR LA DEVOLUCIÓN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

    
}

