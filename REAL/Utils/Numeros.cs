using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REAL.Utils
{
    public class Numeros
    {
        public string AgregarDecimales(string numero)
        {
            try
            {
                if (numero.Contains("."))
                {
                    numero = numero.Replace(".", ",");
                }

                if (numero.Contains(","))
                {
                    switch (numero.Substring(numero.LastIndexOf(",") + 1).Length)
                    {
                        case 0:
                            numero += "00";
                            break;
                        case 1:
                            numero += "0";
                            break;
                        case 2:
                            break;
                        default:
                            numero = numero.Substring(0, (numero.LastIndexOf(",") + 1) + 2);
                            break;
                    }
                }
                else
                {
                    numero += ",00";
                }
            }
            catch
            { }

            return numero;
        }

    }
}
