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
   public class SeccionDat
    {

        public List<seccion> listarseccion()
        {

            var bd = new bdscecEntities();

            List<seccion> secciones = (from s in bd.seccion orderby s.id_test select s).ToList();

            return secciones;

            

        }

        public List<seccion> listarSeccionPorIdTest(int id_test)
        {

            using (bdscecEntities bd = new bdscecEntities())
            {
                return (from e in bd.seccion where e.id_test == id_test select e).ToList();
                
            }
        }

        public void nuevoseccion(seccion seccion)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {

                try
                {
                    bd.seccion.Add(seccion);
                    bd.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    throw e;
                }

            }
        }

        public void modificarseccion(seccion seccion)
        {
            seccion getseccion;
            using (var ctx = new bdscecEntities())
            {
                try
                {
                    getseccion = ctx.seccion.Where(s => s.id == seccion.id).FirstOrDefault<seccion>();
                }
                catch (DbEntityValidationException e)
                {
                    throw e;
                }

            }

            if (getseccion != null)
            {
                getseccion.id = seccion.id;
                getseccion.id_test = seccion.id_test;
                getseccion.status = seccion.status;

            }


            using (var dbCtx = new bdscecEntities())
            {

                dbCtx.Entry(getseccion).State = EntityState.Modified;

                dbCtx.SaveChanges();
            }
        }


        public void eliminarRelacionSeccionPregunta(int id_seccion) 
        { 
        
            using(bdscecEntities bd = new bdscecEntities())
            {

                List<pregunta> preguntas = (from p in bd.pregunta where p.id_seccion == id_seccion select p).ToList();
                foreach(var pregunta in preguntas)
                {

                    bd.pregunta.Remove(pregunta);
                    bd.SaveChanges();

                }
            
            }

        
        }


       //agregar id test
        public seccion obtenerseccionPorId(int id)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
                seccion seccion = (from e in bd.seccion where e.id == id select e).First();
                return seccion;
            }
        }

        public void eliminarseccion(int id)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
                try
                {
                    var seccionAEliminar = (from e in bd.seccion where e.id == id select e).First();
                    this.eliminarRelacionSeccionPregunta(seccionAEliminar.id);
                    bd.seccion.Remove(seccionAEliminar);
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
