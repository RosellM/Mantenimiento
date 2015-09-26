using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantenimiento.Models;
using Entidades;
namespace Mantenimiento.Controllers
{
    public class PreguntaController : Controller
    {
        //
        // GET: /Pregunta/

        public ActionResult Index()
        {
            return View(new PreguntaModel());
        }

        public ActionResult Nuevo() 
        {

            return View(new PreguntaModel());
        }

        [HttpPost]
        public ActionResult Nuevo(PreguntaModel pregunta) 
        {

            pregunta p = new pregunta();
            p.id_seccion = pregunta.id_seccion;
            p.pregunta1 = pregunta.pregunta1;
            p.respuesta = pregunta.respuesta;
            new PreguntaModel().NuevaPregunta(p);
            return RedirectToAction("Index","Pregunta" ,new PreguntaModel());

        }

        public ActionResult modificarPregunta(int id) 
        {
            pregunta pregunta = new PreguntaModel().obtenerPreguntaPorId(id);
            PreguntaModel pm = new PreguntaModel();
            pm.pregunta1 = pregunta.pregunta1;
            pm.id_seccion = pregunta.id_seccion;
            pm.respuesta = pregunta.respuesta;
            pm.id = pregunta.id;
            return View(pm);
        }

        [HttpPost]
        public ActionResult modificarPregunta(PreguntaModel pregunta) 
        {
            new PreguntaModel().modificarPregunta(pregunta);
            return RedirectToAction("Index","Pregunta",new PreguntaModel());
        }

        public ActionResult eliminarPregunta(int id) 
        {
            new PreguntaModel().eliminarPregunta(id);
            return RedirectToAction("Index", "Pregunta", new PreguntaModel());

           // return View("Index", new PreguntaModel());
        }
            
    }
}
