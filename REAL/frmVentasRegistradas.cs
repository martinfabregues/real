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
    public partial class frmVentasRegistradas : Form
    {
        public frmVentasRegistradas()
        {
            InitializeComponent();
        }

        private void frmVentasRegistradas_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            CargarDataGrid();
        }

        private void CargarDataGrid()
        {

            List<Remito> list = Remitos.GetTodo();
            if (list.Count > 0)
            {
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

                dgvRemitos.DataSource = resultado;

                DataGridViewButtonColumn Detalle = new DataGridViewButtonColumn();
                Detalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Detalle.HeaderText = "Detalle Venta";
                Detalle.Name = "btnDetalle";
                Detalle.Text = "Detalle Venta";
                Detalle.UseColumnTextForButtonValue = true;

                dgvRemitos.Columns.Add(Detalle);

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

        private void frmVentasRegistradas_Resize(object sender, EventArgs e)
        {
            dgvRemitos.Width = this.Width - 40;
            dgvRemitos.Height = this.Height - 200;
        }

        private void dgvRemitos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRemitos.Rows.Count > 0)
            {
                if (dgvRemitos.Columns[e.ColumnIndex].Name == "btnDetalle")
                {
                    
                    DataGridViewRow fila = dgvRemitos.CurrentRow;
                    Remito remito = new Remito();
                    remito.remito_id = Convert.ToInt32(fila.Cells["remito_id"].Value);
                    remito.remito_numero = fila.Cells["remito_numero"].Value.ToString();

                    frmDetalleVenta frm = new frmDetalleVenta(remito);
                    //frm.MdiParent = this;
                    frm.Text = "VENTA - DETALLE DE VENTA - Remito N° " + remito.remito_numero;
                    frm.ShowDialog();

                    
                }
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
