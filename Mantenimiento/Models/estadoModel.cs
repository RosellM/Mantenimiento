using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Negocio;

namespace Mantenimiento.Models
{
    public class estadoModel
    {
        int exito = 0;
        public int  id{ get; set; }

        [Display(Name = "NOMBRE DEL NUEVO ESTADO")]
        [Required(ErrorMessage="Campos requeridos")]
        public string nombre{ get; set; }
        [Display(Name = "DESCRIPCION DEL NUEVO ESTADO")]
        [Required(ErrorMessage="Campos requeridos")]
        public string descripcion { get; set; }

        public List<estados> listarEstados() 
        {
            return new estadoNeg().listarEstados();
        }

        public void nuevoEstado(estados estado) 
        {
            new estadoNeg().nuevoEstado(estado);
        }

        public void eliminarEstado(int id) 
        {
            exito =  new estadoNeg().eliminarEstado(id);
        }

        public estados obtenerEstadoPorId(int id)
        {
            return new estadoNeg().obtenerEstadoPorId(id);
        }

        public void modificarEstado(estados estado)
        {
            new estadoNeg().modificarEstado(estado);
        }


    }
}