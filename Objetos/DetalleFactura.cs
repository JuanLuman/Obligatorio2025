using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class DetalleFactura
    {
        public int IdFactura { get; set; }
        //public int FacturaId { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }

        public DetalleFactura() { }

        public DetalleFactura(string descripcion, decimal monto)
        {
            Descripcion = descripcion;
            Monto = (double)monto;
        }










    }
}
