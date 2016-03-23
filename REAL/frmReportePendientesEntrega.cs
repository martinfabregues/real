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
    public partial class frmReportePendientesEntrega : Form
    {
        private List<OrdenCompraPendiente> pendientesL;
        public frmReportePendientesEntrega(List<OrdenCompraPendiente> _pendientesL)
        {
            pendientesL = _pendientesL;
            InitializeComponent();
        }

        private void frmReportePendientesEntrega_Load(object sender, EventArgs e)
        {

            var query = (from row in pendientesL
                        select new
                        {
                            odcnumero = row.ordencompra.numero,
                            odcfecha = row.ordencompra.fecha,
                            pronombre = row.proveedor.pronombre,
                            proid = row.proveedor.proid,
                            prdcodigo = row.producto.prdcodigo,
                            prddenominacion = row.producto.prddenominacion,
                            ocdcantidad = row.cantidad,
                            ocdimporte = row.importe_unitario,
                            total = (row.cantidad * row.importe_unitario),
                            sucnombre = row.sucursal.sucnombre
                        });


            ReportDataSource rds = new ReportDataSource();
            rds = new ReportDataSource("DataSet1", query);

            reportViewer1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\Pendientes.rdl";
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            //this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();

        }
    }
}
