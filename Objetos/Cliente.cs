using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;


namespace Objetos
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public String RazonSocial { get; set; }
        public String RUT { get; set; }
        public String Direccion { get; set; }

        public Cliente() { }

        public Cliente(String razonsocial, String rut, String direccion)
        {
            this.RazonSocial = razonsocial;
            this.RUT = rut;
            this.Direccion = direccion;
        }



        public override String ToString()
        {
            return $"{RazonSocial} - {RUT}";
        }









    }
}
