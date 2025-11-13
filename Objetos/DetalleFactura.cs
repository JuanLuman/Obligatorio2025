using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public double Monto { get; set; }

        public DetalleFactura() { }

        public DetalleFactura(string descripcion, double monto)
        {
            this.Descripcion = descripcion;
            this.Monto = monto;
        }


        public override string ToString()
        {
            return $"{Descripcion} - ${Monto}";

        }










    }
}
