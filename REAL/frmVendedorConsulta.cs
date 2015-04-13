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
    public partial class frmVendedorConsulta : Form
    {
        public frmVendedorConsulta()
        {
            InitializeComponent();
        }


        private void IniciarControles()
        {
            dgvVendedores.DataSource = null;
        }

        private void frmVendedorConsulta_Load(object sender, EventArgs e)
        {
            IniciarControles();
            CargarGrid();
        }

        private void CargarGrid()
        {
            List<Vendedor> list = Vendedores.GetTodos();

            var resultado = (from fila in list
                             select new
                             {
                                 codigo = String.Format("{0:000}", fila.vendedor_id),
                                 fila.vendedor_nombre,
                                 fila.vendedor_direccion,
                                 fila.vendedor_telefonofijo,
                                 fila.vendedor_telefonocelular,
                                 fila.vendedor_email,
                                 fila.estado.estestado,
                             }).ToList();

            if (resultado.Count > 0)
            {
                dgvVendedores.DataSource = resultado;
                PersonalizarGrid();
            }
        }

        private void PersonalizarGrid()
        {
            dgvVendedores.Columns[0].HeaderText = "Código";
            dgvVendedores.Columns[1].HeaderText = "Nombre";
            dgvVendedores.Columns[2].HeaderText = "Dirección";
            dgvVendedores.Columns[3].HeaderText = "Tel. Fijo";
            dgvVendedores.Columns[4].HeaderText = "Tel. Celular";
            dgvVendedores.Columns[5].HeaderText = "Email";
            dgvVendedores.Columns[6].HeaderText = "Estado";

            dgvVendedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVendedores.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
