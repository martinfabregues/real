using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmPrueba : Form
    {
        DataSet data = new DataSet();
        public frmPrueba()
        {
            InitializeComponent();
        }

        private void frmPrueba_Load(object sender, EventArgs e)
        {

            comboBox1.DisplayMember = "vendedor_nombre";
            comboBox1.ValueMember = "vendedor_id";
            List<Vendedor> list = Vendedores.GetTodos();
            foreach (Vendedor vendedor in list)
            {
                comboBox1.Items.Add(vendedor);
            }

            DataTable Orden = ConvertToDataTable(OrdenesCompra.GetTodo());

            DataTable detalles = OrdenesCompraDetalle.GetTodo();
            data.Tables.Add(Orden);
            data.Tables.Add(detalles);



            data.Relations.Add(new DataRelation("OrdenDetalle",
            data.Tables["Table1"].Columns["odcid"],
            data.Tables["Table2"].Columns["odcid"]));

            comboBox1.SelectedIndex = -1;
            comboBox1.SelectedText = "SELECCIONE VENDEDOR";
            dataGrid2.DataSource = data;
            dataGrid2.DataMember = "Table1";
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }


    }
}
