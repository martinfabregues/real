using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace REAL
{
    public partial class frmBonificacionProducto : Form
    {
        public frmBonificacionProducto()
        {
            InitializeComponent();
        }


        private void IniciarControles()
        {
            txtCosto.Enabled = false;
            txtProducto.Enabled = false;
            txtMetros.Visible = false;
            txtid.Visible = false;
        }

        private void CargarComboBoxProveedor()
        {
            cmbProveedor.ValueMember = "proid";
            cmbProveedor.DisplayMember = "pronombre";
            cmbProveedor.DataSource = Proveedores.GetProveedoresDatos();
            cmbProveedor.SelectedIndex = 0;
        }


        private void CargarComboBoxBonificacion(int proid)
        {
            cmbBonificacion.DataSource = null;
            cmbBonificacion.ValueMember = "bonid";
            cmbBonificacion.DisplayMember = "bonnombre";
            DataTable dt = Bonificaciones.GetBonificacionPorIdProveedor(proid);
            //cmbBonificacion.SelectedIndex = 0;
            if (dt.Rows.Count == 0)
            {
                cmbBonificacion.Items.Clear();
                cmbBonificacion.Items.Add("NO HAY PROMOCIONES ASIGNADAS AL PROVEEDOR");
                cmbBonificacion.SelectedIndex = 0;
            }
            else
            {
                cmbBonificacion.DataSource = dt;
            }
        }

        private void CrearGrid()
        {
            //dgvProductos.Columns.Clear();

            DataGridViewTextBoxColumn bopId = new DataGridViewTextBoxColumn();
            bopId.HeaderText = "ID";
            bopId.Name = "bopid";
            bopId.Visible = false;

            DataGridViewTextBoxColumn prdId = new DataGridViewTextBoxColumn();
            prdId.HeaderText = "ID PROD";
            prdId.Name = "prdid";
            prdId.Visible = false;

            DataGridViewTextBoxColumn prdCodigo = new DataGridViewTextBoxColumn();
            prdCodigo.HeaderText = "CÓDIGO PROD.";
            prdCodigo.Name = "prdCodigo";

            DataGridViewTextBoxColumn prdDenominacion = new DataGridViewTextBoxColumn();
            prdDenominacion.HeaderText = "PRODUCTO";
            prdDenominacion.Name = "prdDenominacion";

            DataGridViewTextBoxColumn prdCosto = new DataGridViewTextBoxColumn();
            prdCosto.HeaderText = "COSTO";
            prdCosto.Name = "prdCosto";
            prdCosto.ValueType = typeof(Decimal);
            DataGridViewCellStyle currencyCellStyle = new DataGridViewCellStyle();
            currencyCellStyle.Format = "C";
            prdCosto.DefaultCellStyle = currencyCellStyle;

            DataGridViewButtonColumn Eliminar = new DataGridViewButtonColumn();
            Eliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Eliminar.HeaderText = "QUITAR PRODUCTO";
            Eliminar.Name = "btnEliminar";
            Eliminar.Text = "Eliminar";
            Eliminar.UseColumnTextForButtonValue = true;

            dgvProductos.Columns.Add(bopId);
            dgvProductos.Columns.Add(prdId);
            dgvProductos.Columns.Add(prdCodigo);
            dgvProductos.Columns.Add(prdDenominacion);
            dgvProductos.Columns.Add(prdCosto);
            dgvProductos.Columns.Add(Eliminar);

            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
        }



        private void frmBonificacionProducto_Load(object sender, EventArgs e)
        {
            CrearGrid();
            CargarComboBoxProveedor();
            IniciarControles();

        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedIndex > -1)
            {
                CargarComboBoxBonificacion(Convert.ToInt32(cmbProveedor.SelectedValue));
            }


        }

        private void cmbBonificacion_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbBonificacion.SelectedIndex > -1)
            {
                DataTable dt = BonificacionesProducto.GetProductosPorIdBonificacion(Convert.ToInt32(cmbBonificacion.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    dgvProductos.Rows.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgvProductos.Rows.Add(dr.ItemArray[0], dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3], dr.ItemArray[4], "");
                    }
                }
                else
                {
                    dgvProductos.Rows.Clear();
                }
            }
        }




        private void ObtenerProducto(int prdid)
        {
            DataTable dt = new DataTable();
            dt = Productos.GetProductoObtenerPorId(prdid);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["proid"]) == Convert.ToInt32(cmbProveedor.SelectedValue))
                {
                    txtProducto.Text = dt.Rows[0].ItemArray[1].ToString();
                    txtCosto.Text = dt.Rows[0].ItemArray[7].ToString();
                    txtCodigo.Text = dt.Rows[0].ItemArray[11].ToString();
                    txtMetros.Text = dt.Rows[0].ItemArray[13].ToString();
                }
            }
            else
            {

                errorProvider1.SetError(btnBuscar, "EL PRODUCTO NO EXISTE REGISTRADO EN EL SISTEMA.");
                txtProducto.Focus();
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtProducto.Text = string.Empty;
            errorProvider1.Clear();

            dlgProducto dlg = new dlgProducto(Convert.ToInt32(cmbProveedor.SelectedValue));
            dlg.Text = "PRODUCTOS - LISTADO DE PRODUCTOS";
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtid.Text = dlg.prdid.ToString();

                DataTable dt = Productos.GetProductoObtenerPorId(Convert.ToInt32(txtid.Text));
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["proid"]) == Convert.ToInt32(cmbProveedor.SelectedValue))
                    {
                        txtCodigo.Text = dlg.prdcodigo.ToString();
                    }
                    else
                    {
                        errorProvider1.SetError(btnBuscar, "EL PRODUCTO NO COINCIDE CON EL PROVEEDOR SELECCIONADO");
                        btnBuscar.Focus();
                    }
                }

            }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (txtid.Text != string.Empty)
            {
                ObtenerProducto(Convert.ToInt32(txtid.Text));
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                errorProvider1.SetError(btnBuscar, "SOLO SE PERMITEN NÚMEROS EN EL CAMPO FACTURA.");
                e.Handled = true;
                txtCodigo.Focus();
                return;

            }
        }


        private void LimpiarControlesProducto()
        {
            txtCodigo.Text = string.Empty;
            txtid.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtMetros.Text = string.Empty;
            txtCosto.Focus();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (txtCodigo.Text != string.Empty)
            {


                if (txtCosto.Text != string.Empty)
                {
                    dgvProductos.Rows.Add("", txtid.Text, txtCodigo.Text, txtProducto.Text, txtCosto.Text);
                    LimpiarControlesProducto();

                }
                else
                {

                    errorProvider1.SetError(txtCosto, "DEBE COMPLETAR EL CAMPO COSTO.");
                    txtCosto.Focus();
                }

            }
            else
            {


                errorProvider1.SetError(btnBuscar, "DEBE COMPLETAR EL CAMPO CÓDIGO.");
                txtCodigo.Focus();
            }

        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int resultado = 0;
            if (dgvProductos.Rows.Count > 0)
            {
                if (dgvProductos.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    DataGridViewRow row = dgvProductos.CurrentRow;
                    int fila = dgvProductos.CurrentRow.Index;
                    DialogResult result = MessageBox.Show("Se van a eliminar el producto seleccionados, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (row.Cells[0].Value.ToString() != string.Empty)
                        {
                            BonificacionProducto bop = new BonificacionProducto();
                            bop.bopid = Convert.ToInt32(row.Cells[0].Value);
                            resultado = BonificacionesProducto.BonificacionProductoEliminar(bop);
                            if (resultado > 0)
                            {
                                dgvProductos.Rows.RemoveAt(fila);
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error al quitar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            }
                        }
                        else
                        {
                            dgvProductos.Rows.RemoveAt(fila);
                        }

                    }

                    txtCodigo.Focus();
                }
            }

        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3) //Column ColB
            {
                if (e.Value != null)
                {
                    e.CellStyle.Format = "C";
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Se van a asociar los los productos seleccionados, esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int resultado = 0;
                bool res = false;
                try
                {
                    foreach (DataGridViewRow dr in dgvProductos.Rows)
                    {
                        if (dr.Cells[0].Value.ToString() == string.Empty)
                        {
                            BonificacionProducto bop = new BonificacionProducto();
                            bop.bonid = Convert.ToInt32(cmbBonificacion.SelectedValue);
                            bop.prdid = Convert.ToInt32(dr.Cells[1].Value);
                            bop = BonificacionesProducto.Insertar(bop);
                            if (bop == null)
                            {
                                res = true;
                                break;
                            }
                        }
                    }
                    if (res != true)
                    {
                       
                        MessageBox.Show("Los productos se asociaron con exito", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarComboBoxProveedor();
                        IniciarControles();
                        //CrearGrid();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al intentar asociar los productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtDenominacion_TextChanged(object sender, EventArgs e)
        {
            dgvProductos.Rows.Clear();
            if (txtDenominacion.Text != string.Empty)
            {
                DataTable dt = BonificacionesProducto.GetProductosPorIdBonificacionLikeProducto(Convert.ToInt32(cmbBonificacion.SelectedValue), txtDenominacion.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgvProductos.Rows.Add(dr.ItemArray[0], dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3], dr.ItemArray[4], "");
                    }
                }
                else
                {
                    dgvProductos.Rows.Clear();
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            dgvProductos.Rows.Clear();
            if (txtDenominacion.Text != string.Empty)
            {

                DataTable dt = BonificacionesProducto.GetProductosPorIdBonificacionLikeProducto(Convert.ToInt32(cmbBonificacion.SelectedValue), txtDenominacion.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgvProductos.Rows.Add(dr.ItemArray[0], dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3], dr.ItemArray[4], "");
                    }
                }
                else
                {
                    dgvProductos.Rows.Clear();
                }


            }
            else
            {
                errorProvider1.SetError(txtDenominacion, "El campo denominacion no puede estar vacio.");
                txtDenominacion.Focus();
            }
        }




    }
}
