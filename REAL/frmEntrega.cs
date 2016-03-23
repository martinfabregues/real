using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmEntrega : Form
    {
        public frmEntrega()
        {
            InitializeComponent();
           
        }

        private void IniciarControles()
        {
            dtpFecha.Value = DateTime.Today.Date;
            //dtpFecha.IsEnabled = false;
            //dtpFecha.SelectedDate = DateTime.Today.Date;

            txtCalle.Text = string.Empty;
            txtDepto.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtPiso.Text = string.Empty;
            txtNumeroRemito.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtComentario.Text = string.Empty;

            txtCosto.Enabled = false;

            CargarComboBoxBarrio();
            CargarComboBoxSucursal();
            CargarComboBoxTipoEntrega();

            //_entrega.Clear();
            //dgvDetalle.ItemsSource = _entrega;
            //dgvDetalle.Columns[0].Visibility = System.Windows.Visibility.Hidden;
            //dgvDetalle.Columns[1].Visibility = System.Windows.Visibility.Hidden;


            CargarComboBoxTipoSalida();
            //cmbTipoSalida.IsEnabled = false;
            CrearGrid();
        }

        private void CrearGrid()
        {
            this.dgvDetalle.Rows.Clear();
            this.dgvDetalle.RowCount = 1;

            //DataGridViewTextBoxColumn Cantidad = new DataGridViewTextBoxColumn();
            //Cantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Cantidad.HeaderText = "Cantidad";
            //Cantidad.DataPropertyName = "CANTIDAD";

            //DataGridViewTextBoxColumn Producto = new DataGridViewTextBoxColumn();
            //Producto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Producto.HeaderText = "Producto";
            //Producto.DataPropertyName = "PRODUCTO";

            //DataGridViewTextBoxColumn Salida = new DataGridViewTextBoxColumn();
            //Salida.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Salida.HeaderText = "Suc. Salida";
            //Salida.DataPropertyName = "SALIDA";

            //DataGridViewButtonColumn Eliminar = new DataGridViewButtonColumn();
            //Eliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Eliminar.HeaderText = "Eliminar";
            //Eliminar.UseColumnTextForButtonValue = true;
            //Eliminar.Text = "Eliminar";
            //Eliminar.Name = "btnEliminar";          

            //dgvDetalle.Columns.Add(Cantidad);
            //dgvDetalle.Columns.Add(Producto);
            //dgvDetalle.Columns.Add(Salida);
            //dgvDetalle.Columns.Add(Eliminar);

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //errorProvider.Clear();
            //if (txtCantidad.Text != string.Empty)
            //{
            //    if (txtProducto.Text != string.Empty)
            //    {
            //        if (txtSalida.Text != string.Empty)
            //        {
            //            dgvDetalle.Rows.Add(txtCantidad.Text, txtProducto.Text, txtSalida.Text);
            //            LimpiarControlesDetalle();
            //        }
            //        else
            //        {
            //            dgvDetalle.Rows.Add(txtCantidad.Text, txtProducto.Text, cmbSucursal.Text);
            //            LimpiarControlesDetalle();
            //        }
            //    }
            //    else
            //    {
            //        lblValidacion.Text = "DEBE COMPLETAR EL CAMPO PRODUCTO.";
            //        errorProvider.SetError(txtProducto, "DEBE COMPLETAR EL CAMPO PRODUCTO.");
            //        txtProducto.Focus();
            //    }
            //}
            //else
            //{
            //    lblValidacion.Text = "DEBE COMPLETAR EL CAMPO CANTIDAD.";
            //    errorProvider.SetError(txtCantidad, "DEBE COMPLETAR EL CAMPO CANTIDAD.");
            //    txtCantidad.Focus();
            //}
        }

        private void LimpiarControlesDetalle()
        {
            //txtCantidad.Text = string.Empty;
            //txtProducto.Text = string.Empty;
            //txtSalida.Text = string.Empty;
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                if (dgvDetalle.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    int fila = dgvDetalle.CurrentRow.Index;
                    dgvDetalle.Rows.RemoveAt(fila);

                    //txtCantidad.Focus();
                }
            }
        }

        private Boolean ValidarDatos()
        {
            errorProvider.Clear();
            bool res = false;
            if (txtNumeroRemito.Text != string.Empty)
            {
                if (txtCalle.Text != string.Empty)
                {
                    if (txtNumero.Text != string.Empty)
                    {
                        if (ckbCosto.Checked == true)
                        {
                            if (txtCosto.Text != string.Empty)
                            {
                                if (dgvDetalle.Rows.Count > 0)
                                {
                                    if (txtNumeroRemito.TextLength == 8)
                                    {
                                        res = true;
                                    }
                                    else
                                    {
                                        res = false;
                                        //lblValidacion.Text = "EL FORMATO DE NÚMERO DE REMITO, ES INCORRECTO.";
                                        errorProvider.SetError(txtNumeroRemito, "EL FORMATO DE NÚMERO DE REMITO, ES INCORRECTO.");
                                        txtNumeroRemito.Focus();
                                    }
                                    
                                }
                                else
                                {
                                    res = false;
                                    dgvDetalle.Focus();
                                }
                            }
                            else
                            {
                                res = false;
                                txtCosto.Focus();
                                //lblValidacion.Text = "DEBE COMPLETAR EL CAMPO COSTO.";
                                errorProvider.SetError(txtCosto, "DEBE COMPLETAR EL CAMPO COSTO.");
                            }
                        }
                        else
                        {
                            if (dgvDetalle.Rows.Count > 0)
                            {
                                res = true;
                            }
                            else
                            {
                                res = false;
                                dgvDetalle.Focus();
                            }

                        }

                    }
                    else
                    {
                        res = false;
                        txtNumero.Focus();
                        //lblValidacion.Text = "DEBE COMPLETAR EL CAMPO NÚMERO.";
                        errorProvider.SetError(txtNumero, "DEBE COMPLETAR EL CAMPO NÚMERO.");
                    }
                }
                else
                {
                    res = false;
                    txtCalle.Focus();
                    //lblValidacion.Text = "DEBE COMPLETAR EL CAMPO CALLE.";
                    errorProvider.SetError(txtCalle, "DEBE COMPLETAR EL CAMPO CALLE.");
                }
            }
            else
            {
                res = false;
                txtNumeroRemito.Focus();
                //lblValidacion.Text = "DEBE COMPLETAR EL CAMPO NÚMERO REMITO.";
                errorProvider.SetError(txtNumeroRemito, "DEBE COMPLETAR EL CAMPO NÚMERO REMITO.");
            }

            return res;
        }


        private Boolean ValidarDatosInterno()
        {
            bool res = false;
            errorProvider.Clear();
            if (txtNumeroRemito.Text != string.Empty)
            {

                if (ckbCosto.Checked == true)
                {
                    if (txtCosto.Text != string.Empty)
                    {
                        if (dgvDetalle.Rows.Count > 0)
                        {
                            res = true;
                        }
                        else
                        {
                            res = false;
                            dgvDetalle.Focus();
                        }
                    }
                    else
                    {
                        res = false;
                        txtCosto.Focus();
                        //lblValidacion.Text = "DEBE COMPLETAR EL CAMPO COSTO.";
                        errorProvider.SetError(txtCosto, "DEBE COMPLETAR EL CAMPO COSTO.");
                    }
                }
                else
                {
                    if (dgvDetalle.Rows.Count > 0)
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
                        dgvDetalle.Focus();
                    }

                }

            }
            else
            {
                res = false;
                txtNumero.Focus();
                //lblValidacion.Text = "DEBE COMPLETAR EL CAMPO NÚMERO.";
                errorProvider.SetError(txtNumero, "DEBE COMPLETAR EL CAMPO NÚMERO.");
            }



            return res;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (cmbTipoSalida.Text)
            {
                case "A CLIENTE":
                    if (ValidarDatos() == true)
                    {
                        Entrega ent = new Entrega();
                        ent.sucid = Convert.ToInt32(cmbSucursal.SelectedValue);
                        ent.remnumero = txtNumeroRemito.Text;
                        ent.sucid = Convert.ToInt32(cmbSucursal.SelectedValue);
                        ent.entfecha = dtpFecha.Value;
                        ent.entcalle = txtCalle.Text;
                        ent.entnumero = txtNumero.Text;
                        ent.entpiso = txtPiso.Text;
                        ent.entdepto = txtDepto.Text;
                        ent.barid = Convert.ToInt32(cmbBarrio.SelectedValue);
                        ent.entcomentarios = txtComentario.Text;
                        ent.entcosto = Convert.ToDecimal(txtCosto.Text);
                        ent.tpeid = Convert.ToInt32(cmbTipoEntrega.SelectedValue);
                        ent.tpsid = Convert.ToInt32(cmbTipoSalida.SelectedValue);
                        ent.eseid = 1;

                        //if (ent.entdepto == string.Empty)
                        //{
                        //    ent.entdepto = "N/D";
                        //    if (ent.entpiso == string.Empty)
                        //    {
                        //        ent.entpiso = "N/D";
                        //    }
                        //}
                        //else
                        //{
                        //    if (ent.entpiso == string.Empty)
                        //    {
                        //        ent.entpiso = "N/D";
                        //    }
                        //}
                        try
                        {
                           
                                int resultado = 0;
                                resultado = Entregas.EntregaInsertar(ent);
                                ent.entid = resultado;
                                if (resultado > 0)
                                {
                                    int resultadoDetalle = 0;
                                    EntregaDetalle ede = new EntregaDetalle();
                                    ede.entid = ent.entid;
                                    bool res = false;
                                    if (dgvDetalle.RowCount > 0)
                                    {
                                        foreach (DataGridViewRow item in dgvDetalle.Rows)
                                        {

                                            if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null)
                                            {
                                                ede.edecantidad = Convert.ToInt32(item.Cells[0].Value);
                                                ede.edeproducto = item.Cells[1].Value.ToString();
                                                ede.edesalida = item.Cells[2].Value.ToString();
                                                resultadoDetalle = EntregasDetalle.EntregaDetalleInsertar(ede);
                                                if (resultadoDetalle == 0)
                                                {
                                                    res = true;
                                                    break;
                                                }
                                         
                                            }
                                            else
                                            {
                                                MessageBox.Show("Debe completar correctamente los datos del detalle.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                IniciarControles();
                                            }
                                        }
                                        if (res != true)
                                        {

                                            MessageBox.Show("REGISTRADO CORRECTAMENTE.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            IniciarControles();


                                        }
                                        else
                                        {
                                            MessageBox.Show("OCURRIO UN ERROR AL REGISTRAR LA ENTREGA.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            IniciarControles();
                                        }
                                       
                                    }
                                    else
                                    {
                                        MessageBox.Show("Debe indicar al menos un producto en el detalle.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        IniciarControles();
                                    }


                                }
                                else
                                {
                                    MessageBox.Show("OCURRIO UN ERROR AL REGISTRAR LA ENTREGA.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    IniciarControles();
                                }
                            


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    break;
                case "INTERNA":
                    if (ValidarDatosInterno() == true)
                    {
                        Entrega ent = new Entrega();
                        ent.sucid = Convert.ToInt32(cmbSucursal.SelectedValue);
                        ent.remnumero = txtNumeroRemito.Text;
                        ent.sucid = Convert.ToInt32(cmbSucursal.SelectedValue);
                        ent.entfecha = dtpFecha.Value;
                        ent.entcalle = txtCalle.Text;
                        ent.entnumero = txtNumero.Text;
                        ent.entpiso = txtPiso.Text;
                        ent.entdepto = txtDepto.Text;
                        ent.barid = Convert.ToInt32(cmbBarrio.SelectedValue);
                        ent.entcomentarios = txtComentario.Text;
                        ent.entcosto = Convert.ToDecimal(txtCosto.Text);
                        ent.tpeid = Convert.ToInt32(cmbTipoEntrega.SelectedValue);
                        ent.tpsid = Convert.ToInt32(cmbTipoSalida.SelectedValue);
                        ent.eseid = 1;

                        //if (ent.entdepto == string.Empty)
                        //{
                        //    ent.entdepto = "N/D";
                        //    if (ent.entpiso == string.Empty)
                        //    {
                        //        ent.entpiso = "N/D";
                        //    }
                        //}
                        //else
                        //{
                        //    if (ent.entpiso == string.Empty)
                        //    {
                        //        ent.entpiso = "N/D";
                        //    }
                        //}
                        try
                        {
                            
                                int resultado = 0;
                                resultado = Entregas.EntregaInsertar(ent);
                                ent.entid = resultado;
                                if (resultado > 0)
                                {
                                    int resultadoDetalle = 0;
                                    EntregaDetalle ede = new EntregaDetalle();
                                    ede.entid = ent.entid;
                                    bool res = false;
                                    foreach (DataGridViewRow item in dgvDetalle.Rows)
                                    {
                                        
                                        ede.edecantidad = Convert.ToInt32(item.Cells[0].Value);
                                        ede.edeproducto = item.Cells[1].Value.ToString();
                                        ede.edesalida = item.Cells[2].Value.ToString();
                                        resultadoDetalle = EntregasDetalle.EntregaDetalleInsertar(ede);
                                        if (resultadoDetalle == 0)
                                        {
                                            res = true;
                                            break;
                                        }
                                    }
                                    if (res != true)
                                    {
                                        
                                        MessageBox.Show("REGISTRADO CORRECTAMENTE.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        HabilitarControles();
                                        IniciarControles();
                                       

                                    }
                                    else
                                    {
                                        MessageBox.Show("OCURRIO UN ERROR AL REGISTRAR LA ENTREGA.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        HabilitarControles();
                                        IniciarControles();
                                    }




                                }
                                else
                                {
                                    MessageBox.Show("OCURRIO UN ERROR AL REGISTRAR LA ENTREGA.", "CONTROL ENTREGAS - INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    IniciarControles();
                                }
                            


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    break;
            }

        }

        private void cmbBarrio_SelectedIndexChanged(object sender, EventArgs e)
        {
         
                int barid = Convert.ToInt32(cmbBarrio.SelectedValue);
                DataTable dt = Barrios.BarrioObtenerCostoPorId(barid);
                if (dt.Rows.Count > 0)
                {
                    txtCosto.Text = dt.Rows[0].ItemArray[0].ToString();
                    if (Convert.ToDecimal(dt.Rows[0].ItemArray[0]) != 0)
                    {
                        cmbTipoEntrega.Text = "CON CARGO";
                    }
                    else
                    {
                        cmbTipoEntrega.Text = "SIN CARGO";
                    }

                }
            
         }
        
        private void HabilitarControles()
        {
            txtCalle.Enabled = true;
            txtNumero.Enabled = true;
            txtPiso.Enabled = true;
            txtDepto.Enabled = true;
        }

        private void cmbTipoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoSalida.SelectedIndex > 0)
            {
                txtCalle.Enabled = false;
                txtNumero.Enabled = false;
                txtPiso.Enabled = false;
                txtDepto.Enabled = false;
                cmbTipoEntrega.SelectedIndex = 0;
                txtCosto.Text = string.Empty;
                cmbTipoEntrega.Enabled = false;
                txtCosto.Enabled = false;
                txtCosto.Text = "0.00";
            }
        }

        private void ckbCosto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCosto.Checked == true)
            {
                txtCosto.Enabled = true;
            }
            else
            {
                txtCosto.Enabled = false;
            }
        }

        private void txtNumeroRemito_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO REMITO";
                errorProvider.SetError(txtNumeroRemito, "SOLO SE PERMITEN NÚMEROS EN EL CAMPO REMITO");
                e.Handled = true;
                txtNumeroRemito.Focus();
                return;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO NÚMERO.";
                errorProvider.SetError(txtNumero, "SOLO SE PERMITEN NÚMEROS EN EL CAMPO NÚMERO.");
                e.Handled = true;
                txtNumero.Focus();
                return;
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider.Clear();
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO COSTO.";
                errorProvider.SetError(txtCosto, "SOLO SE PERMITEN NÚMEROS EN EL CAMPO COSTO.");
                e.Handled = true;
                txtCosto.Focus();
                return;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //errorProvider.Clear();
            //if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            //{
            //    lblValidacion.Text = "SOLO SE PERMITEN NÚMEROS EN EL CAMPO CANTIDAD.";
            //    errorProvider.SetError(txtCantidad, "SOLO SE PERMITEN NÚMEROS EN EL CAMPO CANTIDAD.");
            //    e.Handled = true;
            //    txtCantidad.Focus();
            //    return;
            //}
        }

        private void frmNuevaEntrega_Activated(object sender, EventArgs e)
        {
            //IniciarControles();

        }

        private void frmNuevaEntrega_Load(object sender, EventArgs e)
        {
            IniciarControles();
           

        }

        private void frmNuevaEntrega_Resize(object sender, EventArgs e)
        {
          
        }

      








    }
}
