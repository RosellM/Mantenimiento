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
   public class PreguntaDat
    {

        public List<pregunta> listarpregunta()
        {

            var bd = new bdscecEntities();

            List<pregunta> preguntas = (from s in bd.pregunta orderby s.seccion.id_test select s).ToList();

            return preguntas;
            
        }

        public void nuevopregunta(pregunta pregunta)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
               
                try
                {
                    resultado resultado = new resultado();
                    resultado.descripcion = pregunta.respuesta;
                    bd.resultado.Add(resultado);
                    bd.pregunta.Add(pregunta);
                    bd.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    throw e;
                }

            }
        }

        public void modificarpregunta(pregunta pregunta)
        {
            pregunta getpregunta;
            using (var ctx = new bdscecEntities())
            {
                try
                {
                    getpregunta = ctx.pregunta.Where(s => s.id == pregunta.id).FirstOrDefault<pregunta>();
                }
                catch (DbEntityValidationException e)
                {
                    throw e;
                }

            }

            if (getpregunta != null)
            {
                getpregunta.id = pregunta.id;
                getpregunta.id_seccion = pregunta.id_seccion;
                getpregunta.pregunta1 = pregunta.pregunta1;
                getpregunta.respuesta = pregunta.respuesta;

            }


            using (var dbCtx = new bdscecEntities())
            {

                dbCtx.Entry(getpregunta).State = EntityState.Modified;

                dbCtx.SaveChanges();
            }
        }

        public pregunta obtenerpreguntaPorId(int id)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
                pregunta pregunta = (from e in bd.pregunta where e.id == id select e).First();
                return pregunta;
            }
        }

        public void eliminarpregunta(int id)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
                try
                {
                    var preguntaAEliminar = (from e in bd.pregunta where e.id == id select e).First();
                    bd.pregunta.Remove(preguntaAEliminar);
                    bd.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    throw e;
                }
            }
        }


    }
}
