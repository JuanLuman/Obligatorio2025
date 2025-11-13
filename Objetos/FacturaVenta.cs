using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class FacturaVenta
    {
        public string NumeroFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdProyecto { get; set; }
        public DateTime FechaInicio { get; set; }
        public TipoFactura tipo { get; set; }


        public double SubTotal { get; set; }
        public double IVA { get; set; }
        public double IRAE { get; set; }
        public double MontoTotal { get; set; }


        public Cliente cliente;
        public Proyecto proyecto;
        // public List Detalles { get; set; }

        public FacturaVenta()
        {
            FechaInicio = DateTime.Now;


        }










    }
}
