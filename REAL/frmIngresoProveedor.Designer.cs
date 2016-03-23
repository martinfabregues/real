namespace REAL
{
    partial class frmIngresoProveedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaRecepcion = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.ckbCosto = new System.Windows.Forms.CheckBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.prdid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facturaproveedordetalle_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orden_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orden_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orden_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orden_detalle_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtIdIngreso = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtFactura = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOrdenDetalle_Id = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtIdOrden = new System.Windows.Forms.TextBox();
            this.txtNroOrden = new System.Windows.Forms.TextBox();
            this.btnBuscarOrden = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRN = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtIngBrutos = new System.Windows.Forms.TextBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ckbRemito = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtRemito = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnBuscarRemito = new System.Windows.Forms.Button();
            this.dgvRemitos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitos)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "N° Factura:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha Factura:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha Recepción:";
            // 
            // dtpFechaRecepcion
            // 
            this.dtpFechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRecepcion.Location = new System.Drawing.Point(121, 124);
            this.dtpFechaRecepcion.Name = "dtpFechaRecepcion";
            this.dtpFechaRecepcion.Size = new System.Drawing.Size(129, 20);
            this.dtpFechaRecepcion.TabIndex = 9;
            // 
            // dtpFechaFactura
            // 
            this.dtpFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFactura.Location = new System.Drawing.Point(121, 101);
            this.dtpFechaFactura.Name = "dtpFechaFactura";
            this.dtpFechaFactura.Size = new System.Drawing.Size(129, 20);
            this.dtpFechaFactura.TabIndex = 8;
            // 
            // ckbCosto
            // 
            this.ckbCosto.AutoSize = true;
            this.ckbCosto.Location = new System.Drawing.Point(175, 79);
            this.ckbCosto.Name = "ckbCosto";
            this.ckbCosto.Size = new System.Drawing.Size(59, 17);
            this.ckbCosto.TabIndex = 18;
            this.ckbCosto.Text = "Activar";
            this.ckbCosto.UseVisualStyleBackColor = true;
            this.ckbCosto.CheckedChanged += new System.EventHandler(this.ckbCosto_CheckedChanged);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(553, 527);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(100, 20);
            this.txtid.TabIndex = 13;
            this.txtid.TextChanged += new System.EventHandler(this.txtid_TextChanged);
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(69, 76);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(100, 20);
            this.txtCosto.TabIndex = 11;
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCosto_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(69, 53);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 10;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(246, 30);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(304, 20);
            this.txtProducto.TabIndex = 9;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.PowderBlue;
            this.txtCodigo.Location = new System.Drawing.Point(69, 30);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 7;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Costo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Cantidad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(243, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Producto:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Código:";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prdid,
            this.Column1,
            this.Column2,
            this.Column3,
            this.cantidad,
            this.total,
            this.facturaproveedordetalle_id,
            this.orden_id,
            this.orden_numero,
            this.orden_fecha,
            this.orden_detalle_id,
            this.eliminar});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalle.Location = new System.Drawing.Point(11, 209);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(881, 215);
            this.dgvDetalle.TabIndex = 28;
            this.dgvDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellClick);
            this.dgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEndEdit);
            this.dgvDetalle.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDetalle_CellValidating);
            // 
            // prdid
            // 
            this.prdid.HeaderText = "ID";
            this.prdid.Name = "prdid";
            this.prdid.Visible = false;
            this.prdid.Width = 43;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            this.Column1.Width = 65;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Producto";
            this.Column2.Name = "Column2";
            this.Column2.Width = 75;
            // 
            // Column3
            // 
            dataGridViewCellStyle1.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Costo Unit.";
            this.Column3.Name = "Column3";
            this.Column3.Width = 84;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cant.";
            this.cantidad.Name = "cantidad";
            this.cantidad.Width = 57;
            // 
            // total
            // 
            dataGridViewCellStyle2.NullValue = null;
            this.total.DefaultCellStyle = dataGridViewCellStyle2;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.Width = 56;
            // 
            // facturaproveedordetalle_id
            // 
            this.facturaproveedordetalle_id.HeaderText = "facturaproveedordetalle_id";
            this.facturaproveedordetalle_id.Name = "facturaproveedordetalle_id";
            this.facturaproveedordetalle_id.Visible = false;
            this.facturaproveedordetalle_id.Width = 158;
            // 
            // orden_id
            // 
            this.orden_id.HeaderText = "Id Orden";
            this.orden_id.Name = "orden_id";
            this.orden_id.Visible = false;
            this.orden_id.Width = 73;
            // 
            // orden_numero
            // 
            this.orden_numero.HeaderText = "Nro. Orden";
            this.orden_numero.Name = "orden_numero";
            this.orden_numero.Width = 84;
            // 
            // orden_fecha
            // 
            this.orden_fecha.HeaderText = "Fecha";
            this.orden_fecha.Name = "orden_fecha";
            this.orden_fecha.Width = 62;
            // 
            // orden_detalle_id
            // 
            this.orden_detalle_id.HeaderText = "orden_detalle_id";
            this.orden_detalle_id.Name = "orden_detalle_id";
            this.orden_detalle_id.Visible = false;
            this.orden_detalle_id.Width = 110;
            // 
            // eliminar
            // 
            this.eliminar.HeaderText = "Eliminar Fila";
            this.eliminar.Name = "eliminar";
            this.eliminar.Text = "Eliminar Fila";
            this.eliminar.UseColumnTextForButtonValue = true;
            this.eliminar.Width = 68;
            // 
            // txtIdIngreso
            // 
            this.txtIdIngreso.Location = new System.Drawing.Point(447, 527);
            this.txtIdIngreso.Name = "txtIdIngreso";
            this.txtIdIngreso.Size = new System.Drawing.Size(100, 20);
            this.txtIdIngreso.TabIndex = 33;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(28, 592);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(713, 217);
            this.groupBox5.TabIndex = 44;
            this.groupBox5.TabStop = false;
            // 
            // txtFactura
            // 
            this.txtFactura.HidePromptOnLeave = true;
            this.txtFactura.Location = new System.Drawing.Point(121, 79);
            this.txtFactura.Mask = "9999-99999999";
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(129, 20);
            this.txtFactura.TabIndex = 117;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOrdenDetalle_Id);
            this.groupBox2.Controls.Add(this.txtFecha);
            this.groupBox2.Controls.Add(this.txtIdOrden);
            this.groupBox2.Controls.Add(this.txtNroOrden);
            this.groupBox2.Controls.Add(this.ckbCosto);
            this.groupBox2.Controls.Add(this.btnBuscarOrden);
            this.groupBox2.Controls.Add(this.txtCodigo);
            this.groupBox2.Controls.Add(this.txtProducto);
            this.groupBox2.Controls.Add(this.txtCantidad);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCosto);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Location = new System.Drawing.Point(310, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 137);
            this.groupBox2.TabIndex = 120;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Items Factura";
            // 
            // txtOrdenDetalle_Id
            // 
            this.txtOrdenDetalle_Id.Location = new System.Drawing.Point(415, 79);
            this.txtOrdenDetalle_Id.Name = "txtOrdenDetalle_Id";
            this.txtOrdenDetalle_Id.Size = new System.Drawing.Size(100, 20);
            this.txtOrdenDetalle_Id.TabIndex = 22;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(392, 53);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 21;
            // 
            // txtIdOrden
            // 
            this.txtIdOrden.Location = new System.Drawing.Point(352, 53);
            this.txtIdOrden.Name = "txtIdOrden";
            this.txtIdOrden.Size = new System.Drawing.Size(34, 20);
            this.txtIdOrden.TabIndex = 20;
            // 
            // txtNroOrden
            // 
            this.txtNroOrden.Location = new System.Drawing.Point(246, 53);
            this.txtNroOrden.Name = "txtNroOrden";
            this.txtNroOrden.Size = new System.Drawing.Size(100, 20);
            this.txtNroOrden.TabIndex = 19;
            // 
            // btnBuscarOrden
            // 
            this.btnBuscarOrden.Image = global::REAL.Properties.Resources.search;
            this.btnBuscarOrden.Location = new System.Drawing.Point(175, 28);
            this.btnBuscarOrden.Name = "btnBuscarOrden";
            this.btnBuscarOrden.Size = new System.Drawing.Size(38, 23);
            this.btnBuscarOrden.TabIndex = 17;
            this.btnBuscarOrden.UseVisualStyleBackColor = true;
            this.btnBuscarOrden.Click += new System.EventHandler(this.btnBuscarOrden_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::REAL.Properties.Resources.down_;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(246, 79);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(126, 36);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtObservacion);
            this.groupBox4.Location = new System.Drawing.Point(11, 430);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(536, 91);
            this.groupBox4.TabIndex = 121;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Observaciones";
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.Color.Beige;
            this.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Location = new System.Drawing.Point(9, 19);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(518, 64);
            this.txtObservacion.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtRN);
            this.groupBox3.Controls.Add(this.txtTotal);
            this.groupBox3.Controls.Add(this.txtIngBrutos);
            this.groupBox3.Controls.Add(this.txtIva);
            this.groupBox3.Controls.Add(this.txtSubtotal);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(553, 430);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(339, 91);
            this.groupBox3.TabIndex = 122;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Totales";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(186, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 120;
            this.label12.Text = "RN 2408/08:";
            // 
            // txtRN
            // 
            this.txtRN.Location = new System.Drawing.Point(258, 21);
            this.txtRN.Name = "txtRN";
            this.txtRN.Size = new System.Drawing.Size(71, 20);
            this.txtRN.TabIndex = 119;
            this.txtRN.TextChanged += new System.EventHandler(this.txtRN_TextChanged);
            this.txtRN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRN_KeyPress);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.SeaShell;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(222, 46);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(107, 20);
            this.txtTotal.TabIndex = 118;
            // 
            // txtIngBrutos
            // 
            this.txtIngBrutos.Location = new System.Drawing.Point(84, 63);
            this.txtIngBrutos.Name = "txtIngBrutos";
            this.txtIngBrutos.Size = new System.Drawing.Size(89, 20);
            this.txtIngBrutos.TabIndex = 117;
            this.txtIngBrutos.TextChanged += new System.EventHandler(this.txtIngBrutos_TextChanged);
            this.txtIngBrutos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIngBrutos_KeyPress);
            // 
            // txtIva
            // 
            this.txtIva.Location = new System.Drawing.Point(84, 42);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(89, 20);
            this.txtIva.TabIndex = 116;
            this.txtIva.TextChanged += new System.EventHandler(this.txtIva_TextChanged);
            this.txtIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIva_KeyPress);
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(84, 21);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(89, 20);
            this.txtSubtotal.TabIndex = 115;
            this.txtSubtotal.TextChanged += new System.EventHandler(this.txtSubtotal_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 114;
            this.label13.Text = "Ing.Brut. CBA.:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 113;
            this.label1.Text = "IVA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "Subtotal:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(186, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 108;
            this.label14.Text = "Total:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ckbRemito);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.cmbSucursal);
            this.groupBox6.Controls.Add(this.cmbProveedor);
            this.groupBox6.Location = new System.Drawing.Point(6, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(276, 69);
            this.groupBox6.TabIndex = 118;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Proveedor";
            // 
            // ckbRemito
            // 
            this.ckbRemito.AutoSize = true;
            this.ckbRemito.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckbRemito.Location = new System.Drawing.Point(115, -1);
            this.ckbRemito.Name = "ckbRemito";
            this.ckbRemito.Size = new System.Drawing.Size(125, 17);
            this.ckbRemito.TabIndex = 3;
            this.ckbRemito.Text = "Registrar con Remito";
            this.ckbRemito.UseVisualStyleBackColor = false;
            this.ckbRemito.CheckedChanged += new System.EventHandler(this.ckbRemito_CheckedChanged_1);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(7, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 28);
            this.label11.TabIndex = 2;
            this.label11.Text = "Deposito Ingreso:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new System.Drawing.Point(63, 42);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(203, 21);
            this.cmbSucursal.TabIndex = 1;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(11, 17);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(255, 21);
            this.cmbProveedor.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(881, 198);
            this.tabControl1.TabIndex = 123;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtRemito);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtFactura);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.dtpFechaRecepcion);
            this.tabPage1.Controls.Add(this.dtpFechaFactura);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(873, 172);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos Factura";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtRemito
            // 
            this.txtRemito.HidePromptOnLeave = true;
            this.txtRemito.Location = new System.Drawing.Point(121, 146);
            this.txtRemito.Mask = "9999-99999999";
            this.txtRemito.Name = "txtRemito";
            this.txtRemito.Size = new System.Drawing.Size(129, 20);
            this.txtRemito.TabIndex = 123;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 122;
            this.label4.Text = "Nro. Remito:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.dgvRemitos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(873, 172);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Remitos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnBuscarRemito);
            this.groupBox7.Location = new System.Drawing.Point(6, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 45);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Remitos";
            // 
            // btnBuscarRemito
            // 
            this.btnBuscarRemito.Image = global::REAL.Properties.Resources.document;
            this.btnBuscarRemito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarRemito.Location = new System.Drawing.Point(27, 16);
            this.btnBuscarRemito.Name = "btnBuscarRemito";
            this.btnBuscarRemito.Size = new System.Drawing.Size(125, 23);
            this.btnBuscarRemito.TabIndex = 0;
            this.btnBuscarRemito.Text = "&Buscar Remitos";
            this.btnBuscarRemito.UseVisualStyleBackColor = true;
            this.btnBuscarRemito.Click += new System.EventHandler(this.btnBuscarRemito_Click);
            // 
            // dgvRemitos
            // 
            this.dgvRemitos.AllowUserToAddRows = false;
            this.dgvRemitos.AllowUserToDeleteRows = false;
            this.dgvRemitos.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvRemitos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRemitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemitos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.numero,
            this.fecha});
            this.dgvRemitos.Location = new System.Drawing.Point(6, 54);
            this.dgvRemitos.Name = "dgvRemitos";
            this.dgvRemitos.ReadOnly = true;
            this.dgvRemitos.Size = new System.Drawing.Size(274, 92);
            this.dgvRemitos.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // numero
            // 
            this.numero.HeaderText = "Nro. Remito";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Image = global::REAL.Properties.Resources.save;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(12, 527);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(129, 33);
            this.btnRegistrar.TabIndex = 118;
            this.btnRegistrar.Text = "&Guardar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Image = global::REAL.Properties.Resources.back_icon_16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(763, 527);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(129, 33);
            this.btnCerrar.TabIndex = 119;
            this.btnCerrar.Text = "&Salir";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmIngresoProveedor
            // 
            this.AcceptButton = this.btnRegistrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(904, 572);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.txtIdIngreso);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.txtid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmIngresoProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIngresoProveedor";
            this.Load += new System.EventHandler(this.frmIngresoProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFechaRecepcion;
        private System.Windows.Forms.DateTimePicker dtpFechaFactura;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnBuscarOrden;
        private System.Windows.Forms.CheckBox ckbCosto;
        private System.Windows.Forms.TextBox txtIdIngreso;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.MaskedTextBox txtFactura;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtIngBrutos;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtRemito;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnBuscarRemito;
        private System.Windows.Forms.DataGridView dgvRemitos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.CheckBox ckbRemito;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbSucursal;
        private System.Windows.Forms.TextBox txtNroOrden;
        private System.Windows.Forms.TextBox txtIdOrden;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRN;
        private System.Windows.Forms.TextBox txtOrdenDetalle_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn prdid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturaproveedordetalle_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden_detalle_id;
        private System.Windows.Forms.DataGridViewButtonColumn eliminar;
    }
}