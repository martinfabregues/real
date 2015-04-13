using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Entidad;
using Negocio;
using System.IO;

namespace REAL.Reportes
{
    public partial class _reporteComprasListado : Form
    {
        public _reporteComprasListado()
        {
            InitializeComponent();
        }

        private void _reporteComprasListado_Load(object sender, EventArgs e)
        {
            IList<OrdenCompra> datos = OrdenesCompra.FindAll();
            reportViewer1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportViewer1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\_reporteOrdenes.rdl";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", datos));
            reportViewer1.RefreshReport();
        }

     
    }
}
