namespace REAL
{
    partial class frmVentasRegistradas
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvRemitos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.IndianRed;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(943, 20);
            this.lblTitulo.TabIndex = 118;
            this.lblTitulo.Text = "VENTAS REGISTRADAS";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvRemitos
            // 
            this.dgvRemitos.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvRemitos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRemitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemitos.Location = new System.Drawing.Point(12, 110);
            this.dgvRemitos.Name = "dgvRemitos";
            this.dgvRemitos.RowHeadersVisible = false;
            this.dgvRemitos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRemitos.Size = new System.Drawing.Size(919, 501);
            this.dgvRemitos.TabIndex = 119;
            this.dgvRemitos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemitos_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 69);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // frmVentasRegistradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 621);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvRemitos);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmVentasRegistradas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVentasRegistradas";
            this.Load += new System.EventHandler(this.frmVentasRegistradas_Load);
            this.Resize += new System.EventHandler(this.frmVentasRegistradas_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvRemitos;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}