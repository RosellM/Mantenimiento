﻿using System;
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

        public ActionResult Nuevo(int? id) 
        {
            if (id == null)
            {
                PreguntaModel model = new PreguntaModel();
                return View(new PreguntaModel());
            }
            else 
            {
                PreguntaModel model = new PreguntaModel();
                model.id_seccion= (int)id;
                return View(model);
            }
           
        }

        [HttpPost]
        public ActionResult Nuevo(PreguntaModel pregunta) 
        {
            /*
             *agregar r1,r2 y r1 a un array para agregar a su propia entidad
             * 
             */
            List<String> reactivos = new List<String>();
            pregunta p = new pregunta();
            p.id_seccion = pregunta.id_seccion;
            p.pregunta1 = pregunta.pregunta1;
            p.respuesta = pregunta.respuesta;
            p.reactivo_a = pregunta.reactivo_a;
            p.reactivo_b = pregunta.reactivo_b;
            p.reactivo_c = pregunta.reactivo_c;
            new PreguntaModel().NuevaPregunta(p);
            return RedirectToAction("Index","Seccion" ,new SeccionModel());

        }

        public ActionResult modificarPregunta(int id) 
        {
            pregunta pregunta = new PreguntaModel().obtenerPreguntaPorId(id);
            PreguntaModel pm = new PreguntaModel();
            pm.pregunta1 = pregunta.pregunta1;
            pm.reactivo_a = pregunta.reactivo_a;
            pm.reactivo_b = pregunta.reactivo_b;
            pm.reactivo_c = pregunta.reactivo_c;
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
