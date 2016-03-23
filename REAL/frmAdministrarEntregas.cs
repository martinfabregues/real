using Negocio;
using REAL.Utils;
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
    public partial class frmAdministrarEntregas : Form
    {
        public frmAdministrarEntregas()
        {
            InitializeComponent();
            //IniciarControles();
        }

        private void IniciarControles()
        {

            dtpDesde.Value = DateTime.Today.Date;
            dtpHasta.Value = DateTime.Today.Date;

            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;

            txtNumero.Enabled = false;
        }


        private void FiltrarForm()
        {
            DateTime? fec_desde = ckbFecha.Checked ? (DateTime?)dtpDesde.Value : null;
            DateTime? fec_hasta = ckbFecha.Checked ? (DateTime?)dtpHasta.Value : null;
            string nro_remito = txtNumero.Text == string.Empty ? null : txtNumero.Text;

            var query = (from entrega in Entregas.FindAllFiltro(fec_desde, fec_hasta, nro_remito).OrderByDescending(x => x.entfecha).Take(50)
                         select new
                         {
                             entrega.entid,
                             entrega.remnumero,
                             entfecha = entrega.entfecha.ToShortDateString(),
                             entrega.barrio.barnombre,
                             entrega.sucursal.sucnombre,
                             entrega.tipo_entrega.tpetipo,
                             entrega.entcosto,
                             entrega.tipo_salida.tpstipo,
                             entrega.estado_entrega.eseestado
                         }).ToList();

            dgvEntregas.Rows.Clear();
            foreach(var row in query)
            {
                dgvEntregas.Rows.Add(row.entid, row.remnumero, row.entfecha, row.barnombre,
                    row.sucnombre, row.tpetipo, row.entcosto, row.tpstipo, row.eseestado);
            }

            dgvEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
            dgvEntregas.Columns[0].Visible = false;
        }


        private void CargarGridEntregas()
        {
            IniciarControles();

            dgvEntregas.DataSource = Entregas.GetEntregasTodasConId();
            
        }

        private void PersonalizarGrid()
        {
            DataGridViewButtonColumn Modificar = new DataGridViewButtonColumn();
            Modificar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Modificar.HeaderText = "Modificar";
            Modificar.Name = "btnModificar";
            Modificar.Text = "Modificar Entrega";
            Modificar.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn Confirmar = new DataGridViewButtonColumn();
            Confirmar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Confirmar.HeaderText = "Confirmar Recepción";
            Confirmar.Name = "btnConfirmar";
            Confirmar.Text = "Confirmar Recepción";
            Confirmar.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn Anular = new DataGridViewButtonColumn();
            Anular.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Anular.HeaderText = "Anular";
            Anular.Name = "btnAnular";
            Anular.Text = "Anular Entrega";
            Anular.UseColumnTextForButtonValue = true;

            dgvEntregas.Columns.Add(Modificar);
            dgvEntregas.Columns.Add(Confirmar);
            dgvEntregas.Columns.Add(Anular);

            dgvEntregas.Columns[0].Visible = false;
            dgvEntregas.Columns[1].HeaderText = "N° Remito";
            dgvEntregas.Columns[2].HeaderText = "Fecha";
            dgvEntregas.Columns[3].Visible = false;
            dgvEntregas.Columns[4].Visible = false;
            dgvEntregas.Columns[5].Visible = false;
            dgvEntregas.Columns[6].Visible = false;
            dgvEntregas.Columns[7].HeaderText = "Barrio";
            dgvEntregas.Columns[8].HeaderText = "Sucursal";
            dgvEntregas.Columns[9].HeaderText = "Cargo";
            dgvEntregas.Columns[10].HeaderText = "Costo";
            dgvEntregas.Columns[11].HeaderText = "Tipo Entrega";
            dgvEntregas.Columns[12].HeaderText = "Estado";
            dgvEntregas.Columns[10].DefaultCellStyle.Format = "c";
            //dgvEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvEntregas.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdministrarEntregas_Resize(object sender, EventArgs e)
        {
            //dgvEntregas.Width = this.Width - 20;
            //dgvEntregas.Height = this.Height - 180;
            //btnCerrar.Location = new Point(this.Width - 100, this.Height - 90);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //lblValidacion.Text = string.Empty;
            //dgvEntregas.Columns.Clear();
            //errorProvider1.Clear();
            //if (ckbFecha.Checked == true)
            //{
            //    if (dtpDesde.Value <= dtpHasta.Value)
            //    {
            //        dgvEntregas.DataSource = Entregas.GetEntregasFechas(dtpDesde.Value, dtpHasta.Value).DefaultView;
            //        PersonalizarGrid();
            //    }
            //    else
            //    {
            //        errorProvider1.SetError(dtpHasta, "LA FECHA DE INICIO NO PUEDE SER MAYOR A LA FINAL");
            //        dtpDesde.Focus();
            //    }
            //}
            //else
            //{
            //    if (ckbNumero.Checked == true)
            //    {
            //        DataTable dt = new DataTable();
            //        dt = Entregas.GetEntregasPorRemito(txtNumero.Text);
            //        if (dt.Rows.Count > 0)
            //        {
            //            dgvEntregas.DataSource = dt.DefaultView;
            //            PersonalizarGrid();
            //        }
            //        else
            //        {
            //            //lblValidacion.Text = "NO SE ENCONTRO NINGUNA ENTREGA CON ESE NÚMERO DE REMITO.";
                        
            //        }

                    
            //    }
            //    else
            //    {
            //        CargarGridEntregas();
            //        PersonalizarGrid();
            //    }
            //}

            FiltrarForm();
        }

        private void ActualizarGrid()
        {
            //lblValidacion.Text = string.Empty;
            dgvEntregas.Columns.Clear();

            if (ckbFecha.Checked == true)
            {
                dgvEntregas.DataSource = Entregas.GetEntregasFechas(dtpDesde.Value, dtpHasta.Value).DefaultView;
                PersonalizarGrid();
            }
            else
            {
                if (ckbNumero.Checked == true)
                {
                    DataTable dt = new DataTable();
                    dt = Entregas.GetEntregasPorRemito(txtNumero.Text);
                    if (dt.Rows.Count > 0)
                    {
                        dgvEntregas.DataSource = dt.DefaultView;
                        PersonalizarGrid();
                    }
                    else
                    {
                        //lblValidacion.Text = "NO SE ENCONTRO NINGUNA ENTREGA CON ESE NÚMERO DE REMITO.";

                    }


                }
                else
                {
                    CargarGridEntregas();
                    PersonalizarGrid();
                }
            }
        }

        private void frmAdministrarEntregas_Load(object sender, EventArgs e)
        {
            IniciarControles();
            FiltrarForm();
        }

        private void dgvEntregas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(9))
            {
                DataGridViewRow fila = dgvEntregas.CurrentRow;

                int id = Convert.ToInt32(fila.Cells[0].Value);

                frmModificarEntrega frm = new frmModificarEntrega(id);
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    ActualizarGrid();
                   
                }
               
            }

            if (e.ColumnIndex.Equals(10))
            {
                DataGridViewRow fila = dgvEntregas.CurrentRow;

                int id = Convert.ToInt32(fila.Cells[0].Value);
                string rem = fila.Cells[1].Value.ToString();
                DialogResult dlg = new DialogResult();
                dlg = MessageBox.Show("Esta seguro de confirmar la recepción de la entrega? " + rem + " ?", "Atención", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    int resultado = 0;
                    resultado = Entregas.EntregaActualizarRecibido(id);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Los datos se registraron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrid();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al registrar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActualizarGrid();
                    }
                }
            }

            if (e.ColumnIndex.Equals(11))
            {
                DataGridViewRow fila = dgvEntregas.CurrentRow;

                int id = Convert.ToInt32(fila.Cells[0].Value);
                string rem = fila.Cells[1].Value.ToString();
                DialogResult dlg = new DialogResult();
                dlg = MessageBox.Show("Esta seguro de anular la entrega? " + rem + " ?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    int resultado = 0;
                    resultado = Entregas.EntregaAnular(id);
                    if (resultado > 0)
                    {
                        MessageBox.Show("La entrega se anulo correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrid();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al anular la entrega.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActualizarGrid();
                    }
                }
            }
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
               dtpDesde.Enabled = false;
               dtpHasta.Enabled = false;
           }
        }

        private void ckbNumero_CheckedChanged(object sender, EventArgs e)
        {
            txtNumero.Text = string.Empty;

            if (ckbNumero.CheckState == CheckState.Checked)
                txtNumero.Enabled = true;
            else
                txtNumero.Enabled = false;
        }


        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO REMITO.";
                e.Handled = true;
                txtNumero.Focus();
                return;
            }
        }

       

       
    }
}
