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
    public partial class frmReporteIngresos : Form
    {
        public frmReporteIngresos()
        {
            InitializeComponent();
        }

        private void frmReporteIngresos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            DataTable dt = new DataTable();
            dt = FacturasProveedorDetalle.GetFacturaProveedorTodo();

            reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportViewer1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\_ReporteIngresos.rdl";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            reportViewer1.RefreshReport();


        }
    }
}
