namespace REAL
{
    partial class frmFormaPago
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblTotalCobro = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTarjeta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCobroRemito = new System.Windows.Forms.DataGridView();
            this.cobroremito_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formapago_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formapago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarjetacredito_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarjetacredito_denominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plan_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plan_denominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cobroremito_importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobroRemito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.txtImporte);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbPlan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbTarjeta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbFormaPago);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(723, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos - Forma Pago";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSaldo);
            this.groupBox2.Controls.Add(this.lblTotalCobro);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblImporte);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(489, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 119);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // lblSaldo
            // 
            this.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaldo.ForeColor = System.Drawing.Color.Red;
            this.lblSaldo.Location = new System.Drawing.Point(91, 71);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Padding = new System.Windows.Forms.Padding(3);
            this.lblSaldo.Size = new System.Drawing.Size(106, 23);
            this.lblSaldo.TabIndex = 11;
            this.lblSaldo.Text = "label9";
            // 
            // lblTotalCobro
            // 
            this.lblTotalCobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCobro.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCobro.Location = new System.Drawing.Point(91, 43);
            this.lblTotalCobro.Name = "lblTotalCobro";
            this.lblTotalCobro.Padding = new System.Windows.Forms.Padding(3);
            this.lblTotalCobro.Size = new System.Drawing.Size(106, 23);
            this.lblTotalCobro.TabIndex = 13;
            this.lblTotalCobro.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Saldo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total Cobros:";
            // 
            // lblImporte
            // 
            this.lblImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImporte.ForeColor = System.Drawing.Color.Red;
            this.lblImporte.Location = new System.Drawing.Point(91, 15);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Padding = new System.Windows.Forms.Padding(3);
            this.lblImporte.Size = new System.Drawing.Size(106, 23);
            this.lblImporte.TabIndex = 10;
            this.lblImporte.Text = "lblImporte";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Importe Total:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(320, 112);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(129, 23);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar v";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(110, 112);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(121, 20);
            this.txtImporte.TabIndex = 7;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Importe:";
            // 
            // cmbPlan
            // 
            this.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(110, 85);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(121, 21);
            this.cmbPlan.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Plan:";
            // 
            // cmbTarjeta
            // 
            this.cmbTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarjeta.FormattingEnabled = true;
            this.cmbTarjeta.Location = new System.Drawing.Point(110, 58);
            this.cmbTarjeta.Name = "cmbTarjeta";
            this.cmbTarjeta.Size = new System.Drawing.Size(207, 21);
            this.cmbTarjeta.TabIndex = 3;
            this.cmbTarjeta.SelectedIndexChanged += new System.EventHandler(this.cmbTarjeta_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tarjeta Credito:";
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Location = new System.Drawing.Point(110, 31);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(207, 21);
            this.cmbFormaPago.TabIndex = 1;
            this.cmbFormaPago.SelectedIndexChanged += new System.EventHandler(this.cmbFormaPago_SelectedIndexChanged);
            this.cmbFormaPago.SelectionChangeCommitted += new System.EventHandler(this.cmbFormaPago_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forma Pago:";
            // 
            // dgvCobroRemito
            // 
            this.dgvCobroRemito.AllowUserToAddRows = false;
            this.dgvCobroRemito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCobroRemito.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvCobroRemito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCobroRemito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCobroRemito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cobroremito_id,
            this.formapago_id,
            this.formapago,
            this.tarjetacredito_id,
            this.tarjetacredito_denominacion,
            this.plan_id,
            this.plan_denominacion,
            this.cobroremito_importe,
            this.eliminar});
            this.dgvCobroRemito.Location = new System.Drawing.Point(12, 175);
            this.dgvCobroRemito.Name = "dgvCobroRemito";
            this.dgvCobroRemito.ReadOnly = true;
            this.dgvCobroRemito.RowHeadersVisible = false;
            this.dgvCobroRemito.Size = new System.Drawing.Size(723, 150);
            this.dgvCobroRemito.TabIndex = 1;
            this.dgvCobroRemito.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobroRemito_CellClick);
            // 
            // cobroremito_id
            // 
            this.cobroremito_id.HeaderText = "Column1";
            this.cobroremito_id.Name = "cobroremito_id";
            this.cobroremito_id.ReadOnly = true;
            this.cobroremito_id.Visible = false;
            // 
            // formapago_id
            // 
            this.formapago_id.HeaderText = "Column1";
            this.formapago_id.Name = "formapago_id";
            this.formapago_id.ReadOnly = true;
            this.formapago_id.Visible = false;
            // 
            // formapago
            // 
            this.formapago.HeaderText = "Forma Pago";
            this.formapago.Name = "formapago";
            this.formapago.ReadOnly = true;
            // 
            // tarjetacredito_id
            // 
            this.tarjetacredito_id.HeaderText = "Column1";
            this.tarjetacredito_id.Name = "tarjetacredito_id";
            this.tarjetacredito_id.ReadOnly = true;
            this.tarjetacredito_id.Visible = false;
            // 
            // tarjetacredito_denominacion
            // 
            this.tarjetacredito_denominacion.HeaderText = "Tarjeta Credito";
            this.tarjetacredito_denominacion.Name = "tarjetacredito_denominacion";
            this.tarjetacredito_denominacion.ReadOnly = true;
            // 
            // plan_id
            // 
            this.plan_id.HeaderText = "Column1";
            this.plan_id.Name = "plan_id";
            this.plan_id.ReadOnly = true;
            this.plan_id.Visible = false;
            // 
            // plan_denominacion
            // 
            this.plan_denominacion.HeaderText = "Plan";
            this.plan_denominacion.Name = "plan_denominacion";
            this.plan_denominacion.ReadOnly = true;
            // 
            // cobroremito_importe
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.cobroremito_importe.DefaultCellStyle = dataGridViewCellStyle1;
            this.cobroremito_importe.HeaderText = "Importe";
            this.cobroremito_importe.Name = "cobroremito_importe";
            this.cobroremito_importe.ReadOnly = true;
            // 
            // eliminar
            // 
            this.eliminar.HeaderText = "Eliminar";
            this.eliminar.Name = "eliminar";
            this.eliminar.ReadOnly = true;
            this.eliminar.Text = "Eliminar";
            this.eliminar.UseColumnTextForButtonValue = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(563, 346);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(644, 346);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.IndianRed;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(747, 20);
            this.lblTitulo.TabIndex = 116;
            this.lblTitulo.Text = "FORMA DE PAGO";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFormaPago
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(747, 392);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvCobroRemito);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFormaPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFormaPago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFormaPago_FormClosing);
            this.Load += new System.EventHandler(this.frmFormaPago_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobroRemito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTarjeta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCobroRemito;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cobroremito_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn formapago_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn formapago;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarjetacredito_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarjetacredito_denominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn plan_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn plan_denominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cobroremito_importe;
        private System.Windows.Forms.DataGridViewButtonColumn eliminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblTotalCobro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTitulo;
    }
}