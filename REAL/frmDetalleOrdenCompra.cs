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
    public partial class frmDetalleOrdenCompra : Form
    {
        public int id { get; set; }
        public frmDetalleOrdenCompra(int ocI)
        {
            id = ocI;
            InitializeComponent();
        }


        private void PersonalizarGrid()
        {
            dgvOrdenCompra.Columns[0].Visible = false;
            dgvOrdenCompra.Columns[1].Visible = false;
            dgvOrdenCompra.Columns[2].HeaderText = "N° O.COMP.";
            dgvOrdenCompra.Columns[3].HeaderText = "FECHA";
            dgvOrdenCompra.Columns[4].Visible = false;
            dgvOrdenCompra.Columns[5].Visible = false;
            dgvOrdenCompra.Columns[6].Visible = false;
            dgvOrdenCompra.Columns[7].Visible = false;
            dgvOrdenCompra.Columns[8].Visible = false;
            dgvOrdenCompra.Columns[9].HeaderText = "CANT.";
            dgvOrdenCompra.Columns[10].HeaderText = "COD.PROD.";
            dgvOrdenCompra.Columns[11].HeaderText = "PRODUCTO";
            dgvOrdenCompra.Columns[12].HeaderText = "IMP.UNIT";
            dgvOrdenCompra.Columns[13].Visible = false;
            dgvOrdenCompra.Columns[14].HeaderText = "SUCURSAL";
            dgvOrdenCompra.Columns[15].Visible = false;
            dgvOrdenCompra.Columns[16].Visible = false;
            dgvOrdenCompra.Columns[17].HeaderText = "TOTAL";
            dgvOrdenCompra.Columns[12].DefaultCellStyle.Format = "c";
            dgvOrdenCompra.Columns[17].DefaultCellStyle.Format = "c";
            dgvOrdenCompra.Columns[18].Visible = false;
            dgvOrdenCompra.Columns[19].Visible = false;
            dgvOrdenCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenCompra.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        private void CargarGrid()
        {
            DataTable dt = new DataTable();
            dt = OrdenesCompraDetalle.GetOrdencompraDetalleDatosPodId(id);
            if (dt.Rows.Count > 0)
            {
                dgvOrdenCompra.DataSource = dt.DefaultView;
                PersonalizarGrid();
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetalleOrdenCompra_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
