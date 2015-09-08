using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Entidades;
using Negocio;
using System.Web.Mvc;
namespace Mantenimiento.Models
{
    public class SeccionModel
    {

        public int id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Elija el test")]
        public int id_test { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Nombre de la seccion")]
        public string nombre { get; set; }


        public void NuevaSeccion(seccion seccion)
        {
            new SeccionNeg().nuevoseccion(seccion);
        }


        public List<seccion> listarSeccion()
        {
            return new SeccionNeg().listarseccion();
        }

        public IEnumerable<SelectListItem> listarTest()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var i in new TestNeg().listarTest())
            {
                listItems.Add(new SelectListItem
                {
                    Text = i.nombre,
                    Value = i.id.ToString()
                });
            }

            return listItems;

        }

        public seccion obtenerSeccionPorId(int id)
        {
            return new SeccionNeg().obtenerseccionPorID(id);
        }

        public void modificarSeccion(SeccionModel seccion)
        {
            seccion s = new seccion();
            s.id = seccion.id;
            s.id_test =seccion.id_test;
            s.nombre = seccion.nombre;
            new SeccionNeg().modificarseccion(s);

        }

        public void eliminarSeccion(int id)
        {
            new SeccionNeg().eliminarseccion(id);
        }


    }
}