using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Negocio;
using System.Web.Mvc;

namespace Mantenimiento.Models
{
    public class ciudadModel
    {
        public int id { get; set; }
        public int idEstado { get; set; }
        public string nombreEstado { get; set; }
        [Required(ErrorMessage="Campo requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string descripcion { get; set; }

        public void guardarCiudad(ciudad ciudad)
        {

            new ciudadesNeg().guardarCiudad(ciudad);

        }

        public List<ciudad> listarCiudad() 
        {

            return new ciudadesNeg().listarCiudades();
        }

        public estados obtenerNombreEstado(int idEstado) 
        {
            return new ciudadesNeg().nombreEstado(idEstado);
        }

        public IEnumerable<SelectListItem> estados() 
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var i in new ciudadesNeg().estados()) 
            {
                listItems.Add(new SelectListItem
                {
                    Text = i.nombre,
                    Value = i.id.ToString()
                });
            }

            return listItems;
            
        }
    }
}