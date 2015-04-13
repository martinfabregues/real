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
    public partial class frmReportePendientesEntrega : Form
    {
        public string tiporeporte { get; set; }
        public int proid { get; set; }
        public frmReportePendientesEntrega(string tR, int pId)
        {
            proid = pId;
            tiporeporte = tR;
            InitializeComponent();
        }

        private void frmReportePendientesEntrega_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            this.WindowState = FormWindowState.Maximized;
            switch (tiporeporte)
            {
                case "PROVEEDOR":
                    dt.Clear();
                    dt = OrdenesCompraPendiente.GetOrdenCompraPendientePorIdProveedor(proid);
                    break;
                    
                case "COMPLETO":
                    
                    dt.Clear();
                    dt = OrdenesCompraPendiente.GetOrdenCompraPendienteTodo();
                    break;

            }     
            reportViewer1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportViewer1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\_reportePendientes.rdl";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            reportViewer1.RefreshReport();

        }
    }
}
