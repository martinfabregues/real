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
    public partial class frmConsultaBarrio : Form
    {
        public frmConsultaBarrio()
        {
            InitializeComponent();
            IniciarControles();
            CargarGrid();

        }


        private void IniciarControles()
        {
            txtNombre.Text = string.Empty;
        }

        private void CargarGrid()
        {
            dgvBarrios.DataSource = Barrios.GetTodos();
            PersonalizarGrid();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PersonalizarGrid()
        {
            dgvBarrios.Columns[0].Visible = false;
            dgvBarrios.Columns[1].HeaderText = "BARRIO";
            dgvBarrios.Columns[2].Visible = false;
            dgvBarrios.Columns[3].HeaderText = "COSTO";

            dgvBarrios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBarrios.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;

            dgvBarrios.Columns[3].DefaultCellStyle.Format = "c";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty)
            {
                dgvBarrios.DataSource = Barrios.GetLikeNombre(txtNombre.Text);
                PersonalizarGrid();
            }
            else
            {
                CargarGrid();
            }
        }

        private void dgvBarrios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvBarrios.Columns[e.ColumnIndex].Name == "barcosto")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    e.Value = "SIN CARGO";
                }
                //e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        private void frmConsultaBarrio_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmConsultaBarrio_Resize(object sender, EventArgs e)
        {
            dgvBarrios.Width = this.Width - 16;
            dgvBarrios.Height = this.Height - 250;
            btnCerrar.Location = new Point(this.Width - 110, this.Height - 80);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty)
            {
                dgvBarrios.DataSource = Barrios.GetLikeNombre(txtNombre.Text);
                PersonalizarGrid();
            }
            else
            {
                CargarGrid();
            }
        }

    }
}
