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
    public partial class frmReporteEntregas : Form
    {
        private string tiporeport { get; set; }
        private DateTime desde { get; set; }
        private DateTime hasta { get; set; }
        public frmReporteEntregas(string t, DateTime d, DateTime h)
        {
            tiporeport = t;
            desde = d;
            hasta = h;
            InitializeComponent();
        }

        private void frmReporteEntregas_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            DataTable dt = new DataTable();
   
            switch (tiporeport)
            {
                case "HISTORICO":
                   
                    dt = Entregas.GetEntregasTodas();
                    break;
                case "MES":
                    dt = Entregas.GetEntregasDesdeHastaX(desde, hasta);
                    break;


                case "FECHA":
                    dt = Entregas.GetEntregasDesdeHastaX(desde, hasta);
                    break;

            }


            
            reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportViewer1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\Reports\_reporteEntregas.rdl";
          
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
           
            
            reportViewer1.RefreshReport();
        }
    }
}
