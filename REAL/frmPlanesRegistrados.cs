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
    public partial class frmPlanesRegistrados : Form
    {
        public frmPlanesRegistrados()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPlanesRegistrados_Load(object sender, EventArgs e)
        {
            CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            List<Plan> list = Planes.GetTodo();

            if (list.Count > 0)
            {
                var resultado = (from fila in list
                                 select new
                                 {
                                     fila.plan_id,
                                     fila.plan_denominacion,
                                     fila.plan_comision,
                                     fila.plan_costofinanciero,
                                     fila.tarjetacredito.tarnombre,
                                 }).ToList();

                dgvPlanes.DataSource = resultado;
                PersonalizarDataGrid();
            }
        }

        private void PersonalizarDataGrid()
        {
            dgvPlanes.Columns[0].Visible = false;
            dgvPlanes.Columns[1].HeaderText = "Denominación";
            dgvPlanes.Columns[2].HeaderText = "Comisión";
            dgvPlanes.Columns[3].HeaderText = "Costo Financiero";
            dgvPlanes.Columns[4].HeaderText = "Tarjeta de Credito";

            dgvPlanes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlanes.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }


        
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty)
            {

                List<Plan> list = Planes.GetTodo();

                if (list.Count > 0)
                {
                    var resultado = (from fila in list
                                     where fila.plan_denominacion.Contains(txtNombre.Text)
                                     select new
                                     {
                                         fila.plan_id,
                                         fila.plan_denominacion,
                                         fila.plan_comision,
                                         fila.plan_costofinanciero,
                                         fila.tarjetacredito.tarnombre,
                                     }).ToList();

                    dgvPlanes.DataSource = resultado;
                    PersonalizarDataGrid();
                }




            }
        }

    }
}
