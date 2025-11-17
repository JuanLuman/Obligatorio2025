using Objetos;
using Obligatorio.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio2025.Datos;
using System.Data;

namespace Logica
{
    public class LogicaProyecto
    {
        Proyecto proyecto = new Proyecto();
        ProyectoDatos proyectodatos = new ProyectoDatos();
        ClienteDatos clientedato = new ClienteDatos();

        //metodo para agregar proyecto

        public String AgregarProyecto(Proyecto proyecto)
        {

            if (string.IsNullOrWhiteSpace(proyecto.NombreProyecto))
                throw new Exception("El nombre del proyecto es obligatorio");

            if (proyecto.PresupuestoInicial <= 0)
                throw new Exception("El presupuesto debe ser mayor a cero");

            
            if (proyecto.FechaInicio == DateTime.MinValue)
                throw new Exception("Debe especificar una fecha de inicio");
            try
            {
                
                proyectodatos.IngresarProyecto(proyecto);
                return "Proyecto agregado con exito";
            }
            catch (Exception ex)
            {
                return "Error al agregar proyecto: " + ex.Message;
            }
        }




        public String EliminarProyecto(int idProyecto)
        {
            try
            {
                proyectodatos.EliminarProyecto(idProyecto);
                return "Proyecto eliminado con exito";
            }
            catch (Exception ex)
            {
                return "Error al eliminar proyecto: " + ex.Message;
            }
        }





        public List<Proyecto> ListarProyecto()
        {
            ProyectoDatos proyecto = new ProyectoDatos();
            try
            {
                return proyecto.ListarProyectos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en listar proyecto " + ex.Message);
            }
        }







    }
}
