namespace REAL
{
    partial class frmEstadisticaAnual
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvEstadistica = new System.Windows.Forms.DataGridView();
            this.cmbAnos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadistica)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(542, 393);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvEstadistica
            // 
            this.dgvEstadistica.AllowUserToAddRows = false;
            this.dgvEstadistica.AllowUserToDeleteRows = false;
            this.dgvEstadistica.AllowUserToOrderColumns = true;
            this.dgvEstadistica.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvEstadistica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEstadistica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadistica.Location = new System.Drawing.Point(12, 87);
            this.dgvEstadistica.Name = "dgvEstadistica";
            this.dgvEstadistica.ReadOnly = true;
            this.dgvEstadistica.RowHeadersVisible = false;
            this.dgvEstadistica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstadistica.Size = new System.Drawing.Size(605, 297);
            this.dgvEstadistica.TabIndex = 1;
            this.dgvEstadistica.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEstadistica_CellFormatting);
            // 
            // cmbAnos
            // 
            this.cmbAnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbAnos.FormattingEnabled = true;
            this.cmbAnos.Location = new System.Drawing.Point(45, 21);
            this.cmbAnos.Name = "cmbAnos";
            this.cmbAnos.Size = new System.Drawing.Size(121, 21);
            this.cmbAnos.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Año:";
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(180, 20);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 4;
            this.btnCargar.Text = "&Buscar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCargar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbAnos);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 49);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(629, 23);
            this.lblTitulo.TabIndex = 41;
            this.lblTitulo.Text = "Estadística de Entregas Anual";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEstadisticaAnual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(629, 422);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvEstadistica);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEstadisticaAnual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEstadisticaAnual";
            this.Load += new System.EventHandler(this.frmEstadisticaAnual_Load);
            this.Resize += new System.EventHandler(this.frmEstadisticaAnual_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadistica)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvEstadistica;
        private System.Windows.Forms.ComboBox cmbAnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitulo;
    }
}