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
    public partial class frmConsultaIngresoProveedor : Form
    {
        public frmConsultaIngresoProveedor()
        {
            InitializeComponent();
        }


        private void IniciarControles()
        {

            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;
            cmbProveedor.Enabled = false;
            cmbSucursal.Enabled = false;
        }

        private void CargarGrilla()
        {
            DataTable dt = new DataTable();
            dt = FacturasProveedorDetalle.GetFacturaProveedorTodo();
            if(dt.Rows.Count>0)
            {
                dgvEntregas.DataSource = dt.DefaultView;
                PersonalizarGrilla();
            }
            
        }

        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetTodos();

        }

        private void CargarComboBoxSucursal()
        {
            cmbSucursal.ValueMember = "sucid";
            cmbSucursal.DisplayMember = "sucnombre";
            cmbSucursal.DataSource = Sucursales.GetTodos();

        }

        private void PersonalizarGrilla()
        {
            dgvEntregas.Columns[0].Visible = false;
            dgvEntregas.Columns[1].HeaderText = "N° FAC";
            dgvEntregas.Columns[2].HeaderText = "N° REM";
            dgvEntregas.Columns[3].HeaderText = "FECHA FAC";
            dgvEntregas.Columns[4].HeaderText = "FECHA REC";
            dgvEntregas.Columns[5].HeaderText = "SUCURSAL";
            dgvEntregas.Columns[6].HeaderText = "PRODUCTO";
            dgvEntregas.Columns[7].HeaderText = "CANT";
            dgvEntregas.Columns[8].HeaderText = "IMP UNIT";
            dgvEntregas.Columns[9].HeaderText = "TOTAL";
            dgvEntregas.Columns[10].HeaderText = "O.COMPRA";

            dgvEntregas.Columns[8].DefaultCellStyle.Format = "c";
            dgvEntregas.Columns[9].DefaultCellStyle.Format = "c";

            dgvEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEntregas.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        private void frmConsultaIngresoProveedor_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            IniciarControles();
            CargarGrilla();
            CargarComboBoxProveedor();
            CargarComboBoxSucursal();
        }

        private void frmConsultaIngresoProveedor_Resize(object sender, EventArgs e)
        {
            dgvEntregas.Width = this.Width - 40;
            dgvEntregas.Height = this.Height - 300;
            groupBox1.Width = this.Width - 40;
            btnAceptar.Location = new Point(20, this.Height - 70);
            btnCancelar.Location = new Point(this.Width - 100, this.Height - 70);
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text != string.Empty)
            {
                DataTable dt = new DataTable();
                dt = FacturasProveedorDetalle.GetFacturaProveedorTodoPorNombreProducto(txtProducto.Text);
                if (dt.Rows.Count > 0)
                {
                    dgvEntregas.DataSource = dt.DefaultView;
                    PersonalizarGrilla();
                }
                else
                {
                    dgvEntregas.DataSource = null;
                }
            }
        }

        private void txtFactura_TextChanged(object sender, EventArgs e)
        {
            if (txtFactura.Text != string.Empty)
            {
                DataTable dt = new DataTable();
                dt = FacturasProveedorDetalle.GetFacturaProveedorTodoPorNumeroFactura(txtFactura.Text);
                if (dt.Rows.Count > 0)
                {
                    dgvEntregas.DataSource = dt.DefaultView;
                    PersonalizarGrilla();
                }
                else
                {
                    dgvEntregas.DataSource = null;
                }
            }
        }

        private void txtRemito_TextChanged(object sender, EventArgs e)
        {
            if (txtRemito.Text != string.Empty)
            {
                DataTable dt = new DataTable();
                dt = FacturasProveedorDetalle.GetFacturaProveedorTodoPorNumeroRemito(txtRemito.Text);
                if (dt.Rows.Count > 0)
                {
                    dgvEntregas.DataSource = dt.DefaultView;
                    PersonalizarGrilla();
                }
                else
                {
                    dgvEntregas.DataSource = null;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (ckbFecha.Checked == true)
            {
                if (dtpDesde.Value <= dtpHasta.Value)
                {
                    DataTable dt = new DataTable();
                    dt = FacturasProveedorDetalle.GetFacturaProveedorTodoEntreFechas(dtpDesde.Value, dtpHasta.Value);
                    if (dt.Rows.Count > 0)
                    {
                        dgvEntregas.DataSource = dt.DefaultView;
                        PersonalizarGrilla();

                    }
                    else
                    {
                        dgvEntregas.DataSource = null;
                    }
                }
                else
                {
                    errorProvider1.SetError(dtpDesde, "LA FECHA INICIAL NO PUEDE SER MAYOR A LA FINAL");
                }

            }
            else
            {
                if (ckbProveedor.Checked == true)
                {
                    DataTable dt = new DataTable();
                    dt = FacturasProveedorDetalle.GetFacturaProveedorTodoPorIdProveedor(Convert.ToInt32(cmbProveedor.SelectedValue));
                    if (dt.Rows.Count > 0)
                    {
                        dgvEntregas.DataSource = dt.DefaultView;
                        PersonalizarGrilla();
                    }
                    else
                    {
                        dgvEntregas.DataSource = null;
                    }

                }
                else
                {

                    if (ckbSucursal.Checked == true)
                    {
                        DataTable dt = new DataTable();
                        dt = FacturasProveedorDetalle.GetFacturaProveedorTodoPorIdSucursal(Convert.ToInt32(cmbSucursal.SelectedValue));
                        if (dt.Rows.Count > 0)
                        {

                            dgvEntregas.DataSource = dt.DefaultView;
                            PersonalizarGrilla();

                        }
                        else
                        {
                            dgvEntregas.DataSource = null;
                        }



                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        dt = FacturasProveedorDetalle.GetFacturaProveedorTodo();
                        if (dt.Rows.Count > 0)
                        {
                            dgvEntregas.DataSource = dt.DefaultView;
                            PersonalizarGrilla();
                        }
                        else
                        {
                            dgvEntregas.DataSource = null;
                        }

                    }


                }

            }
        }

        private void ckbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFecha.Checked == true)
            {
                dtpHasta.Enabled = true;
                dtpDesde.Enabled = true;
                cmbSucursal.Enabled = false;
                cmbProveedor.Enabled = false;
                ckbProveedor.CheckState = CheckState.Unchecked;
                ckbSucursal.CheckState = CheckState.Unchecked;
            }
            else
            {
                dtpHasta.Enabled = false;
                dtpDesde.Enabled = false;
            }
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO REMITO";
                e.Handled = true;
                txtFactura.Focus();
                return;
            }
        }

        private void txtRemito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO REMITO";
                e.Handled = true;
                txtRemito.Focus();
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbProveedor.Checked == true)
            {
                cmbProveedor.Enabled = true;
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
                cmbSucursal.Enabled = false;
                ckbFecha.CheckState = CheckState.Unchecked;
                ckbSucursal.CheckState = CheckState.Unchecked;

            }
            else
            {
                cmbProveedor.Enabled = false;
            }
        }

        private void ckbSucursal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSucursal.Checked == true)
            {
                cmbSucursal.Enabled = true;
                cmbProveedor.Enabled = false;
                dtpHasta.Enabled = false;
                dtpDesde.Enabled = false;
                ckbFecha.CheckState = CheckState.Unchecked;
                ckbProveedor.CheckState = CheckState.Unchecked;
            }
            else
            {
                cmbSucursal.Enabled = false;
            }
        }

      
    }
}
