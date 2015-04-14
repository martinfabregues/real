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
    public partial class frmConsultaPendientes : Form
    {
        public frmConsultaPendientes()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtOrden.Enabled = false;
            txtProducto.Enabled = false;
            cmbProveedor.Enabled = false;
            cmbSucursal.Enabled = false;
            dgvPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void CargarGrid()
        {
            DataTable dt = new DataTable();
            dt = OrdenesCompraPendiente.GetOrdenCompraPendienteTodo();
            if (dt.Rows.Count > 0)
            {
                dgvPendientes.DataSource = dt.DefaultView;
                dgvPendientes.CurrentRow.Selected = false;
                CalcularTotal();
            }
            else
            {

            }
       
        }

        private void PersonalizarGrid()
        {
            dgvPendientes.Columns[0].Visible = false;
            dgvPendientes.Columns[1].Visible = false;
            dgvPendientes.Columns[4].Visible = false;
            dgvPendientes.Columns[6].Visible = false;
            dgvPendientes.Columns[2].HeaderText = "Nro. Orden";
            dgvPendientes.Columns[3].HeaderText = "Fecha";
            dgvPendientes.Columns[5].HeaderText = "Proveedor";
            dgvPendientes.Columns[7].HeaderText = "Cod. Prod.";
            dgvPendientes.Columns[8].HeaderText = "Producto";
            dgvPendientes.Columns[9].HeaderText = "Cant.";
            dgvPendientes.Columns[10].HeaderText = "Imp. Unit.";
            dgvPendientes.Columns[11].HeaderText = "Total";
            dgvPendientes.Columns[12].HeaderText = "Sucursal";

            //dgvPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvPendientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
            dgvPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPendientes.Columns[10].DefaultCellStyle.Format = "c";
            dgvPendientes.Columns[11].DefaultCellStyle.Format = "c";
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow dr in dgvPendientes.Rows)
            {
                total = total + Convert.ToDecimal(dr.Cells[7].Value);
            }
            lblTotal.Text = "$ " + total;
        }

        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetProveedoresDatos();
        }

        private void CargarComboBoxSucursal()
        {
            cmbSucursal.ValueMember = "sucid";
            cmbSucursal.DisplayMember = "sucnombre";
            cmbSucursal.DataSource = Sucursales.GetTodos();

        }

        private void CargarDataGrid()
        {
            var query = (from row in OrdenesCompra.FindPendientes()
                         select new
                         {
                             row.ordencompra.odcnumero,
                             row.ordencompra.odcfecha,
                             row.proveedor.pronombre,
                             row.producto.prdcodigo,
                             row.producto.prddenominacion,
                             row.ocdcantidad,
                             row.ocdimporte,
                             total = (row.ocdcantidad * row.ocdimporte),
                             row.sucursal.sucnombre

                         }).ToList();

            dgvPendientes.Rows.Clear();
            foreach (var fila in query)
            {
                dgvPendientes.Rows.Add(fila.odcnumero, fila.odcfecha.ToShortDateString(), fila.pronombre, fila.prdcodigo,
                    fila.prddenominacion, fila.ocdcantidad, fila.ocdimporte, fila.total, fila.sucnombre);
            }

            CalcularTotal();
        }

        private void FiltrarForm()
        {
            int? proveedor_id = ckbProveedor.Checked ? (int?)Convert.ToInt32(cmbProveedor.SelectedValue) : null;
            int? sucursal_id = ckbSucursal.Checked ? (int?)Convert.ToInt32(cmbSucursal.SelectedValue) : null;
            
            string numero_orden = txtOrden.Text == string.Empty ? null : txtOrden.Text;
            string producto = txtProducto.Text == string.Empty ? null : txtProducto.Text;

            var query = (from row in OrdenesCompra.FindPendientesCondicional(proveedor_id, sucursal_id, numero_orden, producto)
                         select new
                         {
                             row.ordencompra.odcnumero,
                             row.ordencompra.odcfecha,
                             row.proveedor.pronombre,
                             row.producto.prdcodigo,
                             row.producto.prddenominacion,
                             row.ocdcantidad,
                             row.ocdimporte,
                             total = (row.ocdcantidad * row.ocdimporte),
                             row.sucursal.sucnombre

                         }).ToList();

            dgvPendientes.Rows.Clear();
            foreach (var fila in query)
            {
                dgvPendientes.Rows.Add(fila.odcnumero, fila.odcfecha.ToShortDateString(), fila.pronombre, fila.prdcodigo,
                    fila.prddenominacion, fila.ocdcantidad, fila.ocdimporte, fila.total, fila.sucnombre);
            }

            CalcularTotal();

        }

        private void frmConsultaPendientes_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            IniciarControles();
            //CargarGrid();
            //if (dgvPendientes.Rows.Count > 0)
            //{
            //    PersonalizarGrid();
            //}
            
            CargarComboBoxProveedor();
            CargarComboBoxSucursal();

            CargarDataGrid();
        }

        private void frmConsultaPendientes_Resize(object sender, EventArgs e)
        {
            this.dgvPendientes.Width = this.Width - 40;
            this.dgvPendientes.Height = this.Height - 260;
            this.btnAceptar.Location = new Point(this.Width - 100, this.Height - 80);
            this.groupBox2.Location = new Point(20, this.Height - 120);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            cmbProveedor.SelectedIndex = 0;

            if (ckbProveedor.CheckState == CheckState.Checked)
                cmbProveedor.Enabled = true;
            else
                cmbProveedor.Enabled = false;

            //txtOrden.Text = string.Empty;
            //txtProducto.Text = string.Empty;
            //if (ckbProveedor.Checked == true)
            //{
            //    cmbProveedor.Enabled = true;
            //    //cmbSucursal.Enabled = false;
            //    txtProducto.Enabled = false;
            //    txtOrden.Enabled = false;
            //    ckbOrden.CheckState = CheckState.Unchecked;
            //    ckbProducto.CheckState = CheckState.Unchecked;
            //    //ckbSucursal.CheckState = CheckState.Unchecked;
            //}
            //else
            //{
            //    cmbProveedor.Enabled = false;
            //}
        }

        private void ckbOrden_CheckedChanged(object sender, EventArgs e)
        {
            txtOrden.Text = string.Empty;

            if (ckbOrden.CheckState == CheckState.Checked)
                txtOrden.Enabled = true;
            else
                txtOrden.Enabled = false;
            
            //txtOrden.Text = string.Empty;
            //txtProducto.Text = string.Empty;
            //if (ckbOrden.Checked == true)
            //{
            //    txtOrden.Enabled = true;
            //    cmbProveedor.Enabled = false;
            //    cmbSucursal.Enabled = false;
            //    txtProducto.Enabled = false;
            //    ckbProducto.CheckState = CheckState.Unchecked;
            //    ckbProveedor.CheckState = CheckState.Unchecked;
            //    ckbSucursal.CheckState = CheckState.Unchecked;
            //}
            //else
            //{
            //    txtOrden.Enabled = false;
            //}
        }

        private void ckbProducto_CheckedChanged(object sender, EventArgs e)
        {
            txtProducto.Text = string.Empty;

            if (ckbProducto.CheckState == CheckState.Checked)
                txtProducto.Enabled = true;
            else
                txtProducto.Enabled = false;
                
            
            //txtOrden.Text = string.Empty;
            //txtProducto.Text = string.Empty;
            //if (ckbProducto.Checked == true)
            //{
            //    txtProducto.Enabled = true;
            //    cmbProveedor.Enabled = false;
            //    cmbSucursal.Enabled = false;
            //    txtOrden.Enabled = false;
            //    ckbOrden.CheckState = CheckState.Unchecked;
            //    ckbProveedor.CheckState = CheckState.Unchecked;
            //    ckbSucursal.CheckState = CheckState.Unchecked;
            //}
            //else
            //{
            //    txtProducto.Enabled = false;
            //}
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarForm();


            //if (ckbProveedor.Checked == true)
            //{
            //    if (ckbSucursal.Checked == true)
            //    {
            //        DataTable dt = new DataTable();
            //        dt = OrdenesCompraPendiente.GetOrdenCompraPendientePorIdProveedorPorSucursal(Convert.ToInt32(cmbProveedor.SelectedValue), Convert.ToInt32(cmbSucursal.SelectedValue));
            //        if (dt.Rows.Count > 0)
            //        {
            //            dgvPendientes.DataSource = dt.DefaultView;
            //            CalcularTotal();
            //        }
            //        else
            //        {
            //            dgvPendientes.DataSource = null;
            //        }
            //    }
            //    else
            //    {
            //        DataTable dt = new DataTable();
            //        dt = OrdenesCompraPendiente.GetOrdenCompraPendientePorIdProveedor(Convert.ToInt32(cmbProveedor.SelectedValue));
            //        if (dt.Rows.Count > 0)
            //        {
            //            dgvPendientes.DataSource = dt.DefaultView;
            //            PersonalizarGrid();
            //            CalcularTotal();
            //        }
            //        else
            //        {
            //            dgvPendientes.DataSource = null;
            //        }
            //    }
            //}
            //else
            //{
            //    if (ckbOrden.Checked == true)
            //    {
            //        DataTable dt = new DataTable();
            //        dt = OrdenesCompraPendiente.GetOrdenCompraPendientePorNumeroOrden(txtOrden.Text);
            //        if (dt.Rows.Count > 0)
            //        {
            //            dgvPendientes.DataSource = dt.DefaultView;
            //            PersonalizarGrid();
            //            CalcularTotal();
            //        }
            //        else
            //        {
            //            dgvPendientes.DataSource = null;
            //        }

            //    }
            //    else
            //    {
            //        if (ckbProducto.Checked == true)
            //        {
            //            DataTable dt = new DataTable();
            //            dt = OrdenesCompraPendiente.GetOrdenCompraPendientePorNombreProducto(txtProducto.Text);
            //            if (dt.Rows.Count > 0)
            //            {

            //                dgvPendientes.DataSource = dt.DefaultView;
            //                PersonalizarGrid();
            //                CalcularTotal();
            //            }
            //            else
            //            {
            //                dgvPendientes.DataSource = null;
            //            }
            //        }
            //        else
            //        {
            //            if (ckbSucursal.Checked == true)
            //            {
            //                DataTable dt = new DataTable();
            //                dt = OrdenesCompraPendiente.GetOrdenCompraPendientePorNombreProducto(txtProducto.Text);
            //                if (dt.Rows.Count > 0)
            //                {
            //                    dgvPendientes.DataSource = OrdenesCompraPendiente.GetOrdenCompraPendientePorIdSucursal(Convert.ToInt32(cmbSucursal.SelectedValue));
            //                    CalcularTotal();
            //                }
            //                else
            //                {
            //                    dgvPendientes.DataSource = null;
            //                }
            //            }
            //            else
            //            {
                        
            //                    CargarGrid();
            //                    if (dgvPendientes.Rows.Count > 0)
            //                    {
            //                        PersonalizarGrid();
            //                        CalcularTotal();
            //                    }
            //                    else
            //                    {
            //                        dgvPendientes.DataSource = null;
            //                    }
                           
            //            }
            //        }
            //    }
            //}
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            FiltrarForm();

            //if (txtProducto.Text != string.Empty)
            //{
            //    DataTable dt = new DataTable();
            //    dt = OrdenesCompraPendiente.GetOrdenCompraPendientePorNombreProducto(txtProducto.Text);
            //    if (dt.Rows.Count > 0)
            //    {

            //        dgvPendientes.DataSource = dt.DefaultView;
            //        PersonalizarGrid();
            //        CalcularTotal();
            //    }
            //    else
            //    {
            //        dgvPendientes.DataSource = null;
            //    }
            //}
        }

        private void txtOrden_TextChanged(object sender, EventArgs e)
        {
            FiltrarForm();

            //if (txtOrden.Text != string.Empty)
            //{
            //    DataTable dt = new DataTable();
            //    dt = OrdenesCompraPendiente.GetOrdenCompraPendientePorNumeroOrden(txtOrden.Text);
            //    if (dt.Rows.Count > 0)
            //    {
            //        dgvPendientes.DataSource = dt.DefaultView;
            //        PersonalizarGrid();
            //        CalcularTotal();
            //    }
            //    else
            //    {
            //        dgvPendientes.DataSource = null;
            //    }
            //}
        }

        private void ckbSucursal_CheckedChanged(object sender, EventArgs e)
        {
            cmbSucursal.SelectedIndex = 0;

            if (ckbSucursal.CheckState == CheckState.Checked)
                cmbSucursal.Enabled = true;
            else
                cmbSucursal.Enabled = false;
            
            
            //txtOrden.Text = string.Empty;
            //txtProducto.Text = string.Empty;
            //if (ckbSucursal.Checked == true)
            //{
            //    cmbSucursal.Enabled = true;
            //    //cmbProveedor.Enabled = false;
            //    txtOrden.Enabled = false;
            //    txtProducto.Enabled = false;
            //    //ckbProveedor.CheckState = CheckState.Unchecked;
            //    ckbOrden.CheckState = CheckState.Unchecked;
            //    ckbProducto.CheckState = CheckState.Unchecked;

            //}
            //else
            //{
            //    cmbSucursal.Enabled = false;

            //}

        }

      
    }
}
