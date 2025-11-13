using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class FacturaCompra
    {

        public int NumFactura { get; set; }
        public string RUTPr { get; set; }
        public string RazonSocialPr { get; set; }
        public string DireccionPr { get; set; }


        public double SubTotal { get; set; }
        public double IVA;
        public double MontoTotal;











    }
}
