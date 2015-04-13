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
    public partial class dlgIngresosProveedor : Form
    {
        public int fapid { get; set; }
        public string fapnumero { get; set; }
        public dlgIngresosProveedor()
        {
            InitializeComponent();
            
        }

        private void IniciarControles()
        {
            txtNombre.Enabled = false;
            txtRemito.Enabled = false;
        }


        private void CargarGrid()
        {

            List<FacturaProveedor> listFp = FacturasProveedor.GetTodos();
            List<Proveedor> listProv = Proveedores.GetTodos();
            List<Sucursal> listSuc = Sucursales.GetTodos();

            var res = (from fac in listFp
                       join prov in listProv on
                       fac.proveedor_id equals prov.proid
                       join suc in listSuc
                       on fac.sucursal_id equals suc.sucid
                       select new
                       {
                           fac.id,
                           fac.numero,
                           fac.numeroremito,
                           fac.fecha,
                           fac.fecharecepcion,
                           prov.pronombre,
                           suc.sucnombre,
                           fac.importe
                       }).ToList();



            dgvIngresos.DataSource = res;
        }

        private void dlgIngresosProveedor_Load(object sender, EventArgs e)
        {
            IniciarControles();
            CargarGrid();
            PersonalizarGrilla();
        }

        private void PersonalizarGrilla()
        {
            dgvIngresos.Columns[0].Visible = false;
            dgvIngresos.Columns[1].HeaderText = "N° Fact.";
            dgvIngresos.Columns[2].HeaderText = "N° Rem.";
            dgvIngresos.Columns[3].HeaderText = "Fecha";
            dgvIngresos.Columns[4].HeaderText = "F.Recepción";
            dgvIngresos.Columns[5].HeaderText = "Proveedor";
            dgvIngresos.Columns[6].HeaderText = "Sucursal";
            dgvIngresos.Columns[7].HeaderText = "Importe";

            dgvIngresos.Columns[7].DefaultCellStyle.Format = "c";

            dgvIngresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIngresos.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvIngresos.SelectedRows.Count > 0)
            {
                if (dgvIngresos.CurrentRow.Index > -1)
                {
                    fapid = Convert.ToInt32(dgvIngresos.CurrentRow.Cells[0].Value);
                    fapnumero = dgvIngresos.CurrentRow.Cells[1].Value.ToString();
                }
            }
        }


        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //
            // Si el control DataGridView no tiene el foco, 
            // se abandonamos el procedimiento, llamando al metodo base
            //
            if ((!dgvIngresos.Focused))
                return base.ProcessCmdKey(ref msg, keyData);

            //
            // Si la tecla presionada es distinta al ENTER, 
            // se abandonamos el procedimiento, llamando al metodo base
            //
            if (keyData != Keys.Enter)
                return base.ProcessCmdKey(ref msg, keyData);
            //
            // Obtenemos la fila actual 
            //
            DataGridViewRow row = dgvIngresos.CurrentRow;
            fapid = Convert.ToInt32(dgvIngresos.CurrentRow.Cells[0].Value);
            fapnumero = dgvIngresos.CurrentRow.Cells[1].Value.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //frmSeleccion frm = new frmSeleccion(cuenta, desc);
            //frm.ShowDialog();


            return true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ckbFactura.Checked == true)
            {
                FiltrarPorNroFactura();
            }
            else
            {
                if (ckbRemito.Checked == true)
                {
                    FiltrarPorNroRemito();
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            FiltrarPorNroFactura();
        }

        private void FiltrarPorNroFactura()
        {
            List<FacturaProveedor> listFp = FacturasProveedor.GetTodos();
            List<Proveedor> listProv = Proveedores.GetTodos();
            List<Sucursal> listSuc = Sucursales.GetTodos();

            var res = (from fac in listFp
                       join prov in listProv on
                       fac.proveedor_id equals prov.proid
                       join suc in listSuc
                       on fac.sucursal_id equals suc.sucid
                       where fac.numero == txtNombre.Text
                       select new
                       {
                           fac.id,
                           fac.numero,
                           fac.numeroremito,
                           fac.fecha,
                           fac.fecharecepcion,
                           prov.pronombre,
                           suc.sucnombre,
                           fac.importe
                       }).ToList();



            dgvIngresos.DataSource = res;

        }

        private void FiltrarPorNroRemito()
        {
            List<FacturaProveedor> listFp = FacturasProveedor.GetTodos();
            List<Proveedor> listProv = Proveedores.GetTodos();
            List<Sucursal> listSuc = Sucursales.GetTodos();

            var res = (from fac in listFp
                       join prov in listProv on
                       fac.proveedor_id equals prov.proid
                       join suc in listSuc
                       on fac.sucursal_id equals suc.sucid
                       where fac.numeroremito == txtRemito.Text
                       select new
                       {
                           fac.id,
                           fac.numero,
                           fac.numeroremito,
                           fac.fecha,
                           fac.fecharecepcion,
                           prov.pronombre,
                           suc.sucnombre,
                           fac.importe
                       }).ToList();



            dgvIngresos.DataSource = res;

        }

        private void ckbFactura_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtRemito.Text = string.Empty;
            if (ckbFactura.Checked == true)
            {
                txtNombre.Enabled = true;
                txtRemito.Enabled = false;
                ckbRemito.CheckState = CheckState.Unchecked;

            }
            else
            {
                txtNombre.Enabled = false;
            }
        }

        private void ckbRemito_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtRemito.Text = string.Empty;
            if (ckbRemito.Checked == true)
            {
                txtRemito.Enabled = true;
                txtNombre.Enabled = false;
                ckbFactura.CheckState = CheckState.Unchecked;
            }
            else
            {
                txtRemito.Enabled = false;
            }
        }

        private void txtRemito_TextChanged(object sender, EventArgs e)
        {
            FiltrarPorNroRemito();
        }

    }
}
