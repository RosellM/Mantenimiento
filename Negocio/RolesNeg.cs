using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Negocio
{
    public class RolesNeg
    {
        public List<roles> listarRoles()
        {
            List<roles> roles = new RolesDat().listarRoles();
            return roles;

        }

        public void nuevoRol(roles rol) 
        {
            new RolesDat().nuevoRol(rol);
        }

        public void eliminarRol(int id) 
        {
            new RolesDat().eliminarRol(id);
        }

        public void modificarRol(roles rol)
        {
            new RolesDat().modificarRol(rol);
        }

        public roles obtenerRolById(int id)
        {
        return new RolesDat().obtenerRolByID(id);
        }

    }
}
