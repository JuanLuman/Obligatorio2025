using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Obligatorio2025.Objetos.EnumeradosProyecto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Objetos
{
    public class Proyecto
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NombreProyecto { get; set; }
        public TipoProyecto Tipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public double PresupuestoInicial { get; set; }
        public DateTime FechaFinPlanificada { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoProyecto Estado { get; set; }

        public Proyecto() { }
      

        public Proyecto(int clienteId, string nombre, TipoProyecto tipo,
                     double presupuesto, DateTime fechaInicio)
        {
            IdCliente = clienteId;
            NombreProyecto = nombre;
            Tipo = tipo;
            PresupuestoInicial = presupuesto;
            FechaInicio = fechaInicio;
            Estado = EstadoProyecto.Planificado;
        }

        public static implicit operator Proyecto(Proyecto v)
        {
            throw new NotImplementedException();
        }
    }
}





