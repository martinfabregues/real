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
    public partial class frmConsultarEntregas : Form
    {
        public frmConsultarEntregas()
        {
            InitializeComponent();

        }




        private void btnCerrar_Click(object sender, EventArgs e)
        {

            this.Close();             
        }

        private void frmConsultarEntregas_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            IniciarControles();
            PersonalizarGrid();
        }

        private void IniciarControles()
        {
            CargarGridEntregas();
            //PersonalizarGrid();
            dtpDesde.Value = DateTime.Today.Date;
            dtpHasta.Value = DateTime.Today.Date;
        }

        private void CargarGridEntregas()
        {
            List<Entrega> listaEntrega = Entregas.GetTodos();
            List<Barrio> listaBarrio = Barrios.GetTodos();
            List<Sucursal> listaSucursal = Sucursales.GetTodos();
            List<TipoEntrega> listaTipoEntrega = TiposEntrega.GetTodos();
            List<TipoSalida> listaTipoSalida = TiposSalida.GetTodos();
            List<EstadoEntrega> listaEstado = EstadosEntrega.GetTodos();

            var resultado = (from ents in listaEntrega
                             join bars in listaBarrio on
                             ents.barid equals bars.barid
                             join sucs in listaSucursal on
                             ents.sucid equals sucs.sucid
                             join tent in listaTipoEntrega on
                             ents.tpeid equals tent.tpeid
                             join tsal in listaTipoSalida on
                             ents.tpsid equals tsal.tpsid
                             join ests in listaEstado on
                             ents.eseid equals ests.eseid
                             select new
                             {
                                 ents.remnumero,
                                 ents.entfecha,
                                 bars.barnombre,
                                 sucs.sucnombre,
                                 tent.tpetipo,
                                 ents.entcosto,
                                 tsal.tpstipo,
                                 ests.eseestado
                             }).ToList();

            dgvEntregas.DataSource = resultado;
            PersonalizarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (dtpDesde.Value <= dtpHasta.Value)
            {
                List<Entrega> listaEntrega = Entregas.GetEntreFechas(dtpDesde.Value, dtpHasta.Value);
                List<Barrio> listaBarrio = Barrios.GetTodos();
                List<Sucursal> listaSucursal = Sucursales.GetTodos();
                List<TipoEntrega> listaTipoEntrega = TiposEntrega.GetTodos();
                List<TipoSalida> listaTipoSalida = TiposSalida.GetTodos();
                List<EstadoEntrega> listaEstado = EstadosEntrega.GetTodos();

                var resultado = (from ents in listaEntrega
                                 join bars in listaBarrio on
                                 ents.barid equals bars.barid
                                 join sucs in listaSucursal on
                                 ents.sucid equals sucs.sucid
                                 join tent in listaTipoEntrega on
                                 ents.tpeid equals tent.tpeid
                                 join tsal in listaTipoSalida on
                                 ents.tpsid equals tsal.tpsid
                                 join ests in listaEstado on
                                 ents.eseid equals ests.eseid
                                 select new
                                 {
                                     ents.remnumero,
                                     ents.entfecha,
                                     bars.barnombre,
                                     sucs.sucnombre,
                                     tent.tpetipo,
                                     ents.entcosto,
                                     tsal.tpstipo,
                                     ests.eseestado
                                 }).ToList();

                dgvEntregas.DataSource = resultado;
                PersonalizarGrid();
            }
            else
            {
                errorProvider1.SetError(dtpDesde, "LA FECHA INICIAL NO PUEDE SER MAYOR A LA FINAL");

            }
        }

        private void PersonalizarGrid()
        {
            dgvEntregas.Columns[0].HeaderText = "N° REMITO";
            dgvEntregas.Columns[1].HeaderText = "FECHA";
            dgvEntregas.Columns[2].HeaderText = "BARRIO";
            dgvEntregas.Columns[3].HeaderText = "SUCURSAL";
            dgvEntregas.Columns[4].HeaderText = "CARGO";
            dgvEntregas.Columns[5].HeaderText = "COSTO";
            dgvEntregas.Columns[6].HeaderText = "TIPO ENTREGA";
            dgvEntregas.Columns[7].HeaderText = "ESTADO";
            dgvEntregas.Columns[5].DefaultCellStyle.Format = "c";
            dgvEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEntregas.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }

        private void frmConsultarEntregas_Resize(object sender, EventArgs e)
        {
            dgvEntregas.Width = this.Width - 20;
            dgvEntregas.Height = this.Height - 180;
            btnCerrar.Location = new Point(this.Width - 100, this.Height - 70);
        }
      
    }
}
