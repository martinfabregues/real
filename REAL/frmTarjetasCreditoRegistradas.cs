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
    public partial class frmTarjetasCreditoRegistradas : Form
    {
        public frmTarjetasCreditoRegistradas()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTarjetasCreditoRegistradas_Load(object sender, EventArgs e)
        {

            CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            List<TarjetaCredito> list = TarjetasCredito.GetTodos();

            if (list.Count > 0)
            {
                dgvTarjetas.DataSource = list;
                PersonalizarDataGrid();
            }
        }

        private void PersonalizarDataGrid()
        {
            dgvTarjetas.Columns[0].Visible = false;
            dgvTarjetas.Columns[1].HeaderText = "Nombre Tarjeta";

            dgvTarjetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTarjetas.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty)
            {
                List<TarjetaCredito> list = TarjetasCredito.GetTodos();
                var result = (from fila in list
                              where fila.tarnombre.Contains(txtNombre.Text)
                              select fila).ToList();
                if (result.Count > 0)
                {
                    dgvTarjetas.DataSource = result;
                    PersonalizarDataGrid();
                }
            }
        }
    }
}
