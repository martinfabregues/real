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
    public partial class frmDetalleVenta : Form
    {
        private Remito remito;
        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            cmbTipoComprobante.Enabled = false;
            txtNumeroFactura.Enabled = false;
            txtNumeroRemito.Enabled = false;
            txtRazonSocial.Enabled = false;
            txtCalle.Enabled = false;
            txtDocumento.Enabled = false;
            txtNumero.Enabled = false;
            txtTipoCliente.Enabled = false;
            txtBarrio.Enabled = false;
            txtCiudad.Enabled = false;
            
        }


        public frmDetalleVenta(Remito rem)
        {
            remito = rem;
            InitializeComponent();
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            IniciarControles();
            CargarComboComprobante();
            ObtenerDatos(remito);
        }

        private void ObtenerDatos(Remito remito)
        {
            remito = Remitos.GetPorId(remito.remito_id);

            if (remito != null)
            {
                cmbTipoComprobante.Text = remito.tipocomprobante.tipocomprobante_denominacion;
                txtNumeroRemito.Text = remito.remito_numero;
                txtNumeroFactura.Text = remito.remito_numerofactura;
                txtRazonSocial.Text = remito.cliente.clinombre;
                txtCalle.Text = remito.cliente.clicalle;
                txtDocumento.Text = remito.cliente.clidocumento;
                txtTipoCliente.Text = remito.cliente.tipoiva.tpitipo;
                txtNumero.Text = remito.cliente.clinumero;
                txtBarrio.Text = remito.cliente.clibarrio;
                txtCiudad.Text = remito.cliente.ciudad.ciunombre;
                
                lblImporte.Text = " $ " + remito.remito_importe.ToString();

                dgvDetalle.Rows.Clear();
                foreach (RemitoDetalle detalle in remito.detalle)
                {
                    dgvDetalle.Rows.Add(detalle.producto.prdcodigo, detalle.producto.prddenominacion, detalle.remitodetalle_importeunitario, detalle.remitodetalle_cantidad, (detalle.remitodetalle_importeunitario * detalle.remitodetalle_cantidad));
                }

                dgvPagos.Rows.Clear();
                foreach (CobroRemitoContado cobrocontado in remito.cobrocontado)
                {
                    dgvPagos.Rows.Add("CONTADO", "", "", cobrocontado.cobroremito_importe);
                }

                foreach (CobroRemitoCredito cobrocredito in remito.cobrocredito)
                {
                    dgvPagos.Rows.Add("CREDITO", cobrocredito.plan.tarjetacredito.tarnombre, cobrocredito.plan.plan_denominacion, cobrocredito.cobroremito_importe);
                }

            }
        }

        private void CargarComboComprobante()
        {
            cmbTipoComprobante.ValueMember = "tipocomprobante_id";
            cmbTipoComprobante.DisplayMember = "tipocomprobante_denominacion";
            cmbTipoComprobante.DataSource = TiposComprobante.GetTodos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
     
    }
}
