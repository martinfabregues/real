using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace REAL.Utils
{
    public class Imprimir
    {
        public PrintDocument print { get; set; }
        public PrintPreviewDialog printPrev { get; set; }
        


        public void ImprimirTitulo()
        {
           
        }

        public void ImprimirOrdenCompra()
        {
            print = new PrintDocument();
            print.DocumentName = "";

        }


    }
}
