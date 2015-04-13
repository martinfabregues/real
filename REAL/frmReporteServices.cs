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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmReporteServices : Form
    {
        public int serid { get; set; }
        public frmReporteServices()
        {
           
            InitializeComponent();
        }

        private void frmReporteServices_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            //dt = Services.GetServiceObtenerDatos();
            reportViewer1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportViewer1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\_reporteServiceConsulta.rdl";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            reportViewer1.RefreshReport();
        }
    }
}
