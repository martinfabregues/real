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
using System.Windows.Forms;

namespace REAL
{
    public partial class frmRecepcionEntrega : Form
    {
        public frmRecepcionEntrega()
        {
            InitializeComponent();
        }

        private void frmRecepcionEntrega_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;

            DataTable entregas = Entregas.GetPorFecha(DateTime.Today.Date);
            DataTable cantidad = Entregas.GetCantidad(DateTime.Today.Date);
            reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportViewer1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\_reporteRecepcion.rdl";

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", entregas));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", cantidad));

            reportViewer1.RefreshReport();
        }
    }
}
