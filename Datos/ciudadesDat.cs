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
    public class ciudadesDat
    {


        public List<ciudad> listarCiudades()
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
                return bd.ciudad.ToList();
            }
        }

        public void guardarCiudad(ciudad ciudad)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {

                bd.ciudad.Add(ciudad);
                bd.SaveChanges();

            }
        }

        public estados obtenerNombreEstado(int idEstado)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
                estados estado = (from e in bd.estados where e.id == idEstado select e).First();
                return estado;

            }


        }

        public List<estados> estados()
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
                return bd.estados.ToList();
            }

        }

        public ciudad obtenerCiudadPorId(int id)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
                return (from e in bd.ciudad where e.id == id select e).First();
            }
        }

        public void modificarCiudad(ciudad ciudad)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
                ciudad getCiudad;
                using (var ctx = new bdscecEntities())
                {
                    try
                    {
                        getCiudad = ctx.ciudad.Where(s => s.id == ciudad.id).FirstOrDefault<ciudad>();

                        if (getCiudad != null)
                        {
                            getCiudad.nombre = ciudad.nombre;
                            getCiudad.descripcion = ciudad.descripcion;
                            getCiudad.idEstado = ciudad.idEstado;
                            getCiudad.id = ciudad.id;
                        }

                        ctx.Entry(getCiudad).State = EntityState.Modified;

                        ctx.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        throw e;
                    }

                }
            }
        }

        public int eliminarEstado(int id)
        {
            using (bdscecEntities bd = new bdscecEntities())
            {
                try
                {
                    var ciudadAEliminar = (from e in bd.ciudad where e.id == id select e).First();
                    this.eliminarRelacionCiudadPersona(ciudadAEliminar.id);
                    bd.ciudad.Remove(ciudadAEliminar);
                    bd.SaveChanges();
                    return 1;
                }
                catch (DbEntityValidationException e)
                {
                    return 0;
                }
            }


        }

        public bool eliminarRelacionCiudadPersona(int idCiudad)
        {

            using (bdscecEntities bd = new bdscecEntities())
            {
                try
                {
                    List<personas> personaAEliminar = (from e in bd.personas where e.idCiudad == idCiudad select e).ToList();
                    
                    foreach (var persona in personaAEliminar)
                    {
                     bd.personas.Remove(persona);
                    bd.SaveChanges();
                    }

                   
                    return true;
                }
                catch (DbEntityValidationException e)
                {
                    return false;
                }
            }
        
        }
    }
}
