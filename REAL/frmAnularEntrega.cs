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
    public partial class frmAnularEntrega : Form
    {
        public frmAnularEntrega()
        {
            InitializeComponent();
            IniciarControles();
        }


        private void IniciarControles()
        {
            txtCalle.Enabled = false;
            txtBarrio.Enabled = false;
            txtDepto.Enabled = false;
            txtFecha.Enabled = false;
            txtNumero.Enabled = false;
            txtPiso.Enabled = false;
            txtSucursal.Enabled = false;
            txtTipo.Enabled = false;
            txtCosto.Enabled = false;
            txtid.Visible = false;
            lblValidacion.Text = string.Empty;
            CargarComboBoxSucursal();
            dgvDetalle.DataSource = null;

        }

        private void LimpiarControles()
        {
            txtCalle.Text = string.Empty;
            txtBarrio.Text = string.Empty;
            txtDepto.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtPiso.Text = string.Empty;
            txtSucursal.Text = string.Empty;
            txtid.Text = string.Empty;
            txtTipo.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtRemito.Text = string.Empty;
            //lblValidacion.Text = string.Empty;
            txtRemito.Focus();
            dgvDetalle.DataSource = null;
        }

        private void CargarComboBoxSucursal()
        {
            cmbSucursal.ValueMember = "sucid";
            cmbSucursal.DisplayMember = "sucnombre";
            cmbSucursal.DataSource = Sucursales.SucursalObtenerTodo().DefaultView;
            cmbSucursal.SelectedIndex = 0;
        }

        private void frmAnularEntrega_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtRemito.Text != string.Empty)
            {
                if (txtRemito.TextLength == 8)
                {
                    lblValidacion.Text = string.Empty;
                    DataTable dt = new DataTable();
                    dt = Entregas.GetEntregaPorSucursalRemito(Convert.ToInt32(cmbSucursal.SelectedValue), txtRemito.Text);
                    if (dt.Rows.Count > 0)
                    {
                        txtid.Text = dt.Rows[0].ItemArray[0].ToString();
                        txtFecha.Text = Convert.ToDateTime(dt.Rows[0].ItemArray[2].ToString()).ToShortDateString();
                        txtCalle.Text = dt.Rows[0].ItemArray[3].ToString();
                        txtNumero.Text = dt.Rows[0].ItemArray[4].ToString();
                        txtPiso.Text = dt.Rows[0].ItemArray[5].ToString();
                        txtDepto.Text = dt.Rows[0].ItemArray[6].ToString();
                        txtBarrio.Text = dt.Rows[0].ItemArray[7].ToString();
                        txtSucursal.Text = dt.Rows[0].ItemArray[8].ToString();
                        txtTipo.Text = dt.Rows[0].ItemArray[9].ToString();
                        txtCosto.Text = dt.Rows[0].ItemArray[10].ToString();

                        DataTable dtDetalle = new DataTable();
                        dtDetalle = EntregasDetalle.GetEntregaDetallePorId(Convert.ToInt32(txtid.Text));
                        if (dtDetalle.Rows.Count > 0)
                        {
                            dgvDetalle.DataSource = dtDetalle.DefaultView;
                            PersonalizarGridDetalle();
                        }

                    }
                    else
                    {
                        LimpiarControles();
                        lblValidacion.Text = "NO SE ENCONTRO EL NÚMERO DE REMITO.";
                    }
                }
                else
                {
                    lblValidacion.Text = "EL FORMATO DEL CAMPO NÚMERO DE REMITO, ES INCORRECTO.";
                }
            }
            else
            {
                txtRemito.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Entregas.GetEntregasEstado(Convert.ToInt32(txtid.Text));
            if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) != 3)
            {
                lblValidacion.Text = string.Empty;
                int resultado = Entregas.EntregaAnular(Convert.ToInt32(txtid.Text));
                if (resultado > 0)
                {
                    MessageBox.Show("ANULACIÓN REGISTRADA CORRECTAMENTE.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRemito.Focus();
                    LimpiarControles();
                }
                else
                {
                    MessageBox.Show("OCURRIO UN ERROR AL REGISTRAR LA ANULACIÓN.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRemito.Focus();
                    LimpiarControles();
                }
            }
            else
            {
                MessageBox.Show("LA ENTREGA YA SE ENCUENTRA ANULADA.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRemito.Focus();
                LimpiarControles();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRemito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO NÚMERO REMITO.";
                e.Handled = true;
                txtRemito.Focus();
                return;
            }
        }


        private void PersonalizarGridDetalle()
        {
            dgvDetalle.Columns[0].Visible = false;
            dgvDetalle.Columns[1].Visible = false;
            dgvDetalle.Columns[2].HeaderText = "PRODUCTO";
            dgvDetalle.Columns[3].HeaderText = "CANTIDAD";
            dgvDetalle.Columns[4].HeaderText = "SALIDA";

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }



    }
}
