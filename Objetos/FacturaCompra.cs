using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2025.Objetos
{
    public class FacturaCompra
    {

        public int NroFactura { get; set; }
        public string ProveedorRazonSocial { get; set; }
        public string ProveedorRUT { get; set; }
        public string ProveedorDireccion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }

        public FacturaCompra() { }


   











    }
}
