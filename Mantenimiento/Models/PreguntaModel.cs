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
    public class PreguntaModel
    {

        public int id { get; set; }

        [Required(ErrorMessage="Campo requerido")]
        [Display(Name="Elija el test")]
        public int id_test { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name="Escriba la pregunta")]
        public string pregunta1 { get; set; }


        public void NuevaPregunta(pregunta pregunta) 
        {
            new PreguntaNeg().nuevoPregunta(pregunta);
        }


        public List<pregunta> listarPregunta()
        {
            return new PreguntaNeg().listarPregunta();
        }

        public IEnumerable<SelectListItem> listaTest()
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

        public pregunta obtenerPreguntaPorId(int id) 
        {
            return new PreguntaNeg().obtenerPreguntaPorID(id);
        }

        public void modificarPregunta(PreguntaModel pregunta)
        {
            pregunta p = new pregunta();
            p.id = pregunta.id;
            p.id_test = pregunta.id_test;
            p.pregunta1 = pregunta.pregunta1;
            new PreguntaNeg().modificarPregunta(p);

        }

        public void eliminarPregunta( int id )
        {
            new PreguntaNeg().eliminarPregunta(id);
        }

    }
}