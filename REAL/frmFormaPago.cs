using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmFormaPago : Form
    {
        public double remito_importe { get; set; }
        public List<CobroRemitoContado> listacontado = new List<CobroRemitoContado>();
        public List<CobroRemitoCredito> listacredito = new List<CobroRemitoCredito>();
        private string movimiento;
        private int remito_id;
        public frmFormaPago()
        {
            InitializeComponent();
        }

        public frmFormaPago(int rem_id)
        {
            remito_id = rem_id;
            movimiento = "MODIFICAR";
            InitializeComponent();
        }

        public frmFormaPago(double rem_importe)
        {
            remito_importe = rem_importe;
            movimiento = "NUEVO";
            InitializeComponent();
        }

        private void IniciarControles()
        {
            cmbFormaPago.SelectedIndex = 0;
            cmbTarjeta.SelectedIndex = 0;
            txtImporte.Text = string.Empty;

        }


        private void CalcularTotales()
        {

            lblImporte.Text = remito_importe.ToString();
            lblSaldo.Text = (Convert.ToDouble(lblImporte.Text) - Convert.ToDouble(lblTotalCobro.Text)).ToString();

        }


        private void ObtenerPagosRemito()
        {
            Remito remito = new Remito();
            remito = Remitos.GetPorId(remito_id);
            if (remito != null)
            {
                remito_importe = remito.remito_importe;
                CargarCobros(remito.cobrocontado, remito.cobrocredito);
            }
        }

        private void CargarCobros(List<CobroRemitoContado> cobrocontado, List<CobroRemitoCredito> cobrocredito)
        {
            dgvCobroRemito.Rows.Clear();
            foreach (CobroRemitoContado filacontado in cobrocontado)
            {
                dgvCobroRemito.Rows.Add(filacontado.cobroremito_id, 0, "CONTADO", "", "", "", "", filacontado.cobroremito_importe);
            }

            foreach (CobroRemitoCredito filacredito in cobrocredito)
            {
                dgvCobroRemito.Rows.Add(filacredito.cobroremito_id, 0, "CREDITO", filacredito.plan.tarjetacredito.tarid, filacredito.plan.tarjetacredito.tarnombre, filacredito.plan.plan_id, filacredito.plan.plan_denominacion, filacredito.cobroremito_importe);
            }

        }

        private void CalcularTotal()
        {
            double total = 0;
            foreach (DataGridViewRow dr in dgvCobroRemito.Rows)
            {
                total = total + Convert.ToDouble(dr.Cells["cobroremito_importe"].Value);

            }


            lblTotalCobro.Text = total.ToString();
        }

        private void frmFormaPago_Load(object sender, EventArgs e)
        {
            CargarComboFormaPago();
            if (movimiento == "MODIFICAR")
            {
                ObtenerPagosRemito();
            }
            
            CalcularTotal();
            CalcularTotales();
            
        }


        private void CargarComboTarjeta()
        {
            cmbTarjeta.ValueMember = "tarid";
            cmbTarjeta.DisplayMember = "tarnombre";
            cmbTarjeta.DataSource = TarjetasCredito.GetTodos();
        }

        private void CargarComboFormaPago()
        {
            cmbFormaPago.ValueMember = "fpaid";
            cmbFormaPago.DisplayMember = "fpaforma";
            cmbFormaPago.DataSource = FormasPago.GetTodos();
        }

        private void CargarComboPlan(int tarjetacredito_id)
        {
            cmbPlan.ValueMember = "plan_id";
            cmbPlan.DisplayMember = "plan_denominacion";
            cmbPlan.DataSource = Planes.GetTodoPorIdTarjeta(tarjetacredito_id);
        }

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTarjeta.SelectedIndex > -1)
            {
                TarjetaCredito tarjetacredito = (TarjetaCredito)cmbTarjeta.SelectedItem;
                CargarComboPlan(tarjetacredito.tarid);
            }
        }


        private Boolean ValidarControles()
        {
            bool resultado = true;
            errorProvider1.Clear();

            if(string.IsNullOrEmpty(txtImporte.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtImporte, "El campo importe no puede ser vacio.");
            }
            if ((TarjetaCredito)cmbTarjeta.SelectedItem == null && cmbFormaPago.Text == "CREDITO")
            {
                resultado = false;
                errorProvider1.SetError(cmbTarjeta, "Debe seleccionar una tarjeta de credito.");
            }
            if ((Plan)cmbPlan.SelectedItem == null && cmbFormaPago.Text == "CREDITO")
            {
                resultado = false;
                errorProvider1.SetError(cmbPlan, "Debe seleccionar un plan.");
            }
            if (Convert.ToDouble(txtImporte.Text) > Convert.ToDouble(lblSaldo.Text))
            {
                resultado = false;
                errorProvider1.SetError(txtImporte, "El importe no puede ser mayor al saldo.");
            }

            return resultado;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarControles() == true)
            {
                dgvCobroRemito.Rows.Add(0, cmbFormaPago.SelectedValue, cmbFormaPago.Text, cmbTarjeta.SelectedValue, cmbTarjeta.Text, cmbPlan.SelectedValue, cmbPlan.Text, Convert.ToDouble(txtImporte.Text));
                LimpiarControles();
            }

            CalcularTotal();
            CalcularTotales();
        }

        private void LimpiarControles()
        {
            cmbTarjeta.DataSource = null;
            cmbFormaPago.SelectedIndex = 0;
            txtImporte.Text = string.Empty;
        }

        private void dgvCobroRemito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCobroRemito.Rows.Count > 0)
            {
                if (dgvCobroRemito.Columns[e.ColumnIndex].Name == "eliminar" && movimiento != "MODIFICAR")
                {
                    int fila = dgvCobroRemito.CurrentRow.Index;
                    dgvCobroRemito.Rows.RemoveAt(fila);
                    CalcularTotal();
                    CalcularTotales();
                }
                else
                {
                    if (dgvCobroRemito.Columns[e.ColumnIndex].Name == "eliminar")
                    {
                        DialogResult result = MessageBox.Show("Se va a eliminar el registro del cobro, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            //ELIMINAR COBRO DE LA BASE
                            int i = dgvCobroRemito.CurrentRow.Index;
                            DataGridViewRow fila = dgvCobroRemito.CurrentRow;
                           
                            if (fila.Cells["formapago"].Value.ToString() == "CONTADO")
                            {
                                bool resultado = Remitos.EliminarCobroContado(Convert.ToInt32(fila.Cells["cobroremito_id"].Value));
                                if (resultado == true)
                                {
                                    MessageBox.Show("El cobro se elimino con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvCobroRemito.Rows.RemoveAt(i);
                                }
                            }
                            else
                            {
                                bool resultado = Remitos.EliminarCobroCredito(Convert.ToInt32(fila.Cells["cobroremito_id"].Value));
                                if (resultado == true)
                                {
                                    MessageBox.Show("El cobro se elimino con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvCobroRemito.Rows.RemoveAt(i);
                                }
                            }

                            CalcularTotal();
                            CalcularTotales();
                        }
                    }
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvCobroRemito.Rows.Count > 0 && Convert.ToDouble(lblSaldo.Text) == 0)
            {
                listacontado.Clear();
                listacredito.Clear();

                foreach (DataGridViewRow fila in dgvCobroRemito.Rows)
                {
                    if (fila.Cells["formapago"].Value.ToString() == "CONTADO")
                    {
                        CobroRemitoContado cobrocontado = new CobroRemitoContado();
                        cobrocontado.cobroremito_id = Convert.ToInt32(fila.Cells["cobroremito_id"].Value);
                        cobrocontado.cobroremito_importe = Convert.ToDouble(fila.Cells["cobroremito_importe"].Value);                        
                        listacontado.Add(cobrocontado);
                    }
                    else
                    {
                        CobroRemitoCredito cobrocredito = new CobroRemitoCredito();
                        cobrocredito.plan = new Plan();
                        cobrocredito.plan.tarjetacredito = new TarjetaCredito();

                        cobrocredito.cobroremito_id = Convert.ToInt32(fila.Cells["cobroremito_id"].Value);
                        cobrocredito.cobroremito_importe = Convert.ToDouble(fila.Cells["cobroremito_importe"].Value);
                        cobrocredito.plan.plan_id = Convert.ToInt32(fila.Cells["plan_id"].Value);
                        cobrocredito.plan.plan_denominacion = fila.Cells["plan_denominacion"].Value.ToString();
                        cobrocredito.plan.tarjetacredito.tarnombre = fila.Cells["tarjetacredito_denominacion"].Value.ToString() ;
                        listacredito.Add(cobrocredito);
                    }
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            else
            {
                
                errorProvider1.SetError(btnAgregar, "Hay errores en la carga de los datos");
                
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || char.IsControl(e.KeyChar)
                )
            {

                e.Handled = false;
            }

            else
            {
                errorProvider1.SetError(txtImporte, "Solo se permiten números en el campo importe.");
                e.Handled = true;
            }
        }

        private void frmFormaPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvCobroRemito.Rows.Count == 0 && Convert.ToInt32(lblSaldo.Text) != 0)
            {
                errorProvider1.SetError(btnAceptar, "Debe revisar los datos.");
            }
        }

        private void cmbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FormaPago formapago = (FormaPago)cmbFormaPago.SelectedItem;
            if (formapago.fpaforma == "CREDITO")
            {
                CargarComboTarjeta();
            }
            else
            {

                cmbPlan.DataSource = null;
                cmbTarjeta.DataSource = null;
            }
        }


    }
}
