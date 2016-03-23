using Entidad;
using Microsoft.Reporting.WinForms;
using Negocio;
using Npgsql;
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
    public partial class frmReporteOrdenCompra : Form
    {
        public int ocdid { get; set; }
        private NpgsqlConnection db { get; set; }

        public frmReporteOrdenCompra(int oId)
        {
            ocdid = oId;
            InitializeComponent();
        }



        private void frmReporteOrdenCompra_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            dt = OrdenesCompraDetalle.GetOrdencompraDetalleDatosPodId(ocdid);
            reportViewer1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportViewer1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\ordencompra.rdl";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            reportViewer1.RefreshReport();

        }
    }
}
