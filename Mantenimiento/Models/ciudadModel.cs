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
        public ciudadModel(int id,int idEstado,String nombre, String descripcion)
        {
            this.id = id;
            this.idEstado = idEstado;
            this.nombre = nombre;
            this.descripcion = descripcion;
        
        }

        public ciudadModel() { }

        public estados state { get; set; }
        public int id { get; set; }
        
        [Required(ErrorMessage = "Campo requerido")]
        public int idEstado { get; set; }
        public string nombreEstado { get; set; }
        [Required(ErrorMessage="Campo requerido")]
        [Display(Name="Nombre de la ciudad")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Descripcion")]
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

        public ciudad obtenerCiudadPorId(int id)
        {
           return new ciudadesNeg().obtenerCiudadPorID(id);
        }

        public void modificarCiudad(ciudadModel ciudad)
        {
            ciudad cd = new ciudad();
            cd.id = ciudad.id;
            cd.idEstado = ciudad.idEstado;
            cd.nombre = ciudad.nombre;
            cd.descripcion = ciudad.descripcion;

            new ciudadesNeg().modificarCiudad(cd);
        }

        public void eliminarEstado(int id)
        {
            new ciudadesNeg().eliminarCiudads(id);
        }

        public string obtenerNombreEstadoPorIdciudad(int id)
        {
            return new ciudadesNeg().obtenerEstadoPorIdCiudad(id);
        }
    }
}