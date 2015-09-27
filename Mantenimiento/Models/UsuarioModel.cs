using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using Negocio;
using System.ComponentModel.DataAnnotations;
namespace Mantenimiento.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }

        [Display(Name = "Apellido paterno")]
        public string nombreApellidoPaterno { get; set; }

        [Display(Name = "Apellido materno")]
        public string nombreApellidoMaterno { get; set; }

         [Display(Name = "Nombre")]
        public string nombre { get; set; }
        public int idRol { get; set; }
     

        public UsuarioModel() { }
        public UsuarioModel(string nombre, string nombreApellidoMaterno, string nombreApellidoPaterno, int idRol)
        {

            this.nombre = nombre;
            this.idRol = idRol;
            this.nombreApellidoMaterno = nombreApellidoMaterno;
            this.nombreApellidoPaterno = nombreApellidoPaterno;
        
        }
        public roles rol { get; set; }

        public void nuevoUser() 
        {
            usuario user = new usuario();
            user.idRol = this.idRol;
            user.nombre = this.nombre;
            user.nombreApellidoMaterno = this.nombreApellidoMaterno;
            user.nombreApellidoPaterno = this.nombreApellidoPaterno;
            new UsuarioNeg().nuevoUser(user);
            
        }

        public void obtenerRol() 
        {
            rol = new UsuarioNeg().obtenerRol(this.idRol);
        }

        public bool obtenerUsuario(string name) 
        {
            
            usuario user = new UsuarioNeg().obtenerUsuario(name);

            if (user != null) 
            {
                this.rol = new UsuarioNeg().obtenerRol(user.idRol);
                this.nombre = user.nombre;
                this.id = user.id;
                this.nombreApellidoMaterno = user.nombreApellidoMaterno;
                this.nombreApellidoPaterno = user.nombreApellidoPaterno;

                return true;
            
            }


            return false;
            
        
        }

        public void modificarUsuario(usuario usuario)
        {
            new UsuarioNeg().modificarUsuario(usuario);
        }
        
    }
}