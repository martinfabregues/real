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
    public partial class dlgPendientesEntrega : Form
    {
        public int odcid { get; set; }
        public string odcnumero { get; set; }
        public int prdid { get; set; }
        public string prdcodigo { get; set; }
        public decimal ocdimporte { get; set; }
        public int proid { get; set; }
        public int sucid { get; set; }

        public DateTime fecha { get; set; }
        public dlgPendientesEntrega(int pi, int si)
        {
            proid = pi;
            sucid = si;
            InitializeComponent();
        }

        public dlgPendientesEntrega(int pi)
        {
            proid = pi;
            InitializeComponent();
        }

        private void CargarGrid()
        {
            DataTable dt = new DataTable();
            dt = OrdenesCompraPendiente.GetOrdenCompraPendientePorIdProveedorIdSucursal(proid, sucid);
            if (dt.Rows.Count > 0)
            {
                dgvPendientes.DataSource = dt.DefaultView;
                dgvPendientes.CurrentRow.Selected = false;
                PersonalizarGrid();
            }
        }

        private void PersonalizarGrid()
        {
            dgvPendientes.Columns[0].Visible = false;
            dgvPendientes.Columns[1].Visible = false;
            dgvPendientes.Columns[4].Visible = false;
            dgvPendientes.Columns[6].Visible = false;
            dgvPendientes.Columns[2].HeaderText = "Nro Orden";
            dgvPendientes.Columns[3].HeaderText = "Fecha";
            dgvPendientes.Columns[5].Visible = false;
            dgvPendientes.Columns[7].HeaderText = "Código Prod.";
            dgvPendientes.Columns[8].HeaderText = "Producto";
            dgvPendientes.Columns[9].HeaderText = "Cant.";
            dgvPendientes.Columns[10].HeaderText = "Imp. Unit.";
            dgvPendientes.Columns[11].HeaderText = "Total";
            dgvPendientes.Columns[12].HeaderText = "Depósito";

            dgvPendientes.Columns[10].DefaultCellStyle.Format = "c";
            dgvPendientes.Columns[11].DefaultCellStyle.Format = "c";
            dgvPendientes.Columns[3].DefaultCellStyle.Format = "dd'/'MM'/'yyyy";
        }

        private void dlgPendientesEntrega_Load(object sender, EventArgs e)
        {
            CargarGrid();
            dgvPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //PersonalizarGrid();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvPendientes.SelectedRows.Count > 0)
            {
                if (dgvPendientes.CurrentRow.Index > -1)
                {
                    prdid = Convert.ToInt32(dgvPendientes.CurrentRow.Cells[6].Value);
                    ocdimporte = Convert.ToDecimal(dgvPendientes.CurrentRow.Cells[10].Value);
                    odcid = Convert.ToInt32(dgvPendientes.CurrentRow.Cells[1].Value);
                    odcnumero = dgvPendientes.CurrentRow.Cells[2].Value.ToString();
                    prdcodigo = dgvPendientes.CurrentRow.Cells[7].Value.ToString();
                    fecha = Convert.ToDateTime(dgvPendientes.CurrentRow.Cells[3].Value);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text != string.Empty)
            {
                DataTable dt = new DataTable();
                dt = OrdenesCompraPendiente.GetOrdenCompraPendientePorNombreProductoPorProveedorPorSucursal(txtProducto.Text, proid, sucid);
                if (dt.Rows.Count > 0)
                {
                    dgvPendientes.DataSource = dt.DefaultView;
                    dgvPendientes.CurrentRow.Selected = false;
                    PersonalizarGrid();
                }


            }
            else
            {
                CargarGrid();
                PersonalizarGrid();
            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text != string.Empty)
            {
                DataTable dt = new DataTable();
                dt = OrdenesCompraPendiente.GetOrdenCompraPendientePorNombreProductoPorProveedorPorSucursal(txtProducto.Text, proid,sucid);
                if (dt.Rows.Count > 0)
                {
                    dgvPendientes.DataSource = dt.DefaultView;
                    PersonalizarGrid();
                }


            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //
            // Si el control DataGridView no tiene el foco, 
            // se abandonamos el procedimiento, llamando al metodo base
            //
            if ((!dgvPendientes.Focused))
                return base.ProcessCmdKey(ref msg, keyData);

            //
            // Si la tecla presionada es distinta al ENTER, 
            // se abandonamos el procedimiento, llamando al metodo base
            //
            if (keyData != Keys.Enter)
                return base.ProcessCmdKey(ref msg, keyData);
            //
            // Obtenemos la fila actual 
            //
            DataGridViewRow row = dgvPendientes.CurrentRow;
            prdid = Convert.ToInt32(dgvPendientes.CurrentRow.Cells[6].Value);
            ocdimporte = Convert.ToDecimal(dgvPendientes.CurrentRow.Cells[10].Value);
            odcid = Convert.ToInt32(dgvPendientes.CurrentRow.Cells[1].Value);
            odcnumero = dgvPendientes.CurrentRow.Cells[2].Value.ToString();
            prdcodigo = dgvPendientes.CurrentRow.Cells[7].Value.ToString();
            fecha = Convert.ToDateTime(dgvPendientes.CurrentRow.Cells[3].Value);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //frmSeleccion frm = new frmSeleccion(cuenta, desc);
            //frm.ShowDialog();


            return true;
        } 

       
    }
}
