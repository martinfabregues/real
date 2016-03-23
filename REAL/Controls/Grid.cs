using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace REAL.Controls
{
    public partial class Grid : DataGridView
    {
        public Grid()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            EstiloGrid();
        }

        private bool Enter_SiguienteCelda = true;
        private bool CeldaCompleta = false;
        private bool EstiloVisual = false;

        public bool MoveLeftToRight
        {
            get { return Enter_SiguienteCelda; }
            set { Enter_SiguienteCelda = value; }
        }

        public bool SeleccionCeldaCompleta
        {
            get { return CeldaCompleta; }
            set { CeldaCompleta = value; }
        }

        public bool CabeceraVisual
        {
            get { return EstiloVisual; }
            set { EstiloVisual = value; }
        }
     
        private void EstiloGrid()
        {
            //this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //this.BackgroundColor = Color.White;
            //this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //this.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //this.ColumnHeadersHeight = 21;
            //this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //this.GridColor = Color.LightGray;
            //this.MultiSelect = false;
            //this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //this.RowHeadersWidth = 17;

            //DataGridViewCellStyle style = new DataGridViewCellStyle();
            //style.BackColor = Color.WhiteSmoke;
            //style.ForeColor = Color.Black;
            //style.SelectionBackColor = SystemColors.Control;
            //style.SelectionForeColor = Color.Black;

            //this.ColumnHeadersDefaultCellStyle = style;

            //DataGridViewCellStyle styleCell = new DataGridViewCellStyle();
            //styleCell.BackColor = Color.White;
            //styleCell.ForeColor = Color.Black;
            //styleCell.SelectionBackColor = SystemColors.Control;
            //styleCell.SelectionForeColor = Color.Black;

            //this.RowTemplate.DefaultCellStyle = styleCell;

            //this.RowHeadersDefaultCellStyle = style;

            if (SeleccionCeldaCompleta == true)
            {
                this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }

            if (EstiloVisual == true)
            {
                this.EnableHeadersVisualStyles = true;
            }
            else
            {
                this.EnableHeadersVisualStyles = false;
            }


        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Enter_SiguienteCelda == true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    MoverSiguienteCelda();
                }
                else
                {
                    base.OnKeyDown(e);
                }
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        protected void MoverSiguienteCelda()
        {
            int ColumnaActual, FilaActual;

            //get the current indicies of the cell
            ColumnaActual = this.CurrentCell.ColumnIndex;
            FilaActual = this.CurrentCell.RowIndex;

            int colCount = 0;

            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (this.Columns[i].Visible == true)
                {
                    colCount = i; //Get the last visible column.
                }
            }

            if (ColumnaActual == colCount &&
                FilaActual == this.Rows.Count - 1)
            //cell is at the end move it to the first cell of the next row
            {
                this.Rows.Add();
                base.ProcessDataGridViewKey(new KeyEventArgs(Keys.Home));
                base.ProcessDataGridViewKey(new KeyEventArgs(Keys.Down));
            }
            else // move it to the next cell
            {
                base.ProcessDataGridViewKey(new KeyEventArgs(Keys.Right));
            }
        }

    }
}
