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
    public partial class frmReporteProductos : Form
    {
        public string tmov { get; set; }
        public int proid { get; set; }
        public frmReporteProductos(string tM, int pI)
        {
            tmov = tM;
            proid = pI;
            InitializeComponent();
        }

        private void frmReporteProductos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            DataTable dt = new DataTable();
            switch (tmov)
            {
                case "COMPLETO":

                    dt = Productos.GetProductosTodos();
                    break;
                case "PROVEEDOR":
                    dt = Productos.GetProductoPorIdProveedor(proid);
                    break;


               

            }



            reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportViewer1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\_ReporteProductos.rdl";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            reportViewer1.RefreshReport();
        }
    }
}
