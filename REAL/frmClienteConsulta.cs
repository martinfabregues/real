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
    public partial class frmClienteConsulta : Form
    {
        public frmClienteConsulta()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtDocumento.Text = string.Empty;
            txtDocumento.Text = string.Empty;
        }

        private void frmClienteConsulta_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            IniciarControles();

            CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            List<Cliente> list = Clientes.GetTodosConsulta();

            var resultado = (from fila in list
                             select new
                             {
                                fila.cliid,
                                fila.clicodigo,
                                fila.clinombre,
                                fila.clidocumento,
                                fila.clibarrio,
                                fila.clitelefonofijo,
                                fila.clitelefonocelular,
                                fila.cliemail,
                                fila.estado.estestado,
                             }).ToList();

            if (resultado.Count > 0)
            {
                dgvClientes.DataSource = resultado;
                PersonalizarDataGrid();
            }
        }

        private void PersonalizarDataGrid()
        {
            dgvClientes.Columns[0].Visible = false;
            dgvClientes.Columns[1].HeaderText = "Código";
            dgvClientes.Columns[2].HeaderText = "Nombre Completo";
            dgvClientes.Columns[3].HeaderText = "Cuit-Cuil-Dni";
            dgvClientes.Columns[4].HeaderText = "Barrio";
            dgvClientes.Columns[5].HeaderText = "Teléfono Fijo";
            dgvClientes.Columns[6].HeaderText = "Teléfono Celular";
            dgvClientes.Columns[7].HeaderText = "Email";
            dgvClientes.Columns[8].HeaderText = "Estado";

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;

        }

        private void frmClienteConsulta_Resize(object sender, EventArgs e)
        {
            dgvClientes.Width = this.Width - 45;
            dgvClientes.Height = this.Height - 180;
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
