using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace REAL
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            ComprasPorProveedor();
            ProductosMasComprados();
        }

        private void ComprasPorProveedor()
        {
            crtComprasPorProveedor.Titles.Clear();

            int mes = DateTime.Now.Month;
            int ano = DateTime.Now.Year;
            DateTime primerdia = new DateTime(ano, mes, 1);
            DateTime ultimodia = primerdia.AddMonths(1).AddDays(-1);

            dynamic dynamic = FacturasProveedor.FindComprasMes(primerdia, ultimodia);

            Dictionary<string, double> _dict = new Dictionary<string, double>();
            foreach(var fila in dynamic)
            {             
                _dict.Add((string)fila.pronombre, (double)fila.total);                             
            }

            var query = (from fila in _dict
                         select new
                         {
                             pronombre = (string)fila.Key,
                             total= (double)fila.Value
                         }).ToList();


            Title title = crtComprasPorProveedor.Titles.Add("Compras Por Proveedor " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(MonthName(mes)) + " " + ano);
            title.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
          
            crtComprasPorProveedor.DataSource = query;
            crtComprasPorProveedor.ChartAreas[0].Area3DStyle.Enable3D = true;
            crtComprasPorProveedor.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            crtComprasPorProveedor.Series[0].XValueMember = "pronombre";
            crtComprasPorProveedor.Series[0].YValueMembers = "total";
            crtComprasPorProveedor.Series[0].IsValueShownAsLabel = false;
            crtComprasPorProveedor.Series[0].ToolTip = "$ " + "#VAL";

            crtComprasPorProveedor.DataBind();

        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }


        private void ProductosMasComprados()
        {
            crtProductos.Titles.Clear();

            int mes = DateTime.Now.Month;
            int ano = DateTime.Now.Year;
            DateTime primerdia = new DateTime(ano, mes, 1);
            DateTime ultimodia = primerdia.AddMonths(1).AddDays(-1);

            Dictionary<string, int> dict = FacturasProveedor.FindProductosMasComprados(primerdia, ultimodia);

            var query = (from fila in dict
                         select new
                         {
                             prddenominacion = (string)fila.Key,
                             cantidad = (double)fila.Value
                         }).ToList();

            Title title = crtProductos.Titles.Add("Productos más Comprados " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(MonthName(mes)) + " " + ano);
            title.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);

            crtProductos.DataSource = query;
            crtProductos.ChartAreas[0].Area3DStyle.Enable3D = true;
            crtProductos.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pyramid;
            crtProductos.Series[0].XValueMember = "prddenominacion";
            crtProductos.Series[0].YValueMembers = "cantidad";
            crtProductos.Series[0].IsValueShownAsLabel = false;
            crtProductos.Series[0].ToolTip = "#VAL";

            crtComprasPorProveedor.DataBind();



        }




    }
}
