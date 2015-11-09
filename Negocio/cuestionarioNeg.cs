using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Negocio
{
   public class cuestionarioNeg
    {
       private List<String> calificaciones = new List<string>();
        public List<seccion> ListarSecciones()
        {
            return new cuestionarioDat().ListarSecciones();
        }


        public List<seccion> ListarSecciones(int id_Tst)
        {
            return new cuestionarioDat().ListarSecciones(id_Tst);
        }

        public List<test> ListarTest()
        {
            return new cuestionarioDat().ListarTest();
        }

        public List<pregunta> cuestionario(int id_seccion) 
        {
            return new cuestionarioDat().obtenerCuestionarios(id_seccion);
        }

       public List<String> calificarCuestionario(string[] ids_pregunta, string[] respuesta,int id_seccion)
       {

           cuestionarioDat datos = new cuestionarioDat();
           datos.persistirResultado(ids_pregunta, respuesta);
           for (var z = 0; z < ids_pregunta.Count(); z++) 
           {
            pregunta pregunta =    datos.obtenerRespuestasCuestionario(Int32.Parse(ids_pregunta[z]));
               if (pregunta.respuesta == respuesta[z]) 
               {

                   calificaciones.Add("<strong>"+ pregunta.pregunta1 + " Correcta</br></strong>" );
               
               }
               else
               {
                   calificaciones.Add("<strong>" +  pregunta.pregunta1 + " Incorrecta</br><strong>");
               }
           }
           /*actualizar status de seccion*/
           datos.actualizarStatusSeccion(id_seccion);
           return calificaciones;
       }

     

    }
}
