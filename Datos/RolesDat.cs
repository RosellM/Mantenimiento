using Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace Datos
{
    public class RolesDat
    {
        public List<roles> listarRoles()
        {

            using (bdscecEntities bd = new bdscecEntities())
            {
                List<roles> roles = bd.roles.ToList();
                return roles;
            }
        }

        public void nuevoRol(roles rol)
        {

            using (bdscecEntities bd = new bdscecEntities())
            {

                try {
                
                  bd.roles.Add(rol);
                bd.SaveChanges();
                }
                catch (DbEntityValidationException e )
                {

                    return;
                }
              
            }

           
        
        }

        public void eliminarRol(int id) 
        {

            using (bdscecEntities bd = new bdscecEntities()) 
            {

                try
                {
                    var rolAeliminar = (from r in bd.roles where r.id == id select r).First();
                    bd.roles.Remove(rolAeliminar);
                    bd.SaveChanges();
                }
                catch (DbEntityValidationException e) {
                    throw e;
                }
            
            }

        }

        public roles obtenerRolByID(int id)
        {
            using (bdscecEntities bd = new bdscecEntities()) 
            {
                try { 
                  var rol = (from r in bd.roles where r.id == id select r).First();
                  return rol;
                
                }
                    catch(DbEntityValidationException e){
                        throw e ;
                }
     
            }
           
        
        }

        public void modificarRol(roles rol)
        {
            try
            {
                roles getRol;
                using (var ctx = new bdscecEntities())
                {
                    try {
                        getRol = ctx.roles.Where(s => s.id == rol.id).FirstOrDefault<roles>();
                    }
                    catch (DbEntityValidationException e) 
                    
                    {
                        throw e;
                    }
               
                }

                if (getRol != null)
                {
                    getRol.nombre = rol.nombre;
                    getRol.descripcion = rol.descripcion;
                }

                
                using (var dbCtx = new bdscecEntities())
                {

                    dbCtx.Entry(getRol).State = EntityState.Modified;

                    dbCtx.SaveChanges();
                }
            }
            catch (DbEntityValidationException e) 
            {
                throw e;
            }
        }

    }
}
