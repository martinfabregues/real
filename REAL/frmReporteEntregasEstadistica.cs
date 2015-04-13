using Microsoft.Reporting.WinForms;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmReporteEntregasEstadistica : Form
    {
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }

        public frmReporteEntregasEstadistica(DateTime d, DateTime h)
        {
            desde = d;
            hasta = h;
            InitializeComponent();
        }

        private void frmReporteEntregasEstadistica_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            int mes = 0;
            string mesest = string.Empty;
            mes = desde.Month;
            switch(mes)
            {
                case 1:
                    mesest = "ENERO";
                    break;
                case 2:
                    mesest = "FEBRERO";
                    break;
                case 3:
                    mesest = "MARZO";
                    break;
                case 4:
                    mesest = "ABRIL";
                    break;
                case 5:
                    mesest = "MAYO";
                    break;
                case 6:
                    mesest = "JUNIO";
                    break;
                case 7:
                    mesest = "JULIO";
                    break;
                case 8:
                    mesest = "AGOSTO";
                    break;
                case 9:
                    mesest = "SEPTIEMBRE";
                    break;
                case 10:
                    mesest = "OCTUBRE";
                    break;
                case 11:
                    mesest = "NOVIEMBRE";
                    break;
                case 12:
                    mesest = "DICIEMBRE";
                    break;
            }




            this.WindowState = FormWindowState.Maximized;
            DataTable dtEntregas = new DataTable();
            DataTable dtBarrios = new DataTable();
            DataTable dtTotales = new DataTable();
            DataTable dtSucursal = new DataTable();

            dtEntregas = Entregas.GetDetallePorDias(desde, hasta);
            dtBarrios = Barrios.BarrioObtenerEntregasPorBarrio(desde, hasta);
            dtTotales = Entregas.GetTotalesentreFechas(desde, hasta);
            dtSucursal = Sucursales.SucursalObtenerCantidadEntregas(desde, hasta);

            reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportViewer1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\_reporteEstadistica.rdl";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dtEntregas));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dtBarrios));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", dtTotales));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet4", dtSucursal));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("mes", mesest));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("año", desde.Year.ToString()));
            reportViewer1.RefreshReport();
        }
    }
}
