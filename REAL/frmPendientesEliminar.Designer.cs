﻿namespace REAL
{
    partial class frmPendientesEliminar
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
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.numero_orden,
            this.fecha,
            this.proveedor,
            this.producto_codigo,
            this.descripcion,
            this.cantidad,
            this.importe,
            this.total,
            this.sucursal,
            this.btnEliminar});
            this.dgvDetalle.Location = new System.Drawing.Point(12, 112);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(954, 397);
            this.dgvDetalle.TabIndex = 119;
            this.dgvDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtProducto);
            this.groupBox1.Controls.Add(this.cmbSucursal);
            this.groupBox1.Controls.Add(this.cmbProveedor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 94);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(436, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 29);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtProducto
            // 
            this.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProducto.Location = new System.Drawing.Point(79, 66);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(317, 20);
            this.txtProducto.TabIndex = 5;
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new System.Drawing.Point(79, 43);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(232, 21);
            this.cmbSucursal.TabIndex = 4;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(79, 19);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(232, 21);
            this.cmbProveedor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sucursal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Producto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor:";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(872, 515);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(94, 34);
            this.btnSalir.TabIndex = 121;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // numero_orden
            // 
            this.numero_orden.HeaderText = "N° N.P";
            this.numero_orden.Name = "numero_orden";
            this.numero_orden.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // proveedor
            // 
            this.proveedor.HeaderText = "Proveedor";
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            // 
            // producto_codigo
            // 
            this.producto_codigo.HeaderText = "Código";
            this.producto_codigo.Name = "producto_codigo";
            this.producto_codigo.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cant.";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // importe
            // 
            this.importe.HeaderText = "Importe Unit.";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // sucursal
            // 
            this.sucursal.HeaderText = "Sucursal";
            this.sucursal.Name = "sucursal";
            this.sucursal.ReadOnly = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "Eliminar";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseColumnTextForButtonValue = true;
            // 
            // frmPendientesEliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(978, 561);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDetalle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPendientesEliminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPendientesEliminar";
            this.Load += new System.EventHandler(this.frmPendientesEliminar_Load);
            this.Resize += new System.EventHandler(this.frmPendientesEliminar_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.ComboBox cmbSucursal;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
    }
}