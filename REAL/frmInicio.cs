using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmInicio : Form
    {
        public string usunombre { get; set; }
        public frmInicio(String uN)
        {
            usunombre = uN;
            InitializeComponent();
        }

        private void btnNuevaEntrega_Click(object sender, EventArgs e)
        {
            frmEntrega frm = new frmEntrega();
            frm.MdiParent = this;
            frm.Text = "Logística - Nueva Entrega";
            frm.Show();
        }

        private void btnAnularEntrega_Click(object sender, EventArgs e)
        {
            frmAnularEntrega frm = new frmAnularEntrega();
            frm.MdiParent = this;
            frm.Text = "Logística - Anular Entrega";
            frm.Show();
        }

        private void btnRecepcionEntrega_Click(object sender, EventArgs e)
        {
            frmNuevaRecepcion frm = new frmNuevaRecepcion();
            frm.MdiParent = this;
            frm.Text = "Logística - Registrar Recepción";
            frm.Show();
        }

        private void btnAdministrarEntregas_Click(object sender, EventArgs e)
        {
            frmAdministrarEntregas frm = new frmAdministrarEntregas();
            frm.MdiParent = this;
            frm.Text = "Logística - Administrar Entregas";
            frm.Show();
        }

        private void btnConsultarEntregas_Click(object sender, EventArgs e)
        {
            frmConsultarEntregas frm = new frmConsultarEntregas();
            frm.MdiParent = this;
            frm.Text = "Logística - Consultar Entregas";
            frm.Show();
        }

        private void btnEntregasCosto_Click(object sender, EventArgs e)
        {
            frmEntregasConCosto frm = new frmEntregasConCosto();
            frm.MdiParent = this;
            frm.Text = "Logística - Entregas con Costo";
            frm.Show();
        }

        private void btnBarriosRegistrados_Click(object sender, EventArgs e)
        {
            frmConsultaBarrio frm = new frmConsultaBarrio();
            frm.MdiParent = this;
            frm.Text = "Logística - Barrios Registrados";
            frm.Show();
        }

        private void btnReporteEntregas_Click(object sender, EventArgs e)
        {
            frmFiltro frm = new frmFiltro();
            frm.MdiParent = this;
            frm.Text = "Reportes - Filtros de Entrega";
            frm.Show();
        }

        private void btnReporteDiario_Click(object sender, EventArgs e)
        {
            frmReporteDiario frm = new frmReporteDiario();
            frm.MdiParent = this;
            frm.Text = "Logística - Reporte de Entregas Diario";
            frm.Show();

            frmRecepcionEntrega frmRecepcion = new frmRecepcionEntrega();
            frmRecepcion.MdiParent = this;
            frmRecepcion.Text = "Logística - Reporte de Recepción de Entregas";
            frmRecepcion.Show();
        }

        private void btnMapa_Click(object sender, EventArgs e)
        {
            frmMapa frm = new frmMapa();
            frm.MdiParent = this;
            frm.Text = "Logística - Mapa";
            frm.Show();
        }

        private void btnNuevaCiudad_Click(object sender, EventArgs e)
        {
            frmNuevaCiudad frm = new frmNuevaCiudad();
            frm.MdiParent = this;
            frm.Text = "Logística - Nueva Ciudad";
            frm.Show();
        }

        private void btnNuevaProvincia_Click(object sender, EventArgs e)
        {
            frmNuevaProvincia frm = new frmNuevaProvincia();
            frm.MdiParent = this;
            frm.Text = "Logística - Nueva Provincia";
            frm.Show();
        }

        private void btnNuevoBarrio_Click(object sender, EventArgs e)
        {
            frmNuevoBarrio frm = new frmNuevoBarrio();
            frm.MdiParent = this;
            frm.Text = "Logística - Nuevo Barrio";
            frm.Show();
        }

        private void btnEstadisticaGeneral_Click(object sender, EventArgs e)
        {
            frmEstadisticaGeneral frm = new frmEstadisticaGeneral();
            frm.MdiParent = this;
            frm.Text = "Logística - Estadística General Mensual";
            frm.Show();
        }

        private void btnEstadisticaAnual_Click(object sender, EventArgs e)
        {
            frmEstadisticaAnual frm = new frmEstadisticaAnual();
            frm.MdiParent = this;
            frm.Text = "Logística - Estadística General Anual";
            frm.Show();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            frmNuevoProducto frm = new frmNuevoProducto("ALTA");
            frm.MdiParent = this;
            frm.Text = "Producto - Registrar Producto";
            frm.Show();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
           

            Size desktop = new Size();
            desktop = System.Windows.Forms.SystemInformation.PrimaryMonitorSize;
            int alto = desktop.Height;
            int ancho = desktop.Width;

            lblUsuario.Text = usunombre;

            if (ancho == 1280)
            {
                this.BackgroundImage = new Bitmap(Properties.Resources.fondo_03);
            }
            if (ancho == 1024)
            {
                this.BackgroundImage = new Bitmap(Properties.Resources.fondosisazul);
            }
            if (ancho == 1366)
            {
                //this.BackgroundImage = new Bitmap(Properties.Resources.fondosis1366);
            }

            //btnCliente.Enabled = false;
            //btnModificarProveedor.Enabled = false;
            btnRecepcionEntrega.Enabled = false;
            //btnListadoProveedor.Enabled = false;
            //btnModificarOrdenCompra.Enabled = false;
            //btnAnularOrdenCompra.Enabled = false;
            //btnModificarIngresoProveedor.Enabled = false;

            //_toolbar.Visible = false;
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            frmNuevoProveedor frm = new frmNuevoProveedor("NUEVO");
            frm.MdiParent = this;
            frm.Text = "Proveedor - Registrar Proveedor";
            frm.Show();
        }

        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            frmNuevaMarca frm = new frmNuevaMarca();
            frm.MdiParent = this;
            frm.Text = "Marca - Nueva Marca";
            frm.Show();
        }

        private void btnNuevaOrdenCompra_Click(object sender, EventArgs e)
        {
            frmNuevaOrdenCompra frm = new frmNuevaOrdenCompra("NUEVO");
            frm.MdiParent = this;
            frm.Text = "Compras - Nueva Orden de Compra";
            frm.Show();
        }

        private void btnListadoOrdendeCompra_Click(object sender, EventArgs e)
        {
            
        }

        private void btnIngresoProveedor_Click(object sender, EventArgs e)
        {
            //frmIngresoProveedor frm = new frmIngresoProveedor("NUEVO");
            //frm.MdiParent = this;
            //frm.Text = "COMPRAS - INGRESO DE COMPROBANTE";
            //frm.Show();
        }

        private void btnListadoPendientesEntrega_Click(object sender, EventArgs e)
        {
            frmConsultaPendientes frm = new frmConsultaPendientes();
            frm.MdiParent = this;
            frm.Text = "Compras - Pendientes de Entrega ";
            frm.Show();
        }

        private void btnReportePendientesEntrega_Click(object sender, EventArgs e)
        {
            frmFiltroReportePendientesEntrega frm = new frmFiltroReportePendientesEntrega();
            frm.MdiParent = this;
            frm.Text = "Reporte - Filtro Pendientes de Entrega";
            frm.Show();
        }

        private void btnListadoProducto_Click(object sender, EventArgs e)
        {
            frmConsultaProductos frm = new frmConsultaProductos();
            frm.MdiParent = this;
            frm.Text = "Productos - Productos Registrados";
            frm.Show();
        }

        private void btnListadoOrdenCompra_Click(object sender, EventArgs e)
        {
            frmConsultaOrdendeCompra frm = new frmConsultaOrdendeCompra();
            frm.MdiParent = this;
            frm.Text = "Compras - Listado de Ordenes de Compra";
            frm.Show();
        }

        private void frmInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Va a cerrar el Sistema, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;

                try
                {
                    Process proc = Process.GetCurrentProcess();
                    proc.Kill();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            frmNuevoProducto frm = new frmNuevoProducto("MODIFICAR");
            frm.MdiParent = this;
            frm.Text = "Producto - Modificar Producto";
            frm.Show();
        }

        private void btnReporteProductos_Click(object sender, EventArgs e)
        {
            frmFiltroReporteProducto frm = new frmFiltroReporteProducto();
            frm.MdiParent = this;
            frm.Text = "Producto - Filtro Reporte Producto";
            frm.Show();
        }

        private void btnModificarOrdenCompra_Click(object sender, EventArgs e)
        {
            //frmNuevaOrdenCompra frm = new frmNuevaOrdenCompra("MODIFICAR");
            //frm.MdiParent = this;
            //frm.Text = "COMPRAS - MODIFICAR ORDEN DE COMPRA";
            //frm.Show();
        }

        private void btnConsultaIngresoProveedor_Click(object sender, EventArgs e)
        {
            frmConsultaIngresoProveedor frm = new frmConsultaIngresoProveedor();
            frm.MdiParent = this;
            frm.Text = "Compras - Listado de Ingresos de Proveedor";
            frm.Show();
        }

        private void btnModificarIngresoProveedor_Click(object sender, EventArgs e)
        {
            //frmIngresoProveedor frm = new frmIngresoProveedor("MODIFICAR");
            //frm.MdiParent = this;
            //frm.Text = "COMPRAS - MODIFICAR INGRESO DE COMPROBANTE";
            //frm.Show();
        }

        private void btnListadoProveedor_Click(object sender, EventArgs e)
        {
            frmConsultaProveedor frm = new frmConsultaProveedor();
            frm.MdiParent = this;
            frm.Text = "Proveedores - Proveedores Registrados";
            frm.Show();
        }

        private void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            frmNuevoProveedor frm = new frmNuevoProveedor("MODIFICAR");
            frm.MdiParent = this;
            frm.Text = "Proveedor - Modificar Proveedor";
            frm.Show();
        }

        private void btnReporteIngresos_Click(object sender, EventArgs e)
        {
            frmReporteIngresos frm = new frmReporteIngresos();
            frm.MdiParent = this;
            frm.Text = "Reportes - Reporte de Ingresos";
            frm.Show();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmNuevoCliente frm = new frmNuevoCliente("NUEVO");
            frm.MdiParent = this;
            frm.Text = "CLIENTE - REGISTRO DE NUEVO CLIENTE";
            frm.Show();
        }

        private void btnGenerarRemito_Click(object sender, EventArgs e)
        {
            frmNuevoRemito frm = new frmNuevoRemito("NUEVO");
            frm.MdiParent = this;
            frm.Text = "VENTAS - GENERAR REMITO";
            frm.Show();
        }

        private void btnNuevaBonificacion_Click(object sender, EventArgs e)
        {
            frmNuevaBonificacion frm = new frmNuevaBonificacion("NUEVO");
            //frm.MdiParent = this;
            frm.Text = "PROVEEDOR - NUEVA BONIFICACIÓN";
            frm.ShowDialog();
        }

        private void btnAsociarProductos_Click(object sender, EventArgs e)
        {
            frmBonificacionProducto frm = new frmBonificacionProducto();
            frm.Text = "BONIFICACIÓN - ASOCIAR PRODUCTOS";
            frm.ShowDialog();
        }

        private void btnModificarBonificacion_Click(object sender, EventArgs e)
        {
            frmNuevaBonificacion frm = new frmNuevaBonificacion("MODIFICAR");
            //frm.MdiParent = this;
            frm.Text = "PROVEEDOR - MODIFICAR BONIFICACIÓN";
            frm.ShowDialog();
        }

        private void btnBonificacionesRegistradas_Click(object sender, EventArgs e)
        {
            frmConsultaBonificacionesRegistradas frm = new frmConsultaBonificacionesRegistradas();
            frm.MdiParent = this;
            frm.Text = "BONIFICACIONES - BONIFICACIONES REGISTRADAS";
            frm.Show();
        }

        private void btnNuevaLista_Click(object sender, EventArgs e)
        {
            frmListaPrecio frm = new frmListaPrecio("NUEVO");
            frm.MdiParent = this;
            frm.Text = "PROVEEDOR - NUEVA LISTA DE PRECIO";
            frm.Show();
        }

        private void btnListasRegistradasConsulta_Click(object sender, EventArgs e)
        {
            frmListasPrecioConsulta frm = new frmListasPrecioConsulta();
            frm.MdiParent = this;
            frm.Text = "PROVEEDOR - LISTAS DE PRECIO REGISTRADAS";
            frm.Show();
        }

        private void btnNuevaTarjeta_Click(object sender, EventArgs e)
        {
            frmNuevaTarjetaCredito frm = new frmNuevaTarjetaCredito();
            frm.MdiParent = this;
            frm.Text = "FORMAS DE PAGO - REGISTRAR TARJETA DE CREDITO";
            frm.Show();
        }

        private void btnRegistrarPlan_Click(object sender, EventArgs e)
        {
            frmNuevoPlan frm = new frmNuevoPlan("NUEVO");
            frm.MdiParent = this;
            frm.Text = "FORMAS DE PAGO - REGISTRAR PLAN";
            frm.Show();
        }

        private void btnAltaVendedor_Click(object sender, EventArgs e)
        {
            frmNuevoVendedor frm = new frmNuevoVendedor("NUEVO");
            frm.MdiParent = this;
            frm.Text = "ADMINISTRACIÓN - ALTA DE VENDEDOR";
            frm.Show();
        }

        private void btnVendedoresConsulta_Click(object sender, EventArgs e)
        {
            frmVendedorConsulta frm = new frmVendedorConsulta();
            frm.MdiParent = this;
            frm.Text = "ADMINISTRACIÓN - VENDEDORES REGISTRADOS";
            frm.Show();
        }

        private void btnVendedorModificar_Click(object sender, EventArgs e)
        {
            frmNuevoVendedor frm = new frmNuevoVendedor("MODIFICAR");
            frm.MdiParent = this;
            frm.Text = "ADMINISTRACIÓN - MODIFICAR VENDEDOR";
            frm.Show();
        }

        private void btnModificarPlan_Click(object sender, EventArgs e)
        {
            frmNuevoPlan frm = new frmNuevoPlan("MODIFICAR");
            frm.MdiParent = this;
            frm.Text = "FORMAS DE PAGO - MODIFICAR PLAN";
            frm.Show();
        }

        private void btnModificarRemito_Click(object sender, EventArgs e)
        {
            frmNuevoRemito frm = new frmNuevoRemito("MODIFICAR");
            frm.MdiParent = this;
            frm.Text = "VENTAS - GENERAR REMITO";
            frm.Show();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRemitoPrueba frm = new frmRemitoPrueba();
            
            frm.ShowDialog();
        }

        private void btnVentasMargenGanancia_Click(object sender, EventArgs e)
        {
           
        }

        private void modificarListaPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaPrecio frm = new frmListaPrecio("MODIFICAR");
            frm.MdiParent = this;
            frm.Text = "PROVEEDOR - MODIFICAR LISTA DE PRECIO";
            frm.Show();
        }

        private void ventasRegistradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentasRegistradas frm = new frmVentasRegistradas();
            frm.MdiParent = this;
            frm.Text = "VENTAS - VENTAS REGISTRADAS";
            frm.Show();
        }

        private void modificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevoCliente frm = new frmNuevoCliente("MODIFICAR");
            frm.MdiParent = this;
            frm.Text = "CLIENTES - MODIFICAR CLIENTES REGISTRADOS";
            frm.Show();
        }

        private void clientesRegistradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClienteConsulta frm = new frmClienteConsulta();
            frm.MdiParent = this;
            frm.Text = "CLIENTES - CLIENTES REGISTRADOS";
            frm.Show();
        }

        private void tarjetasRegistradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTarjetasCreditoRegistradas frm = new frmTarjetasCreditoRegistradas();
            frm.MdiParent = this;
            frm.Text = "FORMAS DE PAGO - TARJETAS DE CREDITO REGISTRADAS";
            frm.Show();
        }

        private void planesRegistradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlanesRegistrados frm = new frmPlanesRegistrados();
            frm.MdiParent = this;
            frm.Text = "FORMAS DE PAGO - PLANES REGISTRADOS";
            frm.Show();
        }

        private void pruebaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPrueba frm = new frmPrueba();
            frm.Show();
        }

        private void pendientesRegistradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaPendientes frm = new frmConsultaPendientes();
            frm.MdiParent = this;
            frm.Text = "Compras - Pendientes de Entrega";
            frm.Show();
        }

        private void pendientesRegistradosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFiltroReportePendientesEntrega frm = new frmFiltroReportePendientesEntrega();
            frm.MdiParent = this;
            frm.Text = "REPORTE PENDIENTES DE ENTREGA - FILTRO";
            frm.Show();
        }

        private void ajustarPendienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPendientesEliminar frm = new frmPendientesEliminar();
            frm.MdiParent = this;
            frm.Text = "Compras - Ajustar Productos Pendientes de Entrega";
            frm.Show();
        }

        private void modificarPreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPreciosActualizacion frm = new frmPreciosActualizacion();
            frm.MdiParent = this;
            frm.Text = "LISTA DE PRECIOS - ACTUALIZAR PRECIOS";
            frm.Show();
        }

        private void registrarServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmService frm = new frmService();
            frm.MdiParent = this;
            frm.Text = "REGISTRO DE NUEVO SERVICE";
            frm.Show();
        }

        private void nuevaAutorizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAutorizacionService frm = new frmAutorizacionService();
            frm.MdiParent = this;
            frm.Text = "SERVICES - AUTORIZACIONES";
            frm.Show();
        }

        private void generarDevoluciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevaDevolucion frm = new frmNuevaDevolucion();
            frm.MdiParent = this;
            frm.Text = "SERVICE - GENERAR DEVOLUCIÓN";
            frm.Show();
        }

        private void aBMOrdenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdenCompraABM frm = new frmOrdenCompraABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                frmOrdenCompraABM frm = new frmOrdenCompraABM();
                frm.MdiParent = this;
                frm.Show();
            }

            if (e.KeyCode == Keys.F3)
            {
                frmProductosABM frm = new frmProductosABM();
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void testRibbonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmPrincipal frm = new frmPrincipal();
            //frm.Show();
        }

        private void pruebaToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            frmOrdenCompraABM frm = new frmOrdenCompraABM();
            frm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmProductosABM frm = new frmProductosABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmOrdenCompraABM frm = new frmOrdenCompraABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            frmIngresoComprobantes frm = new frmIngresoComprobantes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ordenesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdenCompraABM frm = new frmOrdenCompraABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void administrarOrdenesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdenCompraABM frm = new frmOrdenCompraABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarRemitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRemito frm = new frmRemito();
            frm.MdiParent = this;
            frm.Show();
        }

        private void remitosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void registrarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngresoProveedor frm = new frmIngresoProveedor();
            frm.MdiParent = this;
            frm.Text = "Compras - Registrar Factura de Compra";
            frm.Show();
        }

        private void registrarRemitoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRemito frm = new frmRemito();
            frm.MdiParent = this;
            frm.Text = "Compras - Registrar Remito de Compra";
            frm.Show();
        }

        private void btnAnularOrdenCompra_Click(object sender, EventArgs e)
        {

        }

        private void migrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int resultado = FacturasProveedor.MigrarFacturas();
            if(resultado > 0)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void facturasRegistradsaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturasProveedorConsulta frm = new frmFacturasProveedorConsulta();
            frm.MdiParent = this;
            frm.Text = "Compras - Listado de Facturas de Compra Registradas";
            frm.Show();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaIngresoProveedor frm = new frmConsultaIngresoProveedor();
            frm.MdiParent = this;
            frm.Text = "Compras - Listado de Ingresos de Proveedor";
            frm.Show();
        }

     


      
    }
}
