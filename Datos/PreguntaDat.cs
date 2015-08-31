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
            
                return new bdscecEntities().pregunta.ToList();
            
        }

        public void nuevopregunta(pregunta pregunta)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {

                try
                {
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
                getpregunta.id_test = pregunta.id_test;
                getpregunta.pregunta1 = pregunta.pregunta1;

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
