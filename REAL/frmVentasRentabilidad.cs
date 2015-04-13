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
    public partial class frmVentasRentabilidad : Form
    {
        public frmVentasRentabilidad()
        {
            InitializeComponent();
        }

        private void frmVentasRentabilidad_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            List<Venta> list = Ventas.GetTodo();
            if (list.Count > 0)
            {
                dgvDetalle.DataSource = list;
                PersonalizarDataGrid();
                dgvDetalle.CurrentRow.Selected = false;
            }
        }

        private void PersonalizarDataGrid()
        {
            dgvDetalle.Columns[0].HeaderText = "Sucursal";
            dgvDetalle.Columns[1].Visible = false;
            dgvDetalle.Columns[2].HeaderText = "Fecha";
            dgvDetalle.Columns[3].HeaderText = "N° Remito";
            dgvDetalle.Columns[4].HeaderText = "Vendedor";
            dgvDetalle.Columns[5].HeaderText = "Importe Venta";
            dgvDetalle.Columns[6].HeaderText = "Total Venta";
            dgvDetalle.Columns[7].HeaderText = "Precio Costo (Sin Iva)";
            dgvDetalle.Columns[8].HeaderText = "Precio Venta Teorico";
            dgvDetalle.Columns[9].HeaderText = "Gastos Financiación";
            dgvDetalle.Columns[10].HeaderText = "Ganancia";
            dgvDetalle.Columns[11].HeaderText = "Margen de Ganancia";

            dgvDetalle.Columns[5].DefaultCellStyle.Format = "c";
            dgvDetalle.Columns[6].DefaultCellStyle.Format = "c";
            dgvDetalle.Columns[7].DefaultCellStyle.Format = "c";
            dgvDetalle.Columns[8].DefaultCellStyle.Format = "c";
            dgvDetalle.Columns[9].DefaultCellStyle.Format = "c";
            dgvDetalle.Columns[10].DefaultCellStyle.Format = "c";
            dgvDetalle.Columns[11].DefaultCellStyle.Format = "#.00\\%";

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;

            DataGridViewButtonColumn detalle = new DataGridViewButtonColumn();
            detalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            detalle.HeaderText = "Detalle Venta";
            detalle.Name = "btnDetalle";
            detalle.Text = "Detalle Venta";
            detalle.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn cobros = new DataGridViewButtonColumn();
            cobros.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cobros.HeaderText = "Cobros";
            cobros.Name = "btnCobros";
            cobros.Text = "Ver Cobros";
            cobros.UseColumnTextForButtonValue = true;

            dgvDetalle.Columns.Add(detalle);
            dgvDetalle.Columns.Add(cobros);
        }

    }
}
