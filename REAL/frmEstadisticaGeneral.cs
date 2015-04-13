using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace REAL
{
    public partial class frmEstadisticaGeneral : Form
    {
        public frmEstadisticaGeneral()
        {
            InitializeComponent();
            IniciarControles();
            //CargarDatos();
            //CargarSucursalesChart();
            //CargarChartBarrios();
            //CrearGrid();
            //CargarGridDias();
        }

        private void IniciarControles()
        {
            DateTimeFormatInfo formato = CultureInfo.CurrentCulture.DateTimeFormat;
            //string mes = formato.GetMonthName(DateTime.Today.Date.Month);
            //lblMes.Text = mes.ToString().ToUpper() + " " + DateTime.Today.Date.Year;
            txtCliente.Enabled = false;
            txtInterna.Enabled = false;
            txtTotal.Enabled = false;
            txtCargo.Enabled = false;

        }

        private void CargarDatos()
        {
            int mes = cmbMes.SelectedIndex + 1;
            int ano = Convert.ToInt32(cmbAno.Text);

            
            DateTime primerdia = new DateTime(ano, mes, 1);
            DateTime ultimodia = primerdia.AddMonths(1).AddDays(-1);

            DataTable dtCliente = new DataTable();
            dtCliente = TiposSalida.TipoSalidaObtenerACliente(primerdia, ultimodia);

            DataTable dtInterna = new DataTable();
            dtInterna = TiposSalida.TipoSalidaObtenerInterna(primerdia, ultimodia);

            DataTable dtCargo = new DataTable();
            dtCargo = TiposSalida.TipoSalidaObtenerConCargo(primerdia, ultimodia);

            txtCliente.Text = dtCliente.Rows[0].ItemArray[0].ToString();
            txtInterna.Text = dtInterna.Rows[0].ItemArray[0].ToString();
            txtCargo.Text = dtCargo.Rows[0].ItemArray[0].ToString();
            txtTotal.Text = (Convert.ToInt32(dtCliente.Rows[0].ItemArray[0]) + Convert.ToInt32(dtInterna.Rows[0].ItemArray[0])).ToString();

        }


        private void frmEstadisticaGeneral_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            cmbAno.SelectedIndex = 0;
            cmbMes.SelectedIndex = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarSucursalesChart()
        {
            crtSucursal.Series.Clear();
            crtSucursal.Titles.Clear();
            


            int mes = cmbMes.SelectedIndex + 1;
            int ano = Convert.ToInt32(cmbAno.Text);

            
            DateTime primerdia = new DateTime(ano, mes, 1);
            DateTime ultimodia = primerdia.AddMonths(1).AddDays(-1);
            DataTable dt = new DataTable();
            dt = Sucursales.SucursalObtenerCantidadEntregas(primerdia, ultimodia);

            crtSucursal.ChartAreas[0].Area3DStyle.Enable3D = true;
            crtSucursal.Titles.Add("ENTREGAS POR SUCURSAL");
            crtSucursal.ChartAreas[0].AxisX.Title = "Sucursales";
            crtSucursal.ChartAreas[0].AxisY.Title = "Cantidad de Entregas";
            crtSucursal.ChartAreas[0].Area3DStyle.Inclination = 1;
            crtSucursal.ChartAreas[0].Area3DStyle.Rotation = 2;

            
           
            foreach(DataRow dr in dt.Rows)
            {
                Series S = new Series();
                S.Points.AddXY(dr.ItemArray[0], dr.ItemArray[2]);
                S.Name = dr.ItemArray[1].ToString();
                S.ChartType = SeriesChartType.Column;
                crtSucursal.Series.Add(S);
                crtSucursal.Series[S.Name].AxisLabel = dr.ItemArray[1].ToString();
                crtSucursal.Series[S.Name].IsValueShownAsLabel = false;
                crtSucursal.Series[S.Name].ToolTip = "#VAL";
            }
          
            

        }


        private void CargarChartBarrios()
        {
            crtBarrios.Titles.Clear();

            int mes = cmbMes.SelectedIndex + 1;
            int ano = Convert.ToInt32(cmbAno.Text);

            
            DateTime primerdia = new DateTime(ano, mes, 1);
            DateTime ultimodia = primerdia.AddMonths(1).AddDays(-1);
            crtBarrios.Titles.Add("TOP 10 BARRIOS MAS CONCURRIDOS");
            crtBarrios.DataSource = Barrios.BarrioObtenerEntregasPorBarrio(primerdia, ultimodia);
            crtBarrios.ChartAreas[0].Area3DStyle.Enable3D = true;
            crtBarrios.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            crtBarrios.Series[0].XValueMember = "barnombre";
            crtBarrios.Series[0].YValueMembers = "cantidad";
            crtBarrios.Series[0].IsValueShownAsLabel = false;
            crtBarrios.Series[0].ToolTip = "#VAL";



            crtBarrios.DataBind();
       

        }


        private void CrearGrid()
        {
            //this.dgvDias.AutoGenerateColumns = false;
            //this.dgvDias.Columns.Clear();

            //DataGridViewTextBoxColumn fecha = new DataGridViewTextBoxColumn();
            //fecha.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //fecha.HeaderText = "FECHA";
            //fecha.Name = "FECHA";
            ////Codigo.Name = "ID";
            //fecha.DataPropertyName = "FECHA";

            //DataGridViewTextBoxColumn cliente = new DataGridViewTextBoxColumn();
            //cliente.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //cliente.HeaderText = "CLIENTE";
            //cliente.Name = "CLIENTE";
            ////Codigo.Name = "ID";
            //cliente.DataPropertyName = "CLIENTE";

            //DataGridViewTextBoxColumn interna = new DataGridViewTextBoxColumn();
            //interna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //interna.HeaderText = "INTERNA";
            //interna.Name = "INTERNA";
            ////Codigo.Name = "ID";
            //interna.DataPropertyName = "INTERNA";

            //DataGridViewTextBoxColumn cargo = new DataGridViewTextBoxColumn();
            //cargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //cargo.HeaderText = "C/COSTO";
            //cargo.Name = "CONCOSTO";
            ////Codigo.Name = "ID";
            //cargo.DataPropertyName = "CONCOSTO";

            //DataGridViewTextBoxColumn total = new DataGridViewTextBoxColumn();
            //total.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //total.HeaderText = "TOTAL";
            //total.Name = "TOTAL";
            ////Codigo.Name = "ID";
            //total.DataPropertyName = "TOTAL";

            //DataGridViewTextBoxColumn acumulado = new DataGridViewTextBoxColumn();
            //acumulado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //acumulado.HeaderText = "ACUMULADO";
            //acumulado.Name = "ACUMULADO";
            ////Codigo.Name = "ID";
            //acumulado.DataPropertyName = "ACUMULADO";

            //dgvDias.Columns.Add(fecha);
            //dgvDias.Columns.Add(cliente);
            //dgvDias.Columns.Add(interna);
            //dgvDias.Columns.Add(cargo);
            //dgvDias.Columns.Add(total);
            //dgvDias.Columns.Add(acumulado);

            //dgvDias.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
        }


        private void CargarGridDias()
        {
            dgvDias.DataSource = null;
            int mes = cmbMes.SelectedIndex + 1;
            int ano = Convert.ToInt32(cmbAno.Text);
           
            DateTime primerdia = new DateTime(ano, mes, 1);
            DateTime ultimodia = primerdia.AddMonths(1).AddDays(-1);
            
            int uno = primerdia.Day;
            int ult = ultimodia.Day;
            //int ano = fecha.Year;
            //int mes = fecha.Month;

            //DataTable dtCliente = new DataTable();
            //DataTable dtInternas = new DataTable();
            //DataTable dtCargo = new DataTable();
            //int acum = 0;

            DataTable dt = new DataTable();
            dt = Entregas.GetDetallePorDias(primerdia, ultimodia);
            if (dt.Rows.Count > 0)
            {
                dgvDias.DataSource = dt.DefaultView;
                PersonalizarGrid();
            }
            //for(int i = 1; i <= ult; i++)
            //{
            //    dtCliente.Clear();
            //    dtInternas.Clear();
            //    dtCargo.Clear();

            //    DateTime fec = new DateTime(ano, mes, i);
            //    dtCliente = TiposSalida.TipoSalidaObtenerACliente(fec, fec);
            //    dtInternas = TiposSalida.TipoSalidaObtenerInterna(fec, fec);
            //    dtCargo = TiposSalida.TipoSalidaObtenerConCargo(fec, fec);
            //    int total = Convert.ToInt32(dtCliente.Rows[0].ItemArray[0]) + Convert.ToInt32(dtInternas.Rows[0].ItemArray[0]);
            //    acum = acum + total;

            //    dgvDias.Rows.Add(fec, dtCliente.Rows[0].ItemArray[0], dtInternas.Rows[0].ItemArray[0], dtCargo.Rows[0].ItemArray[0], total, acum);

            //}


        }

        private void PersonalizarGrid()
        {
            dgvDias.Columns[0].HeaderText = "FECHA";
            dgvDias.Columns[1].HeaderText = "CON CARGO";
            dgvDias.Columns[2].HeaderText = "SIN CARGO";
            dgvDias.Columns[3].HeaderText = "INTERNA";
            dgvDias.Columns[4].HeaderText = "TOTAL";

            dgvDias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDias.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }


        private void dgvDias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvDias.Columns[e.ColumnIndex].Name == "CLIENTE")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    e.Value = "-";
                }
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            if (this.dgvDias.Columns[e.ColumnIndex].Name == "INTERNA")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    e.Value = "-";
                }
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            if (this.dgvDias.Columns[e.ColumnIndex].Name == "CONCOSTO")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    e.Value = "-";
                }
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            if (this.dgvDias.Columns[e.ColumnIndex].Name == "TOTAL")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    e.Value = "-";
                }
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                e.CellStyle.BackColor = Color.LightGray;
            }

            if (this.dgvDias.Columns[e.ColumnIndex].Name == "ACUMULADO")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    e.Value = "-";
                }
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        private void frmEstadisticaGeneral_Resize(object sender, EventArgs e)
        {
            btnCerrar.Location = new Point(this.Width - 110, this.Height - 70);
            tabControl1.Height = this.Height - 170;
            dgvDias.Height = tabControl1.Height - 100;
            btnImprimir.Location = new Point(30, this.Height - 70);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int mes = cmbMes.SelectedIndex + 1;
            int ano = Convert.ToInt32(cmbAno.Text);
            DateTime primerdia = new DateTime(ano, mes, 1);
            DateTime ultimodia = primerdia.AddMonths(1).AddDays(-1);
            frmReporteEntregasEstadistica frm = new frmReporteEntregasEstadistica(primerdia, ultimodia);
            frm.MdiParent = this.MdiParent;
            frm.Text = "ENTREGAS - ESTADISTÍCA";
            frm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            CargarDatos();
            CargarSucursalesChart();
            CargarChartBarrios();
            CrearGrid();
            CargarGridDias();
        }


    }
}
