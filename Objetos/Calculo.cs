using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2025.Objetos
{
    public class Calculo
    {

        public int Año { get; set; }
        public int Mes { get; set; }
        public double TotalVentas { get; set; }
        public double TotalCompras { get; set; }
        public double IVA { get; set; }
        
        public double IRAE { get; set; }
        public DateTime FechaDelCalculo { get; set; }





        public void Calcular (double ventas, double compras)
        {
            TotalVentas = ventas;
            TotalCompras = compras;
            IVA = (ventas * 0.22) - (compras * 0.22); // IVA ventas - IVA compras
            IRAE = ventas * 0.12; // 12% de la facturación
        }






    }
}
