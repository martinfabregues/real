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
    public partial class frmFacturasProveedorConsulta : Form
    {
        public frmFacturasProveedorConsulta()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtFactura.Text = string.Empty;

            cmbProveedor.Enabled = false;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;

            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvFacturas.Columns[4].DefaultCellStyle.Format = "c";
            dgvFacturas.Columns[5].DefaultCellStyle.Format = "c";
        }

        private void CargarDataGrid()
        {
            var query = (from row in FacturasProveedor.FindAllComplete().OrderByDescending(x => x.fecha)
                         select new
                         {
                             row.id,
                             row.proveedor.pronombre,
                             row.numero,
                             row.fecha,
                             row.fecharecepcion,
                             row.subtotal,
                             row.importe

                         }).ToList();

            dgvFacturas.Rows.Clear();
            foreach(var fila in query)
            {
                dgvFacturas.Rows.Add(fila.id, fila.pronombre, fila.numero, fila.fecha.ToShortDateString(),
                    fila.fecharecepcion.ToShortDateString(), fila.subtotal, fila.importe);
            }
        }

        private void GetProveedores()
        {
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DataSource = Proveedores.FindAll();
        }
        private void frmFacturasProveedorConsulta_Load(object sender, EventArgs e)
        {
            IniciarControles();
            GetProveedores();
            CargarDataGrid();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            cmbProveedor.SelectedIndex = 0;
            if (ckbProveedor.CheckState == CheckState.Checked)
                cmbProveedor.Enabled = true;
            else
                cmbProveedor.Enabled = false;
        }

        private void ckbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbFecha.CheckState == CheckState.Checked)
            {
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
            }
            else
            {
                dtpHasta.Enabled = false;
                dtpDesde.Enabled = false;
            }
        }


        private void FiltrarForm()
        {
            string numero_factura = txtFactura.Text == string.Empty ? null : txtFactura.Text;

            int? proveedor_id = ckbProveedor.Checked ? (int?)Convert.ToInt32(cmbProveedor.SelectedValue) : null;
            
            DateTime? desde = ckbFecha.Checked ? (DateTime?)dtpDesde.Value : null;
            DateTime? hasta = ckbFecha.Checked ? (DateTime?)dtpHasta.Value : null;


            var query = (from row in FacturasProveedor.FindAllCondicional(numero_factura, proveedor_id, desde, hasta).OrderByDescending(x => x.fecha)
                         select new
                         {
                             row.id,
                             row.proveedor.pronombre,
                             row.numero,
                             row.fecha,
                             row.fecharecepcion,
                             row.subtotal,
                             row.importe

                         }).ToList();

            dgvFacturas.Rows.Clear();
            foreach (var fila in query)
            {
                dgvFacturas.Rows.Add(fila.id, fila.pronombre, fila.numero, fila.fecha.ToShortDateString(),
                    fila.fecharecepcion.ToShortDateString(), fila.subtotal, fila.importe);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarForm();
        }

        private void txtFactura_TextChanged(object sender, EventArgs e)
        {
            FiltrarForm();
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvFacturas.CurrentCell.ColumnIndex.Equals(7))
            {
                int factura_id = (int)dgvFacturas.CurrentRow.Cells[0].Value;
                string factura_numero = dgvFacturas.CurrentRow.Cells[2].Value.ToString();
                string proveedor = dgvFacturas.CurrentRow.Cells[1].Value.ToString();

                IList<RemitoProveedor> remitosL = RemitosProveedor.FindAllByIdFactura(factura_id);
                if(remitosL.Count > 0)
                {
                    string mensaje = string.Empty;
                    foreach (var fila in remitosL)
                    {
                        mensaje = mensaje + Environment.NewLine + " * " + fila.numero + " - " + fila.fechaemision.ToShortDateString();
                    }

                    string msg = "Remitos Asociados a la Factura: " + proveedor + ": " + factura_numero + Environment.NewLine;
                    msg = msg + mensaje;
                    MessageBox.Show(msg, "Remitos Asociadas a la Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("La Factura de Compra no tiene asociados ningun Remito.", "Facturas Asociadas al Remito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }


    }
}
