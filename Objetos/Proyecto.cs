using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class Proyecto
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NombreProyecto { get; set; }
        public TipoProyecto tipo { get; set; }
        public double MontoMensual { get; set; }
        public double PrecioFijo { get; set; }
        public DateTime FechaInicio { get; set; }
        public double PresupuestoInicial { get; set; }
        public DateTime FechaFinPlanificada { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoProyecto Estado { get; set; }

        public Proyecto()
        {
            FechaInicio = DateTime.Now;
           
        }

        public override string ToString()
        {
            return base.ToString();
        }























    }




}
