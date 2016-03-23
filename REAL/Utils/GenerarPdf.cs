using Entidad;
using Microsoft.Reporting.WinForms;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace REAL.Utils
{
    public class GenerarPdf
    {

        public static String ExportReportViewer2Pdf(ReportViewer rpt, int orden_id)
        {
            try
            {                          

                DataTable dt = new DataTable();
                dt.Clear();
                dt = OrdenesCompraDetalle.GetOrdencompraDetalleDatosPodId(orden_id);
                rpt.Clear();
                rpt.LocalReport.DataSources.Clear();
                rpt.BorderStyle = System.Windows.Forms.BorderStyle.None;
                rpt.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\ordencompra.rdl";
                rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;
                string deviceInfo = "<DeviceInfo><OutputFormat>PDF</OutputFormat></DeviceInfo>";
                byte[] bytes = rpt.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings) as byte[];

                OrdenCompra ordencompra = OrdenesCompra.FindById(orden_id);

                string path = ordencompra.proveedor.pronombre + " - " + ordencompra.numero +  ".pdf";

                FileStream fs = System.IO.File.Create("C:/ORDENES DE COMPRA/" + path);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                return "C:/ORDENES DE COMPRA/" + path;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
