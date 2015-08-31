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
            p.id_test = pregunta.id_test;
            p.pregunta1 = pregunta.pregunta1;
            new PreguntaModel().NuevaPregunta(p);
            return View("Index", new PreguntaModel());

        }

        public ActionResult modificarPregunta(int id) 
        {
            pregunta pregunta = new PreguntaModel().obtenerPreguntaPorId(id);
            PreguntaModel pm = new PreguntaModel();
            pm.pregunta1 = pregunta.pregunta1;
            pm.id_test = pregunta.id_test;
            pm.id = pregunta.id;
            return View(pm);
        }

        [HttpPost]
        public ActionResult modificarPregunta(PreguntaModel pregunta) 
        {
            new PreguntaModel().modificarPregunta(pregunta);
            return View("Index",new PreguntaModel());
        }

        public ActionResult eliminarPregunta(int id) 
        {
            new PreguntaModel().eliminarPregunta(id);
            return RedirectToAction("Index", "Pregunta", new PreguntaModel());

           // return View("Index", new PreguntaModel());
        }
            
    }
}
