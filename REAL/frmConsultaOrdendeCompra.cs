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
    public partial class frmConsultaOrdendeCompra : Form
    {
        public frmConsultaOrdendeCompra()
        {
            InitializeComponent();
        }

        private void CargarGrid()
        {
            DataTable dt = new DataTable();
            dt = OrdenesCompra.GetOrdenCompraTodo();
            if (dt.Rows.Count > 0)
            {
                dgvOrdenes.DataSource = dt.DefaultView;
                dgvOrdenes.CurrentRow.Selected = false;
                PersonalizarGrid();
                AgregarColumnas();
            }
        }

        private void IniciarControles()
        {
            txtOrden.Text = string.Empty;
            txtOrden.Enabled = false;
            cmbProveedor.Enabled = false;
        }

        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetProveedoresDatos();
        }


        private void AgregarColumnas()
        {

            DataGridViewButtonColumn Detalle = new DataGridViewButtonColumn();
            Detalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Detalle.HeaderText = "Detalle";
            Detalle.Name = "btnDetalle";
            Detalle.Text = "Ver Detalle";
            Detalle.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn Impresion = new DataGridViewButtonColumn();
            Impresion.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Impresion.HeaderText = "Imprimir";
            Impresion.Name = "btnImprimir";
            Impresion.Text = "Imprimir Orden";
            Impresion.UseColumnTextForButtonValue = true;

            dgvOrdenes.Columns.Add(Detalle);
            dgvOrdenes.Columns.Add(Impresion);
        }


        private void PersonalizarGrid()
        {


           


            dgvOrdenes.Columns[0].Visible = false;
            dgvOrdenes.Columns[1].HeaderText = "N° Orden";
            dgvOrdenes.Columns[2].HeaderText = "Fecha";
            dgvOrdenes.Columns[3].HeaderText = "Proveedor";
            dgvOrdenes.Columns[4].HeaderText = "Importe";

            dgvOrdenes.Columns[4].DefaultCellStyle.Format = "c";
            dgvOrdenes.Columns[2].DefaultCellStyle.Format = "dd'/'MM'/'yyyy";

            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenes.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }


        private void frmConsultaOrdendeCompra_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
            IniciarControles();
            CargarGrid();
            CargarComboBoxProveedor();
            //PersonalizarGrid();
            //AgregarColumnas();

        }

        private void frmConsultaOrdendeCompra_Resize(object sender, EventArgs e)
        {
            dgvOrdenes.Width = this.Width - 40;
            dgvOrdenes.Height = this.Height - 250;
            btnCerrar.Location = new Point(this.Width - 110, this.Height - 100);
        }

        private void dgvOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrdenes.Columns[e.ColumnIndex].Name == "btnDetalle")
            {
                DataGridViewRow fila = dgvOrdenes.CurrentRow;

                int id = Convert.ToInt32(fila.Cells["odcid"].Value);
                frmDetalleOrdenCompra frm = new frmDetalleOrdenCompra(id);
                string fmt = "00000000.##";
                //falta agregarle el numero de orden
                frm.Text = "DETALLE ORDEN DE COMPRA ";
                frm.ShowDialog();
            }

            if (dgvOrdenes.Columns[e.ColumnIndex].Name == "btnImprimir")
            {
                DataGridViewRow fila = dgvOrdenes.CurrentRow;

                int id = Convert.ToInt32(fila.Cells["odcid"].Value);
                frmReporteOrdenCompra frm = new frmReporteOrdenCompra(id);
                frm.MdiParent = this.MdiParent;
                string fmt = "00000000.##";
                frm.Text = "IMPRESIÓN ORDEN DE COMPRA N° " + id.ToString(fmt);
                frm.Show();
            }
        }

        private void ckbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            txtOrden.Text = string.Empty;
            if (ckbProveedor.Checked == true)
            {
                cmbProveedor.Enabled = true;
                txtOrden.Enabled = false;
                ckbNumero.CheckState = CheckState.Unchecked;
            }
            else
            {
                cmbProveedor.Enabled = false;
            }
        }

        private void ckbNumero_CheckedChanged(object sender, EventArgs e)
        {
            txtOrden.Text = string.Empty;
            if (ckbNumero.Checked == true)
            {
                txtOrden.Enabled = true;
                cmbProveedor.Enabled = false;
                ckbProveedor.CheckState = CheckState.Unchecked;
            }
            else
            {
                txtOrden.Enabled = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ckbProveedor.Checked == true)
            {
                dgvOrdenes.Columns.Clear();
                DataTable dt = new DataTable();
                dt = OrdenesCompra.GetPorIdProveedor(Convert.ToInt32(cmbProveedor.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    dgvOrdenes.DataSource = dt.DefaultView;
                    PersonalizarGrid();
                    AgregarColumnas();
                }
            }
            else
            {
                if (ckbNumero.Checked == true)
                {
                    dgvOrdenes.Columns.Clear();
                    DataTable dt = new DataTable();
                    dt = OrdenesCompra.GetDatosPorNumero(txtOrden.Text);
                    if (dt.Rows.Count > 0)
                    {
                        dgvOrdenes.DataSource = dt.DefaultView;
                        PersonalizarGrid();
                        AgregarColumnas();
                    }
                }
                else
                {
                    dgvOrdenes.Columns.Clear();
                    CargarGrid();
                    //PersonalizarGrid();
                }
            }
        }

        private void txtOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO N° ORDEN DE COMPRA.";
                e.Handled = true;
                txtOrden.Focus();
                return;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOrden_TextChanged(object sender, EventArgs e)
        {
          
            if (txtOrden.Text != string.Empty)
            {
                dgvOrdenes.Columns.Clear();
                DataTable dt = new DataTable();
                dt = OrdenesCompra.GetDatosPorNumero(txtOrden.Text);
                if (dt.Rows.Count > 0)
                {
                    dgvOrdenes.DataSource = dt.DefaultView;
                    PersonalizarGrid();
                    AgregarColumnas();
                }
            }
        }
    }
}
