﻿namespace REAL
{
    partial class frmAdministrarEntregas
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEntregas = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.ckbFecha = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.ckbNumero = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_remito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barrio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_entrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.confirmar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.anular = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::REAL.Properties.Resources.search;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(645, 35);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(81, 31);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fecha Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(87, 33);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(115, 20);
            this.dtpHasta.TabIndex = 8;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(87, 11);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(115, 20);
            this.dtpDesde.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha Desde:";
            // 
            // dgvEntregas
            // 
            this.dgvEntregas.AllowUserToAddRows = false;
            this.dgvEntregas.AllowUserToDeleteRows = false;
            this.dgvEntregas.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvEntregas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEntregas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntregas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.numero_remito,
            this.fecha,
            this.barrio,
            this.sucursal,
            this.cargo,
            this.costo,
            this.tipo_entrega,
            this.estado,
            this.modificar,
            this.confirmar,
            this.anular});
            this.dgvEntregas.Location = new System.Drawing.Point(7, 95);
            this.dgvEntregas.Name = "dgvEntregas";
            this.dgvEntregas.ReadOnly = true;
            this.dgvEntregas.RowHeadersVisible = false;
            this.dgvEntregas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntregas.Size = new System.Drawing.Size(1007, 430);
            this.dgvEntregas.TabIndex = 11;
            this.dgvEntregas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntregas_CellClick);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Image = global::REAL.Properties.Resources.back_icon_16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(918, 531);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(96, 37);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // ckbFecha
            // 
            this.ckbFecha.AutoSize = true;
            this.ckbFecha.Location = new System.Drawing.Point(249, 22);
            this.ckbFecha.Name = "ckbFecha";
            this.ckbFecha.Size = new System.Drawing.Size(15, 14);
            this.ckbFecha.TabIndex = 13;
            this.ckbFecha.UseVisualStyleBackColor = true;
            this.ckbFecha.CheckedChanged += new System.EventHandler(this.ckbFecha_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "N° Remito:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(420, 22);
            this.txtNumero.MaxLength = 8;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 15;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // ckbNumero
            // 
            this.ckbNumero.AutoSize = true;
            this.ckbNumero.Location = new System.Drawing.Point(526, 25);
            this.ckbNumero.Name = "ckbNumero";
            this.ckbNumero.Size = new System.Drawing.Size(15, 14);
            this.ckbNumero.TabIndex = 16;
            this.ckbNumero.UseVisualStyleBackColor = true;
            this.ckbNumero.CheckedChanged += new System.EventHandler(this.ckbNumero_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.ckbNumero);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ckbFecha);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1007, 77);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpHasta);
            this.groupBox2.Controls.Add(this.dtpDesde);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(19, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 57);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // numero_remito
            // 
            this.numero_remito.HeaderText = "Nro. Remito";
            this.numero_remito.Name = "numero_remito";
            this.numero_remito.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // barrio
            // 
            this.barrio.HeaderText = "Barrio";
            this.barrio.Name = "barrio";
            this.barrio.ReadOnly = true;
            // 
            // sucursal
            // 
            this.sucursal.HeaderText = "Sucursal";
            this.sucursal.Name = "sucursal";
            this.sucursal.ReadOnly = true;
            // 
            // cargo
            // 
            this.cargo.HeaderText = "Cargo";
            this.cargo.Name = "cargo";
            this.cargo.ReadOnly = true;
            // 
            // costo
            // 
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            // 
            // tipo_entrega
            // 
            this.tipo_entrega.HeaderText = "Tipo";
            this.tipo_entrega.Name = "tipo_entrega";
            this.tipo_entrega.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // modificar
            // 
            this.modificar.HeaderText = "Modificar";
            this.modificar.Name = "modificar";
            this.modificar.ReadOnly = true;
            this.modificar.Text = "Modificar";
            this.modificar.UseColumnTextForButtonValue = true;
            // 
            // confirmar
            // 
            this.confirmar.HeaderText = "Confirmar";
            this.confirmar.Name = "confirmar";
            this.confirmar.ReadOnly = true;
            this.confirmar.Text = "Confirmar Recepción";
            this.confirmar.UseColumnTextForButtonValue = true;
            // 
            // anular
            // 
            this.anular.HeaderText = "Anular";
            this.anular.Name = "anular";
            this.anular.ReadOnly = true;
            this.anular.Text = "Anular";
            this.anular.UseColumnTextForButtonValue = true;
            // 
            // frmAdministrarEntregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(1026, 581);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvEntregas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAdministrarEntregas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdministrarEntregas";
            this.Load += new System.EventHandler(this.frmAdministrarEntregas_Load);
            this.Resize += new System.EventHandler(this.frmAdministrarEntregas_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEntregas;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.CheckBox ckbFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.CheckBox ckbNumero;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_remito;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn barrio;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_entrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewButtonColumn modificar;
        private System.Windows.Forms.DataGridViewButtonColumn confirmar;
        private System.Windows.Forms.DataGridViewButtonColumn anular;
    }
}