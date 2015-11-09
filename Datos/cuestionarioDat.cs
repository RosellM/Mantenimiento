using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity.Validation;
using System.Data.Entity;
namespace Datos
{
    public class cuestionarioDat
    {

        public List<seccion> ListarSecciones() 
        {
            return new bdscecEntities().seccion.ToList();
        }


        public List<seccion> ListarSecciones(int idTst)
        {
            string resuelto = "nr";
            using (bdscecEntities bd = new bdscecEntities())
            {
                return (from e in bd.seccion where e.id_test == idTst && e.status == resuelto select e).ToList();

            }
        }

        public List<test> ListarTest() 
        {
            return new bdscecEntities().test.ToList();
        }
        /*
         * Si es cuestionario ya fue resuelto, deactivar la opcion de resolver ese test.
         *  Que el usuario agrege el numero de reactivos y sus respectivas opciones
         */
        public List<pregunta> obtenerCuestionarios(int id_seccion) 
        {
            List<cuestionarioEntidad> cuestionariosEntidad = new List<cuestionarioEntidad>();
            bdscecEntities bd = new bdscecEntities();
            List<pregunta> cuestionarios = (from p in bd.pregunta where p.id_seccion == id_seccion select p).ToList();
            return cuestionarios;
        }


        public pregunta obtenerRespuestasCuestionario(int idPregunta)
        {
                bdscecEntities bd = new bdscecEntities();
                pregunta pregunta = (from p in bd.pregunta where p.id == idPregunta select p).FirstOrDefault() ;

                return pregunta;
        }

        public void persistirResultado(string[] ids_pregunta, string[] respuesta)
        {
            bdscecEntities bd = new bdscecEntities();
           
            List<resultado> res = new List<resultado>();
            
            for (int ix = 0; ix < ids_pregunta.Count(); ix++)
            {
                resultado resultado = new resultado();
                resultado.idPregunta = Int32.Parse(ids_pregunta[ix]);
                resultado.resultado_seleccionado = respuesta[ix];
                res.Add(resultado);

            }

            foreach(resultado re in res)
            {
                bd.resultado.Add(re);
                bd.SaveChanges();
            }


           
        }

        public void actualizarStatusSeccion(int idSeccion)
        {
            seccion getseccion;
            using (var ctx = new bdscecEntities())
            {
                try
                {
                    getseccion = ctx.seccion.Where(s => s.id == idSeccion).FirstOrDefault<seccion>();
                }
                catch (DbEntityValidationException e)
                {
                    throw e;
                }

            }

            if (getseccion != null)
            {
                getseccion.status = "sr";

            }


            using (var dbCtx = new bdscecEntities())
            {

                dbCtx.Entry(getseccion).State = EntityState.Modified;

                dbCtx.SaveChanges();
            }
        }
        
    }
}

