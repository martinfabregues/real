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
    public partial class frmListasPrecioConsulta : Form
    {
        public frmListasPrecioConsulta()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            cmbProveedor.SelectedIndex = 0;
            txtDenominacion.Text = string.Empty;
            dgvListasPrecio.DataSource = null;

        }


        private void CargarComboProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetTodos();

        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListasPrecioConsulta_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
           
            CargarComboProveedor();
            IniciarControles();
            CargarGrid();
        }

        private void PersonalizarGrid()
        {
            dgvListasPrecio.Columns[0].Visible = false;
            dgvListasPrecio.Columns[1].HeaderText = "Proveedor";
            dgvListasPrecio.Columns[2].HeaderText = "Denominación";
            dgvListasPrecio.Columns[3].HeaderText = "Fecha Creación";
            dgvListasPrecio.Columns[4].HeaderText = "Fecha Inicio";
            dgvListasPrecio.Columns[5].HeaderText = "Fecha Fin";
            dgvListasPrecio.Columns[6].HeaderText = "Estado";

            dgvListasPrecio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListasPrecio.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        private void CargarGrid()
        {
            List<ListaPrecio> list = ListasPrecio.GetTodos();
            var resultado = (from fila in list
                             select new
                             {
                                 fila.listaprecio_id,
                                 fila.proveedor.pronombre,
                                 fila.listaprecio_denominacion,
                                 fila.listaprecio_fechacreacion,
                                 fila.listaprecio_fechainicio,
                                 fila.listaprecio_fechafin,
                                 fila.estado.estestado,
                                 
                             }).ToList();

            if (resultado.Count > 0)
            {
                dgvListasPrecio.DataSource = resultado;
                dgvListasPrecio.CurrentRow.Selected = false;
                PersonalizarGrid();
            }

        }

    }
}
