using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using Negocio;
using System.ComponentModel.DataAnnotations;
namespace Mantenimiento.Models
{
    public class RolModel
    {
        [Display(Name="NOMBRE DEL NUEVO ROL")]
        [Required]
        public string nombre { get; set; }


        [Display(Name = "DESCRIPCION DEL NUEVO ROL")]
        [Required]
        public string descripcion { get; set; }


        public List<roles> listarRoles ()
        {
            return new RolesNeg().listarRoles();
        }

        public void nuevoRol(roles rol) 
        {
            new RolesNeg().nuevoRol(rol);
        }

        public void eliminarRol(int id) 
        {

            new RolesNeg().eliminarRol(id);

        }

    }
}