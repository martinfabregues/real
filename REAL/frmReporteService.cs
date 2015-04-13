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
    public partial class frmReporteService : Form
    {
        public int serid { get; set; }
        public frmReporteService(int sId)
        {
            serid = sId;
            InitializeComponent();
          
        }

        private void frmReporteService_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            //dt = Services.GetServiceDatosPodId(serid);
            //reportViewer1.Clear();
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //reportViewer1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\_reporteService.rdl";
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            //reportViewer1.RefreshReport();
        }

       
    }
}
