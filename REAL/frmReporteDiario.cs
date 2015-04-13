using Entidad;
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
    public partial class frmReporteDiario : Form
    {
        public frmReporteDiario()
        {
            InitializeComponent();
        }

        private void frmReporteDiario_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            //DataTable dt = new DataTable();
            //dt.Clear();
            //dt = Entregas.GetEntregasPorFecha(DateTime.Today.Date);
            DataTable dt = Entregas.GetEntregasPorDia(DateTime.Today.Date);
            reportViewer1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportViewer1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\_reporteInforme.rdl";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            reportViewer1.RefreshReport();
        }
    }
}
