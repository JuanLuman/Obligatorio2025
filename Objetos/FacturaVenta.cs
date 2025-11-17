using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Objetos;

namespace Obligatorio2025.Objetos
{
    public class FacturaVenta
    {

        public int NroFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdProyecto { get; set; }
        public DateTime FechaInicio { get; set; }
        public double SubTotal { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }
        public string Descripcion { get; set; }


        // Lista de renglones 
        public List<DetalleFactura> Renglones { get; set; }

        public FacturaVenta()
        {
            Renglones = new List<DetalleFactura>();
        }

        // Método para calcular totales
        public void CalcularTotales()
        { 
            SubTotal = 0;
            foreach (var factura in Renglones)
            {
                SubTotal += factura.Monto;
            }

            IVA = SubTotal * 0.22; 
            Total = SubTotal + IVA;
        }














    }
}
