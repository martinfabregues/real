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
    public partial class dlgRemitos : Form
    {
        public Remito remito { get; set; }
        public dlgRemitos()
        {
            InitializeComponent();
        }

        private void dlgRemitos_Load(object sender, EventArgs e)
        {
            CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            List<Remito> list = Remitos.GetTodo();

            var resultado = (from fila in list
                             select new
                             {
                                 fila.remito_id,
                                 fila.sucursal.sucnombre,
                                 fila.remito_fecha,
                                 fila.remito_numero,
                                 fila.remito_numerofactura,
                                 fila.remito_importe,
                                 fila.vendedor.vendedor_nombre,
                                 fila.movimiento.movnombre,
                                 fila.estadocomprobante.estadocomprobante_denominacion,
                             }).ToList();

            if (resultado.Count > 0)
            {
                dgvRemitos.DataSource = resultado;
                PersonalizarDataGrid();
            }
        }

        private void PersonalizarDataGrid()
        {
            dgvRemitos.Columns[0].Visible = false;
            dgvRemitos.Columns[1].HeaderText = "Sucursal";
            dgvRemitos.Columns[2].HeaderText = "Fecha";
            dgvRemitos.Columns[3].HeaderText = "Número Remito";
            dgvRemitos.Columns[4].HeaderText = "Número Factura";
            dgvRemitos.Columns[5].HeaderText = "Importe";
            dgvRemitos.Columns[6].HeaderText = "Vendedor";
            dgvRemitos.Columns[7].HeaderText = "Movimiento";
            dgvRemitos.Columns[8].HeaderText = "Estado";

            dgvRemitos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRemitos.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;

            dgvRemitos.Columns[5].DefaultCellStyle.Format = "c";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvRemitos.SelectedRows.Count > 0)
            {
                if (dgvRemitos.CurrentRow.Index > -1)
                {
                    remito = new Remito();
                    remito.remito_id = Convert.ToInt32(dgvRemitos.CurrentRow.Cells[0].Value);
                    remito.remito_numero = dgvRemitos.CurrentRow.Cells[3].Value.ToString();
                }
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //
            // Si el control DataGridView no tiene el foco, 
            // se abandonamos el procedimiento, llamando al metodo base
            //
            if ((!dgvRemitos.Focused))
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
            DataGridViewRow row = dgvRemitos.CurrentRow;
            remito = new Remito();
            remito.remito_id = Convert.ToInt32(dgvRemitos.CurrentRow.Cells[0].Value);
            remito.remito_numero = dgvRemitos.CurrentRow.Cells[3].Value.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //frmSeleccion frm = new frmSeleccion(cuenta, desc);
            //frm.ShowDialog();


            return true;
        }


    }
}
