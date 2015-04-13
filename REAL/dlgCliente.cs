using Entidad;
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
    public partial class dlgCliente : Form
    {
        public int cliid { get;set; }
        public string clicodigo { get; set; }
        public dlgCliente()
        {
            InitializeComponent();
        }

        private void CargarGrilla()
        {
            List<Cliente> list = Clientes.GetTodosConsulta();

            var resultado = (from fila in list
                             select new
                             {
                                 fila.cliid,
                                 fila.clicodigo,
                                 fila.clinombre,
                                 fila.clidocumento,
                                 direccion = (fila.clicalle + " " + fila.clinumero),
                                 fila.estado.estestado,
                             }).ToList();

            if (resultado.Count > 0)
            {
                dgvClientes.DataSource = resultado;
                dgvClientes.CurrentRow.Selected = false;
                PersonalizarGrid();
            }
            
        }

        private void PersonalizarGrid()
        {
            dgvClientes.Columns[0].Visible = false;
            dgvClientes.Columns[1].HeaderText = "Código Cliente";
            dgvClientes.Columns[2].HeaderText = "Nombre";
            dgvClientes.Columns[3].HeaderText = "Cuit/Cuil/Dni";
            dgvClientes.Columns[4].HeaderText = "Dirección";
            dgvClientes.Columns[5].HeaderText = "Estado";
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        private void dlgCliente_Load(object sender, EventArgs e)
        {
            CargarGrilla();                 
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                if (dgvClientes.CurrentRow.Index > -1)
                {
                
                    cliid = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
                    clicodigo = dgvClientes.CurrentRow.Cells[1].Value.ToString();
               
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarLikeNombre(string nombre)
        {
            List<Cliente> list = Clientes.GetTodosConsulta();

            var resultado = (from fila in list
                             where fila.clinombre.Contains(nombre)
                             select new
                             {
                                 fila.cliid,
                                 fila.clicodigo,
                                 fila.clinombre,
                                 fila.clidocumento,
                                 direccion = (fila.clicalle + " " + fila.clinumero),
                                 fila.estado.estestado,
                             }).ToList();

            if (resultado.Count > 0)
            {
                dgvClientes.DataSource = resultado;
                dgvClientes.CurrentRow.Selected = false;
                PersonalizarGrid();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty)
            {

                BuscarLikeNombre(txtNombre.Text);
               
            }
            else
            {
                CargarGrilla();
                PersonalizarGrid();
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //
            // Si el control DataGridView no tiene el foco, 
            // se abandonamos el procedimiento, llamando al metodo base
            //

            if ((!dgvClientes.Focused))
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
            if (dgvClientes.SelectedRows.Count > 0)
            {
                if (dgvClientes.CurrentRow.Index > -1)
                {
                    DataGridViewRow row = dgvClientes.CurrentRow;
                    cliid = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
                    clicodigo = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    //frmSeleccion frm = new frmSeleccion(cuenta, desc);
                    //frm.ShowDialog();
                }
            }

            return true;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty)
            {
                BuscarLikeNombre(txtNombre.Text);
            }
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            frmNuevoCliente frm = new frmNuevoCliente("NUEVO");
            frm.MdiParent = this.MdiParent;
            frm.Text = "CLIENTES - REGISTRAR NUEVO CLIENTE";
            frm.ShowDialog();
        }

        private void dlgCliente_Activated(object sender, EventArgs e)
        {
            CargarGrilla();
        }



    }
}
