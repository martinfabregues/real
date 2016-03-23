namespace REAL
{
    partial class frmOrdenCompraTest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtOrden = new System.Windows.Forms.TextBox();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblIngBrutos = new System.Windows.Forms.Label();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblMetros = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCostoNeto = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCoeficiente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMetros = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.ckbCosto = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdOrden = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.detalle_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.odcimporteunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ocdcantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metros3_totales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deposito_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOrden
            // 
            this.txtOrden.Location = new System.Drawing.Point(344, 12);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(100, 20);
            this.txtOrden.TabIndex = 106;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(239, 523);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(363, 12);
            this.ProgressBar1.TabIndex = 109;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblIngBrutos);
            this.groupBox5.Controls.Add(this.lblIva);
            this.groupBox5.Controls.Add(this.lblSubtotal);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.lblMetros);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.lblTotal);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(607, 426);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(285, 91);
            this.groupBox5.TabIndex = 108;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Totales";
            // 
            // lblIngBrutos
            // 
            this.lblIngBrutos.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblIngBrutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIngBrutos.ForeColor = System.Drawing.Color.Black;
            this.lblIngBrutos.Location = new System.Drawing.Point(184, 15);
            this.lblIngBrutos.Name = "lblIngBrutos";
            this.lblIngBrutos.Padding = new System.Windows.Forms.Padding(3);
            this.lblIngBrutos.Size = new System.Drawing.Size(95, 21);
            this.lblIngBrutos.TabIndex = 107;
            this.lblIngBrutos.Text = "label14";
            // 
            // lblIva
            // 
            this.lblIva.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIva.ForeColor = System.Drawing.Color.Black;
            this.lblIva.Location = new System.Drawing.Point(54, 62);
            this.lblIva.Name = "lblIva";
            this.lblIva.Padding = new System.Windows.Forms.Padding(3);
            this.lblIva.Size = new System.Drawing.Size(74, 21);
            this.lblIva.TabIndex = 106;
            this.lblIva.Text = "label14";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubtotal.ForeColor = System.Drawing.Color.Black;
            this.lblSubtotal.Location = new System.Drawing.Point(54, 39);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Padding = new System.Windows.Forms.Padding(3);
            this.lblSubtotal.Size = new System.Drawing.Size(74, 21);
            this.lblSubtotal.TabIndex = 105;
            this.lblSubtotal.Text = "label14";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(134, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 104;
            this.label13.Text = "Ing.Brut:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 103;
            this.label12.Text = "IVA:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 102;
            this.label11.Text = "Subtotal:";
            // 
            // lblMetros
            // 
            this.lblMetros.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblMetros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMetros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetros.ForeColor = System.Drawing.Color.Black;
            this.lblMetros.Location = new System.Drawing.Point(54, 15);
            this.lblMetros.Margin = new System.Windows.Forms.Padding(3);
            this.lblMetros.Name = "lblMetros";
            this.lblMetros.Padding = new System.Windows.Forms.Padding(3);
            this.lblMetros.Size = new System.Drawing.Size(74, 21);
            this.lblMetros.TabIndex = 101;
            this.lblMetros.Text = "label9";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 100;
            this.label9.Text = "Metros:";
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(184, 38);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Padding = new System.Windows.Forms.Padding(3);
            this.lblTotal.Size = new System.Drawing.Size(95, 21);
            this.lblTotal.TabIndex = 99;
            this.lblTotal.Text = "label9";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 98;
            this.label5.Text = "Total:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtObservacion);
            this.groupBox4.Location = new System.Drawing.Point(12, 426);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(590, 91);
            this.groupBox4.TabIndex = 107;
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
            this.txtObservacion.Size = new System.Drawing.Size(575, 64);
            this.txtObservacion.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNumero);
            this.groupBox3.Controls.Add(this.txtCantidad);
            this.groupBox3.Controls.Add(this.txtid);
            this.groupBox3.Controls.Add(this.btnAgregar);
            this.groupBox3.Controls.Add(this.txtCostoNeto);
            this.groupBox3.Controls.Add(this.txtProducto);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtCoeficiente);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtMetros);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtCodigo);
            this.groupBox3.Controls.Add(this.ckbCosto);
            this.groupBox3.Controls.Add(this.btnBuscar);
            this.groupBox3.Controls.Add(this.txtCosto);
            this.groupBox3.Location = new System.Drawing.Point(287, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(605, 148);
            this.groupBox3.TabIndex = 102;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Items";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(163, -4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 101;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(87, 58);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 79;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(248, 61);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(100, 20);
            this.txtid.TabIndex = 13;
            this.txtid.TextChanged += new System.EventHandler(this.txtid_TextChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::REAL.Properties.Resources.down_;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(333, 99);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(132, 35);
            this.btnAgregar.TabIndex = 81;
            this.btnAgregar.Text = "&Agregar v";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCostoNeto
            // 
            this.txtCostoNeto.Location = new System.Drawing.Point(87, 104);
            this.txtCostoNeto.Name = "txtCostoNeto";
            this.txtCostoNeto.Size = new System.Drawing.Size(100, 20);
            this.txtCostoNeto.TabIndex = 88;
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(257, 35);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(325, 20);
            this.txtProducto.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "Código:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 87;
            this.label10.Text = "Costo Neto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "Producto:";
            // 
            // txtCoeficiente
            // 
            this.txtCoeficiente.Location = new System.Drawing.Point(460, 61);
            this.txtCoeficiente.Name = "txtCoeficiente";
            this.txtCoeficiente.Size = new System.Drawing.Size(100, 20);
            this.txtCoeficiente.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Cantidad:";
            // 
            // txtMetros
            // 
            this.txtMetros.Location = new System.Drawing.Point(354, 61);
            this.txtMetros.Name = "txtMetros";
            this.txtMetros.Size = new System.Drawing.Size(100, 20);
            this.txtMetros.TabIndex = 84;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 75;
            this.label6.Text = "Costo:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.SeaShell;
            this.txtCodigo.Location = new System.Drawing.Point(87, 35);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 76;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // ckbCosto
            // 
            this.ckbCosto.AutoSize = true;
            this.ckbCosto.Location = new System.Drawing.Point(193, 106);
            this.ckbCosto.Name = "ckbCosto";
            this.ckbCosto.Size = new System.Drawing.Size(15, 14);
            this.ckbCosto.TabIndex = 82;
            this.ckbCosto.UseVisualStyleBackColor = true;
            this.ckbCosto.CheckedChanged += new System.EventHandler(this.ckbCosto_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::REAL.Properties.Resources.search;
            this.btnBuscar.Location = new System.Drawing.Point(193, 32);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(38, 23);
            this.btnBuscar.TabIndex = 77;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(87, 81);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(100, 20);
            this.txtCosto.TabIndex = 80;
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
            this.detalle_id,
            this.producto_id,
            this.Column1,
            this.Column2,
            this.odcimporteunit,
            this.ocdcantidad,
            this.Column6,
            this.metros,
            this.metros3_totales,
            this.deposito_id,
            this.eliminar});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetalle.Location = new System.Drawing.Point(12, 167);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(880, 253);
            this.dgvDetalle.TabIndex = 103;
            this.dgvDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellClick);
            this.dgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEndEdit);
            this.dgvDetalle.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellValidated);
            this.dgvDetalle.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDetalle_CellValidating);
            this.dgvDetalle.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellValueChanged);
            this.dgvDetalle.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetalle_EditingControlShowing);
            this.dgvDetalle.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDetalle_RowValidating);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.cmbProveedor);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtIdOrden);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 149);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proveedor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Location = new System.Drawing.Point(15, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 69);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(15, 35);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(177, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Fecha";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(19, 42);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(230, 21);
            this.cmbProveedor.TabIndex = 1;
            this.cmbProveedor.SelectionChangeCommitted += new System.EventHandler(this.cmbProveedor_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razón Social:";
            // 
            // txtIdOrden
            // 
            this.txtIdOrden.Location = new System.Drawing.Point(157, 16);
            this.txtIdOrden.Name = "txtIdOrden";
            this.txtIdOrden.Size = new System.Drawing.Size(100, 20);
            this.txtIdOrden.TabIndex = 59;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::REAL.Properties.Resources.back_icon_16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(768, 523);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(124, 38);
            this.btnCancelar.TabIndex = 105;
            this.btnCancelar.Text = "&Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Image = global::REAL.Properties.Resources.save;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(12, 523);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(124, 38);
            this.btnRegistrar.TabIndex = 104;
            this.btnRegistrar.Text = "&Guardar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // detalle_id
            // 
            dataGridViewCellStyle1.NullValue = "0";
            this.detalle_id.DefaultCellStyle = dataGridViewCellStyle1;
            this.detalle_id.HeaderText = "Detalle Id";
            this.detalle_id.Name = "detalle_id";
            this.detalle_id.Visible = false;
            this.detalle_id.Width = 77;
            // 
            // producto_id
            // 
            dataGridViewCellStyle2.NullValue = "0";
            this.producto_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.producto_id.HeaderText = "Producto Id";
            this.producto_id.Name = "producto_id";
            this.producto_id.Visible = false;
            this.producto_id.Width = 87;
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
            // odcimporteunit
            // 
            dataGridViewCellStyle3.NullValue = "0.00";
            this.odcimporteunit.DefaultCellStyle = dataGridViewCellStyle3;
            this.odcimporteunit.HeaderText = "Costo";
            this.odcimporteunit.Name = "odcimporteunit";
            this.odcimporteunit.Width = 59;
            // 
            // ocdcantidad
            // 
            dataGridViewCellStyle4.NullValue = "0";
            this.ocdcantidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.ocdcantidad.HeaderText = "Cant.";
            this.ocdcantidad.Name = "ocdcantidad";
            this.ocdcantidad.Width = 57;
            // 
            // Column6
            // 
            dataGridViewCellStyle5.NullValue = "0.00";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column6.HeaderText = "Total";
            this.Column6.Name = "Column6";
            this.Column6.Width = 56;
            // 
            // metros
            // 
            dataGridViewCellStyle6.NullValue = "0.00";
            this.metros.DefaultCellStyle = dataGridViewCellStyle6;
            this.metros.HeaderText = "m3.";
            this.metros.Name = "metros";
            this.metros.Visible = false;
            this.metros.Width = 49;
            // 
            // metros3_totales
            // 
            dataGridViewCellStyle7.NullValue = "0.00";
            this.metros3_totales.DefaultCellStyle = dataGridViewCellStyle7;
            this.metros3_totales.HeaderText = "m3 Tot.";
            this.metros3_totales.Name = "metros3_totales";
            this.metros3_totales.Width = 68;
            // 
            // deposito_id
            // 
            this.deposito_id.HeaderText = "Deposito";
            this.deposito_id.Name = "deposito_id";
            this.deposito_id.Width = 55;
            // 
            // eliminar
            // 
            this.eliminar.HeaderText = "Eliminar";
            this.eliminar.Name = "eliminar";
            this.eliminar.Text = "Eliminar";
            this.eliminar.UseColumnTextForButtonValue = true;
            this.eliminar.Width = 49;
            // 
            // frmOrdenCompraTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(904, 572);
            this.Controls.Add(this.txtOrden);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmOrdenCompraTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOrdenCompraTest";
            this.Load += new System.EventHandler(this.frmOrdenCompraTest_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrdenCompraTest_KeyDown);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOrden;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblIngBrutos;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMetros;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCostoNeto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCoeficiente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMetros;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.CheckBox ckbCosto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdOrden;
        private System.Windows.Forms.ErrorProvider error;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalle_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn odcimporteunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ocdcantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn metros;
        private System.Windows.Forms.DataGridViewTextBoxColumn metros3_totales;
        private System.Windows.Forms.DataGridViewComboBoxColumn deposito_id;
        private System.Windows.Forms.DataGridViewButtonColumn eliminar;
    }
}