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
    public partial class frmAutorizacionService : Form
    {
        public frmAutorizacionService()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtNumero.Text = string.Empty;
            dgvService.DataSource = null;

            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;
            txtNumero.Enabled = false;
            cmbProveedor.Enabled = false;

            
        }

        private void CargarDataGrid()
        {
            DataTable dt = new DataTable();
            IList<Service> datos = Services.FindAll();

            var query = (from fila in datos
                         select new
                         {
                             fila.serid,
                             fila.sernumero,
                             fila.proveedor.pronombre,
                             fila.sucursal.sucnombre,
                             fila.serremito,
                             fila.serfecha,
                             fila.serfechacompra,
                             fila.cliente.clinombre,

                         }).ToList();

            if (query.Count > 0)
            {
                dgvService.DataSource = query;
                dgvService.CurrentRow.Selected = false;
            }
            
        }

        private void PersonalizarGrid()
        {
            //dgvService.Columns.Clear();
            DataGridViewButtonColumn Detalle = new DataGridViewButtonColumn();
            Detalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Detalle.HeaderText = "Detalle";
            Detalle.Name = "btnDetalle";
            Detalle.Text = "Detalle";
            Detalle.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn Autorizar = new DataGridViewButtonColumn();
            Autorizar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Autorizar.HeaderText = "Autorizar";
            Autorizar.Name = "btnAutorizar";
            Autorizar.Text = "Autorizar";
            Autorizar.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn Denegar = new DataGridViewButtonColumn();
            Denegar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Denegar.HeaderText = "Denegar";
            Denegar.Name = "btnDenegar";
            Denegar.Text = "Denegar";
            Denegar.UseColumnTextForButtonValue = true;

            dgvService.Columns.Add(Detalle);
            dgvService.Columns.Add(Autorizar);
            dgvService.Columns.Add(Denegar);

            dgvService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvService.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;

            dgvService.Columns[0].Visible = false;
        }

        private void frmAutorizacionService_Load(object sender, EventArgs e)
        {
            IniciarControles();
            CargarDataGrid();
            PersonalizarGrid();

        }

        private void frmAutorizacionService_Resize(object sender, EventArgs e)
        {
            //dgvService.Width = this.Width - 20;
            //dgvService.Height = this.Height - 180;
            //btnCancelar.Location = new Point(this.Width- 100, this.Height - 150);
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvService.Columns[e.ColumnIndex].Name == "btnAutorizar")
            {
                DataGridViewRow fila = dgvService.CurrentRow;

                int id = Convert.ToInt32(fila.Cells["serid"].Value);
                string num = fila.Cells["sernumero"].Value.ToString();
                frmNuevaAutorizacion frm = new frmNuevaAutorizacion(id, num);
                frm.Text = "SERVICE - AUTORIZACIÓN DE SERVICE: " + num;
                frm.ShowDialog();
                dgvService.Columns.Clear();
                CargarDataGrid();
                PersonalizarGrid();
            }

            if (dgvService.Columns[e.ColumnIndex].Name == "btnPresentar")
            {
                DataGridViewRow fila = dgvService.CurrentRow;

                int id = Convert.ToInt32(fila.Cells["serid"].Value);
                string num = fila.Cells["sernumero"].Value.ToString();

                DialogResult dg = new DialogResult();
                dg = MessageBox.Show("ESTA SEGURO DE PRESENTAR EL SERVICE N°: " + num, "INFORMACIÓN", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dg == System.Windows.Forms.DialogResult.Yes)
                {
                    //int res = Services.ServicePresentar(id);
                    //if (res > 0)
                    //{
                    //    MessageBox.Show("SERVICE PRESENTADO CORRECTAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    //    dgvService.Columns.Clear();
                    //    CargarDataGrid();
                    //    PersonalizarGrid();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("OCURRIO UN ERROR AL PRESENTAR EL SERVICE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    dgvService.Columns.Clear();
                    //    CargarDataGrid();
                    //    PersonalizarGrid();
                    //}                   
                }               
            }


            if (dgvService.Columns[e.ColumnIndex].Name == "btnDenegar")
            {
                DataGridViewRow fila = dgvService.CurrentRow;

                int id = Convert.ToInt32(fila.Cells["serid"].Value);
                string num = fila.Cells["sernumero"].Value.ToString();

                DialogResult dg = new DialogResult();
                dg = MessageBox.Show("ESTA SEGURO DE DENEGAR EL SERVICE N°: " + num, "INFORMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == System.Windows.Forms.DialogResult.Yes)
                {

                    //int res = Services.ServiceAnular(id);
                    //if (res > 0)
                    //{
                    //    MessageBox.Show("SERVICE DENEGADO CORRECTAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    dgvService.Columns.Clear();
                    //    CargarDataGrid();
                    //    PersonalizarGrid();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("OCURRIO UN ERROR AL DENEGAR EL SERVICE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    dgvService.Columns.Clear();
                    //    CargarDataGrid();
                    //    PersonalizarGrid();
                    //}



                }



            }



        }

       

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
