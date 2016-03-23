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

namespace REAL
{
    public partial class frmEstadisticaAnual : Form
    {
        private string[] meses = new string[12];

        public frmEstadisticaAnual()
        {
            InitializeComponent();
            IniciarControles();
            CrearColumnas();
            CargarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IniciarControles()
        {
            meses[0] = "ENERO";
            meses[1] = "FEBRERO";
            meses[2] = "MARZO";
            meses[3] = "ABRIL";
            meses[4] = "MAYO";
            meses[5] = "JUNIO";
            meses[6] = "JULIO";
            meses[7] = "AGOSTO";
            meses[8] = "SEPTIEMBRE";
            meses[9] = "OCTUBRE";
            meses[10] = "NOVIEMBRE";
            meses[11] = "DICIEMBRE";


            ////dgvEstadistica.DataSource = null;
            cmbAnos.Items.Add("2013");
            cmbAnos.Items.Add("2014");
            cmbAnos.Items.Add("2015");
            cmbAnos.Items.Add("2016");
            cmbAnos.SelectedIndex = 0;
        }

        private void CrearColumnas()
        {
            this.dgvEstadistica.AutoGenerateColumns = false;
            this.dgvEstadistica.Columns.Clear();

            DataGridViewTextBoxColumn Mes = new DataGridViewTextBoxColumn();
            Mes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Mes.HeaderText = "MES";
            Mes.Name = "MES";
            //Codigo.Name = "ID";
            Mes.DataPropertyName = "MES";

            DataGridViewTextBoxColumn sincargo = new DataGridViewTextBoxColumn();
            sincargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sincargo.HeaderText = "SIN CARGO";
            sincargo.Name = "SINCARGO";
            //Usuario.Name = "USUARIO";
            sincargo.DataPropertyName = "SIN CARGO";

            DataGridViewTextBoxColumn internas = new DataGridViewTextBoxColumn();
            internas.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            internas.HeaderText = "INTERNAS";
            internas.Name = "INTERNAS";
            //TipoUsuario.Name = "TIPO_USUARIO";
            internas.DataPropertyName = "INTERNAS";

            DataGridViewTextBoxColumn cargo = new DataGridViewTextBoxColumn();
            cargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cargo.HeaderText = "CON CARGO";
            cargo.Name = "CARGO";
            //FechaAlta.Name = "FECHA_ALTA";
            cargo.DataPropertyName = "CON CARGO";

            DataGridViewTextBoxColumn total = new DataGridViewTextBoxColumn();
            total.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            total.HeaderText = "TOTAL";
            total.Name = "TOTAL";
            //FechaAlta.Name = "FECHA_ALTA";
            total.DataPropertyName = "TOTAL";

            dgvEstadistica.Columns.Add(Mes);
            dgvEstadistica.Columns.Add(sincargo);
            dgvEstadistica.Columns.Add(internas);
            dgvEstadistica.Columns.Add(cargo);
            dgvEstadistica.Columns.Add(total);
        }


        private void CargarDatos()
        {
            dgvEstadistica.Rows.Clear();
            DataTable dtCliente = new DataTable();
            DataTable dtInterna = new DataTable();
            DataTable dtCargo = new DataTable();
            for (int i = 0; i < 12; i++)
            {
                DateTimeFormatInfo formato = CultureInfo.CurrentCulture.DateTimeFormat;
                string mes = formato.GetMonthName(i + 1);
                DateTime primerdia = new DateTime(Convert.ToInt32(cmbAnos.Text), i + 1, 1);
                DateTime ultimodia = primerdia.AddMonths(1).AddDays(-1);

                dtCliente.Rows.Clear();
                dtInterna.Rows.Clear();
                dtCargo.Rows.Clear();
                dtCliente = TiposSalida.TipoSalidaObtenerACliente(primerdia, ultimodia); 
                dtInterna = TiposSalida.TipoSalidaObtenerInterna(primerdia, ultimodia);    
                dtCargo = TiposSalida.TipoSalidaObtenerConCargo(primerdia, ultimodia);
                int total = Convert.ToInt32(dtCliente.Rows[0].ItemArray[0]) + Convert.ToInt32(dtInterna.Rows[0].ItemArray[0]);
                dgvEstadistica.Rows.Add(mes.ToUpper(), dtCliente.Rows[0].ItemArray[0].ToString(), dtInterna.Rows[0].ItemArray[0].ToString(), dtCargo.Rows[0].ItemArray[0].ToString(), total);

            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dgvEstadistica_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvEstadistica.Columns[e.ColumnIndex].Name == "MES")
            { 
                   
                //e.CellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
              
            }
            if (this.dgvEstadistica.Columns[e.ColumnIndex].Name == "SINCARGO")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    e.Value = "-";
                }
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            if (this.dgvEstadistica.Columns[e.ColumnIndex].Name == "INTERNAS")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    e.Value = "-";
                }
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            if (this.dgvEstadistica.Columns[e.ColumnIndex].Name == "CARGO")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    e.Value = "-";
                }
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            if (this.dgvEstadistica.Columns[e.ColumnIndex].Name == "TOTAL")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    e.Value = "-";
                }
                e.CellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.BackColor = Color.LightGray;
            }


        }

        private void frmEstadisticaAnual_Load(object sender, EventArgs e)
        {
       
        }

        private void frmEstadisticaAnual_Resize(object sender, EventArgs e)
        {
            btnCerrar.Location = new Point(this.Width - 110, this.Height - 80);
        }

    }
}
