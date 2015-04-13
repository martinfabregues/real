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
    public partial class dlgOrdenCompra : Form
    {
        public int odcid { get; set; }
        public string odcnumero { get; set; }
        public dlgOrdenCompra()
        {
            InitializeComponent();
        }

        private void dlgOrdenCompra_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {

            DataTable dt = new DataTable();
            dt = OrdenesCompra.GetOrdenCompraTodo();
            if (dt.Rows.Count > 0)
            {
                dgvOrdenes.DataSource = dt.DefaultView;
                dgvOrdenes.CurrentRow.Selected = false;
                PersonalizarGrid();

            }
        }


        private void PersonalizarGrid()
        {

            dgvOrdenes.Columns[0].Visible = false;
            dgvOrdenes.Columns[1].HeaderText = "N° ORDEN COMPRA";
            dgvOrdenes.Columns[2].HeaderText = "FECHA";
            dgvOrdenes.Columns[3].HeaderText = "PROVEDOR";
            dgvOrdenes.Columns[4].HeaderText = "IMPORTE";
            //dgvOrdenes.Columns[5].Visible = false;
            dgvOrdenes.Columns[4].DefaultCellStyle.Format = "c";

            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenes.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.SelectedRows.Count > 0)
            {
                if (dgvOrdenes.CurrentRow.Index > -1)
                {
                    odcid = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells[0].Value);
                    odcnumero = dgvOrdenes.CurrentRow.Cells[1].Value.ToString();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtOrdenCompra.Text != string.Empty)
            {
                DataTable dt = new DataTable();
                dt = OrdenesCompra.GetDatosLikeNumero(txtOrdenCompra.Text);
                if (dt.Rows.Count > 0)
                {
                    dgvOrdenes.DataSource = dt.DefaultView;
                    dgvOrdenes.CurrentRow.Selected = false;
                    PersonalizarGrid();

                }

            }
        }

        private void txtOrdenCompra_TextChanged(object sender, EventArgs e)
        {
            if (txtOrdenCompra.Text != string.Empty)
            {
                DataTable dt = new DataTable();
                dt = OrdenesCompra.GetDatosLikeNumero(txtOrdenCompra.Text);
                if (dt.Rows.Count > 0)
                {
                    dgvOrdenes.DataSource = dt.DefaultView;
                    dgvOrdenes.CurrentRow.Selected = false;
                    PersonalizarGrid();

                }

            }
        }


        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //
            // Si el control DataGridView no tiene el foco, 
            // se abandonamos el procedimiento, llamando al metodo base
            //
            if ((!dgvOrdenes.Focused))
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
            DataGridViewRow row = dgvOrdenes.CurrentRow;
            odcid = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells[0].Value);
            odcnumero = dgvOrdenes.CurrentRow.Cells[1].Value.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //frmSeleccion frm = new frmSeleccion(cuenta, desc);
            //frm.ShowDialog();


            return true;
        } 



    }
}
