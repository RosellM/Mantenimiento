using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using Negocio;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Mantenimiento.Models
{
    public class personasModel
    {

        public int id { get; set; }

        [Required(ErrorMessage="Campo requerido")]
        [Display(Name = "Ciudad")]
        public int idCiudad { get; set; }

         [Required(ErrorMessage = "Campo requerido")]
         [Display(Name = "Nombre(s)")]
        public string Nombres { get; set; }

        [Display(Name = "Apellidos")]
         [Required(ErrorMessage = "Campo requerido")]
        public string Apellidos { get; set; }

         [Required(ErrorMessage = "Campo requerido")]
         [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        public List<personas> listarPersonas()
        {
            return new personasNeg().listarPersonas();
        }

        public List<ciudad> listarCiudad() 
        {
            return new ciudadModel().listarCiudad();
        }

        public IEnumerable<SelectListItem> ciudades()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var i in new ciudadModel().listarCiudad())
            {
                listItems.Add(new SelectListItem
                {
                    Text = i.nombre,
                    Value = i.id.ToString()
                });
            }

            return listItems;

        }


        public void nuevaPersona( personas persona)
        {
            new personasNeg().NuevaPersona(persona);
        }


        public personas obtenerPersonaPorID(int id) 
        {
          return new personasNeg().obternerPersonasPorID(id);
        }

        public void modificarPersonas(personas personas) 
        {
            new personasNeg().modificarPersonas(personas);
        }

        public void eliminarPersonas(int id)
        {
            new personasNeg().eliminarPersonas(id);
        }


    }
}