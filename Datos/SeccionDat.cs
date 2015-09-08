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

            return new bdscecEntities().seccion.ToList();

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
                getseccion.nombre = seccion.nombre;

            }


            using (var dbCtx = new bdscecEntities())
            {

                dbCtx.Entry(getseccion).State = EntityState.Modified;

                dbCtx.SaveChanges();
            }
        }

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
