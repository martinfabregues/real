using DAL.Repositories;
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
    public partial class frmService : Form
    {
        private List<ServiceDetalle> detalle = new List<ServiceDetalle>();
        public frmService()
        {
            InitializeComponent();
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            IniciarControles();
            CargarComboProveedor();
            CargarComboSucursal();
            CrearGrilla();
        }


        private void CrearGrilla()
        {
            DataGridViewButtonColumn Eliminar = new DataGridViewButtonColumn();
            Eliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Eliminar.HeaderText = "Eliminar";
            Eliminar.Name = "btnEliminar";
            Eliminar.Text = "Eliminar del Detalle";
            Eliminar.UseColumnTextForButtonValue = true;

            dgvServices.Columns.Add(Eliminar);
        }

        private void CargarDataGrid()
        {
            IList<Service> datos = Services.FindAll();
            dgvServices.DataSource = datos;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IniciarControles()
        {
            txtDescripcion.Enabled = false;
            txtIdProducto.Visible = false;
            txtCodigo.Enabled = false;
            txtIdCliente.Visible = false;
            txtRazonSocial.Enabled = false;
            txtNumero.Enabled = false;
            txtBarrio.Enabled = false;
            txtCalle.Enabled = false;
            txtCiudad.Enabled = false;
            txtDocumento.Enabled = false;
            txtTipoCliente.Enabled = false;

            dgvServices.Rows.Clear();
        }


        private void CargarComboProveedor()
        {
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DataSource = Proveedores.GetTodos();          
        }

        private void CargarComboSucursal()
        {
            cmbSucursal.DisplayMember = "sucnombre";
            cmbSucursal.ValueMember = "sucid";
            cmbSucursal.DataSource = Sucursales.GetTodos();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            dlgProducto dlg = new dlgProducto(Convert.ToInt32(cmbProveedor.SelectedValue));
            dlg.Text = "PRODUCTOS - LISTADO DE PRODUCTOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.prdid != 0)
            {
                txtIdProducto.Text = dlg.prdid.ToString();
                txtCodigo.Text = dlg.prdcodigo.ToString();

            }
        }




        private void ObtenerProducto(int prdid)
        {
            Producto producto = Productos.GetPorId(prdid);

            if (producto != null)
            {
                if (producto.proveedor.proid == Convert.ToInt32(cmbProveedor.SelectedValue))
                {
                    txtDescripcion.Text = producto.prddenominacion;                   
                }
            }
            else
            {

                errorProvider.SetError(txtDescripcion, "El producto no existe registrado en el sistema.");
            }
        }

        private void txtIdProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtIdProducto.Text != string.Empty)
            {
                ObtenerProducto(Convert.ToInt32(txtIdProducto.Text));
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (!string.IsNullOrEmpty(txtIdProducto.Text) && !string.IsNullOrEmpty(txtCantidad.Text))
            {
                if (!string.IsNullOrEmpty(txtCantidad.Text))
                {
                    dgvServices.Rows.Add(Convert.ToInt32(txtIdProducto.Text), txtCodigo.Text, txtDescripcion.Text, Convert.ToInt32(txtCantidad.Text));

                    LimpiarControles();
                }
                else
                {
                    errorProvider.SetError(btnBuscarProducto, "Debe indicar una cantidad.");
                }
            }
            else
            {
                errorProvider.SetError(btnBuscarProducto, "Debe seleccionar un producto.");
            }
        }

        private void LimpiarControles()
        {
            txtCodigo.Text = string.Empty;
            txtIdProducto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCantidad.Text = string.Empty;
        }


        private Boolean ValidarFormulario()
        {
            bool resultado = true;
            errorProvider.Clear();

            if (string.IsNullOrEmpty(txtRemito.Text))
            {
                resultado = false;
                errorProvider.SetError(txtRemito, "Debe indicar el número de remito de compra.");
            }

            if(string.IsNullOrEmpty(txtIdCliente.Text))
            {
                resultado = false;
                errorProvider.SetError(btnBuscarCliente, "Debe seleccionar un usuario.");
            }

            if(string.IsNullOrEmpty(txtObservacion.Text))
            {
                resultado = false;
                errorProvider.SetError(groupBox3, "Debe indicar el motivo del pedido de service.");
            }

            if(dgvServices.Rows.Count <= 0)
            {
                resultado = false;
                errorProvider.SetError(btnBuscarProducto, "Debe seleccionar un producto.");
            }

            return resultado;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            dlgCliente dlg = new dlgCliente();
            dlg.Text = "CLIENTES - LISTADO DE CLIENTES REGISTRADOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.cliid != 0)
            {
                txtIdCliente.Text = dlg.cliid.ToString();
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            dlgCliente dlg = new dlgCliente();
            dlg.Text = "CLIENTES - LISTADO DE CLIENTES REGISTRADOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.cliid != 0)
            {
                txtIdCliente.Text = dlg.cliid.ToString();

            }
        }

        private void BuscarCliente(int cliid)
        {
            errorProvider.Clear();

            Cliente cliente = new Cliente();
            cliente.cliid = cliid;
            cliente = Clientes.GetPorId(cliente);
            if (cliente != null)
            {
                txtIdCliente.Text = cliente.cliid.ToString();
                txtRazonSocial.Text = cliente.clinombre;
                txtDocumento.Text = cliente.clidocumento;
                txtCalle.Text = cliente.clicalle;
                txtNumero.Text = cliente.clinumero;
                txtTipoCliente.Text = cliente.tipoiva.tpitipo;
                txtBarrio.Text = cliente.clibarrio;
                txtCiudad.Text = cliente.ciudad.ciunombre;
                txtCodigoCliente.Text = cliente.clicodigo;
            }
            else
            {
                LimpiarControlesCliente();
                errorProvider.SetError(btnBuscarCliente, "El cliente no se encuentra registrado.");
            }
        }

        //PENDIENTE
        private void LimpiarControlesCliente()
        {

        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtIdCliente.Text))
            {
                BuscarCliente(Convert.ToInt32(txtIdCliente.Text));
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario() == true)
            {
                 DialogResult result = MessageBox.Show("Se va a generar una solicitud de service, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (result == System.Windows.Forms.DialogResult.Yes)
                 {
                     detalle.Clear();
                     foreach (DataGridViewRow fila in dgvServices.Rows)
                     {
                         ServiceDetalle det = new ServiceDetalle();
                         det.prdid = Convert.ToInt32(fila.Cells[0].Value);
                         det.sdecantidad = Convert.ToInt32(fila.Cells[3].Value);
                         det.sdemotivo = txtObservacion.Text;
                         detalle.Add(det);
                     }

                     Service service = new Service();
                     Cliente cliente = new Cliente();
                     Proveedor proveedor = new Proveedor();
                     Sucursal sucursal = new Sucursal(); 

                     cliente.cliid = Convert.ToInt32(txtIdCliente.Text);
                     proveedor.proid = Convert.ToInt32(cmbProveedor.SelectedValue);
                     sucursal.sucid = Convert.ToInt32(cmbSucursal.SelectedValue);

                     service.cliente = cliente; 
                     service.essid = 1;
                     service.proveedor = proveedor;
                     service.serfecha = dtpFechaService.Value;
                     service.serfechacompra = dtpFechaCompra.Value;
                     service.serremito = txtRemito.Text;
                     service.sucursal = sucursal;
                     service.serfotocopiafactura = "NO";
                     service.serfotocopiaremito = "NO";
                     service.serfajagarantia = "NO";
                     service.sercertfabricacion = "NO";
                     service.detalle = detalle;

                     for (int i = 0; i < ckbDocumentacion.Items.Count; i++)
                     {
                         if (ckbDocumentacion.GetItemChecked(i))
                         {
                             switch (i)
                             {
                                 case 0:
                                     service.serfotocopiafactura = "SI";
                                     break;
                                 case 1:
                                     service.serfotocopiaremito = "SI";
                                     break;
                                 case 2:
                                     service.serfajagarantia = "SI";
                                     break;
                                 case 3:
                                     service.sercertfabricacion = "SI";
                                     break;
                             }
                         }
                     }

                     try
                     {
                         int resultado = Services.Add(service);
                         if (resultado > 0)
                         {
                             MessageBox.Show("Ser registro correctamente el Service.");
                             LimpiarControlesGenerales();
                             LimpiarControlesCliente();

                              DialogResult dialog = MessageBox.Show("Imprimir la Solicitud de Service?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                              if (dialog == System.Windows.Forms.DialogResult.Yes)
                              {

                                  //IMPRIMIR REPORTE

                              }

                         }
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show(ex.Message);
                     }

                 }
            }
        }

        private void btnBuscarCliente_Click_1(object sender, EventArgs e)
        {
            dlgCliente dlg = new dlgCliente();
            dlg.Text = "CLIENTES - LISTADO DE CLIENTES REGISTRADOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && dlg.cliid != 0)
            {
                txtIdCliente.Text = dlg.cliid.ToString();

            }
        }

        private void txtIdCliente_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdCliente.Text))
            {
                BuscarCliente(Convert.ToInt32(txtIdCliente.Text));
            }
        }

        private void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServices.Rows.Count > 0)
            {
                if (dgvServices.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    int fila = dgvServices.CurrentRow.Index;
                    dgvServices.Rows.RemoveAt(fila);
                }
            }
        }

        private void LimpiarControlesGenerales()
        {
            cmbProveedor.SelectedIndex = 0;
            cmbSucursal.SelectedIndex = 0;
            txtRemito.Text = string.Empty;
            dtpFechaCompra.Value = DateTime.Today.Date;
            dtpFechaService.Value = DateTime.Today.Date;
            txtObservacion.Text = string.Empty;

            foreach(int i in ckbDocumentacion.CheckedIndices)
            {
                ckbDocumentacion.SetItemCheckState(i, CheckState.Unchecked);
            }

            dgvServices.Rows.Clear();

        }

    }
}
