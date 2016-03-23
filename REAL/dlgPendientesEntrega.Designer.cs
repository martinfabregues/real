namespace REAL
{
    partial class dlgPendientesEntrega
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dgvPendientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pendiente_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orden_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orden_detalle_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orden_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orden_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Image = global::REAL.Properties.Resources.ckech_3;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(12, 463);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 33);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dgvPendientes
            // 
            this.dgvPendientes.AllowUserToAddRows = false;
            this.dgvPendientes.AllowUserToDeleteRows = false;
            this.dgvPendientes.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvPendientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pendiente_id,
            this.orden_id,
            this.orden_detalle_id,
            this.producto_id,
            this.orden_numero,
            this.orden_fecha,
            this.producto_codigo,
            this.producto,
            this.cantidad,
            this.importe_unitario,
            this.total,
            this.sucursal});
            this.dgvPendientes.Location = new System.Drawing.Point(0, 73);
            this.dgvPendientes.Name = "dgvPendientes";
            this.dgvPendientes.ReadOnly = true;
            this.dgvPendientes.RowHeadersVisible = false;
            this.dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendientes.Size = new System.Drawing.Size(817, 378);
            this.dgvPendientes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Producto:";
            // 
            // txtProducto
            // 
            this.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProducto.Location = new System.Drawing.Point(85, 23);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(228, 20);
            this.txtProducto.TabIndex = 3;
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::REAL.Properties.Resources.search;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(319, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtProducto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(793, 55);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::REAL.Properties.Resources.delete;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(698, 463);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 33);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pendiente_id
            // 
            this.pendiente_id.HeaderText = "Id";
            this.pendiente_id.Name = "pendiente_id";
            this.pendiente_id.ReadOnly = true;
            this.pendiente_id.Visible = false;
            // 
            // orden_id
            // 
            this.orden_id.HeaderText = "Orden Id";
            this.orden_id.Name = "orden_id";
            this.orden_id.ReadOnly = true;
            this.orden_id.Visible = false;
            // 
            // orden_detalle_id
            // 
            this.orden_detalle_id.HeaderText = "Orden Detalle Id";
            this.orden_detalle_id.Name = "orden_detalle_id";
            this.orden_detalle_id.ReadOnly = true;
            this.orden_detalle_id.Visible = false;
            // 
            // producto_id
            // 
            this.producto_id.HeaderText = "PrdId";
            this.producto_id.Name = "producto_id";
            this.producto_id.ReadOnly = true;
            this.producto_id.Visible = false;
            // 
            // orden_numero
            // 
            this.orden_numero.HeaderText = "Nro. Orden";
            this.orden_numero.Name = "orden_numero";
            this.orden_numero.ReadOnly = true;
            // 
            // orden_fecha
            // 
            this.orden_fecha.HeaderText = "Fecha";
            this.orden_fecha.Name = "orden_fecha";
            this.orden_fecha.ReadOnly = true;
            // 
            // producto_codigo
            // 
            this.producto_codigo.HeaderText = "Cód. Prod.";
            this.producto_codigo.Name = "producto_codigo";
            this.producto_codigo.ReadOnly = true;
            // 
            // producto
            // 
            this.producto.HeaderText = "Producto";
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cant.";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // importe_unitario
            // 
            this.importe_unitario.HeaderText = "Imp. Unit.";
            this.importe_unitario.Name = "importe_unitario";
            this.importe_unitario.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "Imp. Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // sucursal
            // 
            this.sucursal.HeaderText = "Sucursal";
            this.sucursal.Name = "sucursal";
            this.sucursal.ReadOnly = true;
            // 
            // dlgPendientesEntrega
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(817, 508);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvPendientes);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgPendientesEntrega";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dlgPendientesEntrega";
            this.Load += new System.EventHandler(this.dlgPendientesEntrega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pendiente_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden_detalle_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
    }
}