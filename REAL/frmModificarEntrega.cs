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
    public partial class frmModificarEntrega : Form
    {
        public int entid { get; set; }
        public Entrega ent = new Entrega();
        public frmModificarEntrega(int eI)
        {
            entid = eI;
            InitializeComponent();
        }

        private void frmModificarEntrega_Load(object sender, EventArgs e)
        {
           
            CargarComboBoxBarrio();
            CargarComboBoxSucursal();
            CargarComboBoxTipoEntrega();
            CargarComboBoxTipoSalida();

            ObtenerDatosEntrega();
        }


        private void CargarComboBoxBarrio()
        {
            cmbBarrio.ValueMember = "barid";
            cmbBarrio.DisplayMember = "barnombre";

            cmbBarrio.DataSource = Barrios.BarrioObtenerTodo().DefaultView;

            cmbBarrio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbBarrio.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void CargarComboBoxTipoSalida()
        {
            cmbTipoSalida.ValueMember = "tpsid";
            cmbTipoSalida.DisplayMember = "tpstipo";
            cmbTipoSalida.DataSource = TiposSalida.TipoSalidaObtenerTodo().DefaultView;

        }

        private void CargarComboBoxSucursal()
        {
            cmbSucursal.ValueMember = "sucid";
            cmbSucursal.DisplayMember = "sucnombre";
            cmbSucursal.DataSource = Sucursales.SucursalObtenerTodo().DefaultView;

        }

        private void CargarComboBoxTipoEntrega()
        {
            cmbTipoEntrega.ValueMember = "tpeid";
            cmbTipoEntrega.DisplayMember = "tpetipo";
            cmbTipoEntrega.DataSource = TiposEntrega.GetTipoEntregaDatos().DefaultView;

        }


        public void ObtenerDatosEntrega()
        {
            
            ent = Entregas.GetPorId(entid);
            this.Text = "ENTREGAS - MODIFICAR ENTREGA N° " + ent.remnumero;
            txtNumeroRemito.Text = ent.remnumero;
            txtCalle.Text = ent.entcalle;
            txtComentario.Text = ent.entcomentarios;
            txtCosto.Text = ent.entcosto.ToString();
            txtDepto.Text = ent.entdepto;
            txtNumero.Text = ent.entnumero;
            txtPiso.Text = ent.entpiso;
            dtpFecha.Value = ent.entfecha;

            Sucursal suc = new Sucursal();
            suc = Sucursales.GetPorId(ent.sucid);
            cmbSucursal.Text = suc.sucnombre;

            TipoSalida tps = new TipoSalida();
            tps = TiposSalida.GetPorId(ent.tpsid);
            cmbTipoSalida.Text = tps.tpstipo;

            //if (tps.tpstipo == "INTERNA")
            //{
            //    txtCalle.Enabled = false;
            //    txtNumero.Enabled = false;
            //    txtDepto.Enabled = false;
            //    txtPiso.Enabled = false;
            //    cmbTipoEntrega.Enabled = false;
            //    txtCosto.Enabled =  false;

            //}

            Barrio bar = new Barrio();
            bar = Barrios.GetPorId(ent.barid);
            cmbBarrio.Text = bar.barnombre;

            TipoEntrega tpe = new TipoEntrega();
            tpe = TiposEntrega.GetPorId(ent.tpeid);
            cmbTipoEntrega.Text = tpe.tpetipo;


            //obtebgo el detalle
            DataTable dt = EntregasDetalle.GetEntregaDetallePorId(entid);

            dgvDetalle.Rows.Clear();
            foreach(DataRow row in dt.Rows)
            {
                dgvDetalle.Rows.Add(row.ItemArray[0].ToString(), row.ItemArray[3].ToString(),
                    row.ItemArray[2].ToString(), row.ItemArray[4].ToString());
            }

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean ValidarDatos()
        {
            errorProvider1.Clear();
            bool res = false;
            if (txtNumeroRemito.Text != string.Empty)
            {
                if (txtCalle.Text != string.Empty)
                {

                    if (txtNumero.Text != string.Empty)
                    {
                        if (txtCosto.Text != string.Empty)
                        {
                            res = true;
                        }
                        else
                        {
                            lblValidacion.Text = "DEBE COMPLETAR EL CAMPO COSTO.";
                            errorProvider1.SetError(txtCosto, "DEBE COMPLETAR EL CAMPO COSTO");
                            res = false;
                            txtCosto.Focus();
                        }
                    }
                    else
                    {
                        lblValidacion.Text = "DEBE COMPLETAR EL CAMPO NÚMERO.";
                        errorProvider1.SetError(txtNumero, "DEBE COMPLETAR EL CAMPO NÚMERO");
                        res = false;
                        txtNumero.Focus();
                    }
                }
                else
                {
                    lblValidacion.Text = "DEBE COMPLETAR EL CAMPO CALLE.";
                    errorProvider1.SetError(txtCalle, "DEBE COMPLETAR EL CAMPO CALLE");
                    res = false;
                    txtCalle.Focus();
                }

            }
            else
            {
                lblValidacion.Text = "DEBE COMPLETAR EL CAMPO NÚMERO DE REMITO.";
                errorProvider1.SetError(txtNumeroRemito, "DEBE COMPLETAR EL CAMPO NÚMERO DE REMITO");
                res = false;
                txtNumeroRemito.Focus();
            }



            return res;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == true)
            {
                ent.barid = Convert.ToInt32(cmbBarrio.SelectedValue);
                ent.entcalle = txtCalle.Text;
                ent.entcomentarios = txtComentario.Text;
                ent.entcosto = Convert.ToDecimal(txtCosto.Text);
                ent.entdepto = txtDepto.Text;
                ent.entfecha = dtpFecha.Value;
                ent.entnumero = txtNumero.Text;
                ent.entpiso = txtPiso.Text;
                ent.remnumero = txtNumeroRemito.Text;
                ent.sucid = Convert.ToInt32(cmbSucursal.SelectedValue);
                ent.tpeid = Convert.ToInt32(cmbTipoEntrega.SelectedValue);
                ent.tpsid = Convert.ToInt32(cmbTipoSalida.SelectedValue);

                IList<EntregaDetalle> detalles = new List<EntregaDetalle>();

                foreach(DataGridViewRow row in dgvDetalle.Rows)
                {
                    EntregaDetalle detalle = new EntregaDetalle();

                    detalle.entid = entid;
                    detalle.edeid = Convert.ToInt32(row.Cells[0].Value);
                    detalle.edecantidad = Convert.ToInt32(row.Cells[1].Value);
                    detalle.edeproducto = row.Cells[2].Value.ToString();
                    detalle.edesalida = row.Cells[3].Value.ToString();

                    detalles.Add(detalle);
                }



                int resultado = 0;
                resultado = Entregas.EntregaModificar(ent, detalles);
                if (resultado > 0)
                {
                    MessageBox.Show("LA ENTREGA SE ACTUALIZO CORRECTAMENTE.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("OCURRIO UN ERROR AL MODIFICAR LA ENTREGA.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbTipoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoSalida.SelectedIndex == 1)
            {
                txtCalle.Enabled = false;
                txtNumero.Enabled = false;
                txtDepto.Enabled = false;
                txtPiso.Enabled = false;
                cmbTipoEntrega.Enabled = false;
                txtCosto.Enabled = false;
                txtCalle.Text = string.Empty;
                txtNumero.Text = string.Empty;
                txtDepto.Text = string.Empty;
                txtPiso.Text = string.Empty;
                txtCosto.Text = "0.00";
            }
            else
            {
                txtCalle.Enabled = true;
                txtNumero.Enabled = true;
                txtDepto.Enabled = true;
                txtPiso.Enabled = true;
                cmbTipoEntrega.Enabled = true;
                txtCosto.Enabled = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dgvDetalle.Rows.Add();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dgvDetalle.Rows.RemoveAt(dgvDetalle.CurrentRow.Index);
        }

    }
}
