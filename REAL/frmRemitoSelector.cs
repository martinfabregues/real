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
    public partial class frmRemitoSelector : Form
    {
        public List<RemitoProveedor> remitos { get; set; }
        public frmRemitoSelector()
        {
            InitializeComponent();
            remitos = new List<RemitoProveedor>();
        }

        private void frmRemitoSelector_Load(object sender, EventArgs e)
        {
            GetRemitos();
        }

        private void GetRemitos()
        {
            var resultado = (from row in RemitosProveedor.FindAllWithSucursal().OrderByDescending(x => x.fechaemision)
                             select new
                             {
                                 row.id,
                                 row.sucursal.sucnombre,
                                 row.fechaemision,
                                 row.numero
                             }).ToList();

            foreach(var row in resultado)
            {
                dgvRemitos.Rows.Add(row.id, row.sucnombre, row.fechaemision.ToShortDateString(), row.numero);
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumero.Text))
            {
                BuscarPorNumero(txtNumero.Text);
            }
            else
            {
                GetRemitos();
            }
        }


        private void BuscarPorNumero(string numero)
        {
            var resultado = (from row in RemitosProveedor.FindAllLikeNumero(numero).OrderByDescending(x => x.fechaemision)
                             select new
                             {
                                 row.id,
                                 row.sucursal.sucnombre,
                                 row.fechaemision,
                                 row.numero
                             }).ToList();

            dgvRemitos.Rows.Clear();
            foreach (var row in resultado)
            {
                dgvRemitos.Rows.Add(row.id, row.sucnombre, row.fechaemision.ToShortDateString(), row.numero);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumero.Text))
            {
                BuscarPorNumero(txtNumero.Text);
            }
            else
            {
                GetRemitos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {           
            foreach(DataGridViewRow row in dgvRemitos.Rows)
            {
                if (Convert.ToBoolean(row.Cells[4].Value) == true)
                {
                    RemitoProveedor remito = new RemitoProveedor();
                    remito.id = Convert.ToInt32(row.Cells[0].Value);
                    remito.numero = row.Cells[3].Value.ToString();
                    remito.fechaemision = Convert.ToDateTime(row.Cells[2].Value);
                    remitos.Add(remito);
                }
            }

        }
    }
}
