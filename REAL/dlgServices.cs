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
    public partial class dlgServices : Form
    {
        public int serId { get; set; }
        public string serCodigo {get; set;}

        public dlgServices()
        {
            InitializeComponent();
        }

        private void dlgServices_Load(object sender, EventArgs e)
        {
            dgvService.DataSource = Services.FindAll();
            dgvService.CurrentRow.Selected = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvService.SelectedRows.Count > 0)
            {
                if (dgvService.CurrentRow.Index > -1)
                {
                    serId = Convert.ToInt32(dgvService.CurrentRow.Cells[0].Value);
                    serCodigo = dgvService.CurrentRow.Cells[1].Value.ToString();
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
