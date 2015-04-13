namespace REAL
{
    partial class frmPreciosActualizacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.cmbLista = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.listaprecioproducto_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listaprecio_denominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prddenominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listaprecioproducto_costobruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listaprecioproducto_costoneto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listaprecioproducto_precioventa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.listaprecioproducto_id,
            this.listaprecio_denominacion,
            this.prddenominacion,
            this.listaprecioproducto_costobruto,
            this.listaprecioproducto_costoneto,
            this.listaprecioproducto_precioventa});
            this.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvDetalle.Location = new System.Drawing.Point(12, 97);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(675, 391);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetalle_EditingControlShowing);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cmbLista);
            this.groupBox1.Controls.Add(this.cmbProveedor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lista de Precio:";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(115, 19);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(235, 21);
            this.cmbProveedor.TabIndex = 2;
            this.cmbProveedor.SelectionChangeCommitted += new System.EventHandler(this.cmbProveedor_SelectionChangeCommitted);
            // 
            // cmbLista
            // 
            this.cmbLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLista.FormattingEnabled = true;
            this.cmbLista.Location = new System.Drawing.Point(115, 45);
            this.cmbLista.Name = "cmbLista";
            this.cmbLista.Size = new System.Drawing.Size(235, 21);
            this.cmbLista.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(410, 43);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // listaprecioproducto_id
            // 
            this.listaprecioproducto_id.HeaderText = "Column1";
            this.listaprecioproducto_id.Name = "listaprecioproducto_id";
            // 
            // listaprecio_denominacion
            // 
            this.listaprecio_denominacion.HeaderText = "Column2";
            this.listaprecio_denominacion.Name = "listaprecio_denominacion";
            // 
            // prddenominacion
            // 
            this.prddenominacion.HeaderText = "Column3";
            this.prddenominacion.Name = "prddenominacion";
            // 
            // listaprecioproducto_costobruto
            // 
            this.listaprecioproducto_costobruto.HeaderText = "Column4";
            this.listaprecioproducto_costobruto.Name = "listaprecioproducto_costobruto";
            // 
            // listaprecioproducto_costoneto
            // 
            this.listaprecioproducto_costoneto.HeaderText = "Column5";
            this.listaprecioproducto_costoneto.Name = "listaprecioproducto_costoneto";
            // 
            // listaprecioproducto_precioventa
            // 
            this.listaprecioproducto_precioventa.HeaderText = "Column6";
            this.listaprecioproducto_precioventa.Name = "listaprecioproducto_precioventa";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(529, 497);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(158, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "&Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // frmPreciosActualizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 532);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDetalle);
            this.Name = "frmPreciosActualizacion";
            this.Text = "frmPreciosActualizacion";
            this.Load += new System.EventHandler(this.frmPreciosActualizacion_Load);
            this.Resize += new System.EventHandler(this.frmPreciosActualizacion_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbLista;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn listaprecioproducto_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn listaprecio_denominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn prddenominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn listaprecioproducto_costobruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn listaprecioproducto_costoneto;
        private System.Windows.Forms.DataGridViewTextBoxColumn listaprecioproducto_precioventa;
        private System.Windows.Forms.Button btnActualizar;
    }
}