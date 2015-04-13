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
    public partial class frmEntregasConCosto : Form
    {
        public frmEntregasConCosto()
        {
            InitializeComponent();
            IniciarControles();

        }

        private void IniciarControles()
        {
            dtpDesde.Value = DateTime.Today.Date;
            dtpHasta.Value = DateTime.Today.Date;
            lblCantidad.Text = string.Empty;
            lblTotal.Text = string.Empty;
           
        }


        private void CargarGrid()
        {
            List<Entrega> listaEntrega = Entregas.GetConCostoEntreFechas(dtpDesde.Value, dtpHasta.Value);
            List<Sucursal> listaSucursal = Sucursales.GetTodos();
            List<Barrio> listaBarrio = Barrios.GetTodos();
            List<EstadoEntrega> listaEstado = EstadosEntrega.GetTodos();
            List<TipoEntrega> listaTipoEntrega = TiposEntrega.GetTodos();
            List<TipoSalida> listaTipoSalida = TiposSalida.GetTodos();

            //DataTable dt = new DataTable();
            //dt = Entregas.GetEntregasConCostoFechas(dtpDesde.Value, dtpHasta.Value);

            var resultado = (from ents in listaEntrega
                             join suc in listaSucursal on
                             ents.sucid equals suc.sucid
                             join bar in listaBarrio on
                             ents.barid equals bar.barid
                             join est in listaEstado on
                             ents.eseid equals est.eseid
                             join tpe in listaTipoEntrega on
                             ents.tpeid equals tpe.tpeid                            
                             select new
                             {
                                 ents.remnumero,
                                 ents.entfecha,
                                 suc.sucnombre,
                                 bar.barnombre,
                                 ents.entcosto,
                                 tpe.tpetipo,
                                 est.eseestado

                             }).ToList();

            dgvEntregas.DataSource = resultado;


            lblCantidad.Text = listaEntrega.Count.ToString();
            decimal total = 0;

            foreach (DataGridViewRow dr in dgvEntregas.Rows)
            {
                total = total + Convert.ToDecimal(dr.Cells[4].Value);
            }
            lblTotal.Text = "$ " +  total;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (dtpDesde.Value <= dtpHasta.Value)
            {
                CargarGrid();
                PersonalizarGrid();
            }
            else
            {
                errorProvider1.SetError(dtpDesde, "LA FECHA DE INICIO NO PUEDE SER MAYOR A LA FINAL");
            }
        }

        private void PersonalizarGrid()
        {
            dgvEntregas.Columns[0].HeaderText = "N° REMITO";
            dgvEntregas.Columns[1].HeaderText = "FECHA";
            dgvEntregas.Columns[2].HeaderText = "SUCURSAL";
            dgvEntregas.Columns[3].HeaderText = "BARRIO";
            dgvEntregas.Columns[4].HeaderText = "IMPORTE";
            dgvEntregas.Columns[5].HeaderText = "TIPO ENTREGA";
            dgvEntregas.Columns[6].HeaderText = "ESTADO";

            dgvEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEntregas.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;

            dgvEntregas.Columns[4].DefaultCellStyle.Format = "c";
        }

        private void frmEntregasConCosto_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmEntregasConCosto_Resize(object sender, EventArgs e)
        {
            dgvEntregas.Width = this.Width - 30;
            dgvEntregas.Height = this.Height - 250;
            btnCerrar.Location = new Point(this.Width - 110, this.Height - 80);
            groupBox1.Location = new Point(10, this.Height - 130);
        }

       

    }
}
