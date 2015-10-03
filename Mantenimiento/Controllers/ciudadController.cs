using Mantenimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using System.Web.Mvc;

namespace Mantenimiento.Controllers
{
    public class ciudadController : Controller
    {
        //
        // GET: /ciudad/

        public ActionResult Index()
        {
            
            return View(new ciudadModel());
        }

        public ActionResult nuevaCiudad() 
        {
            return View(new ciudadModel());
        }

        [HttpPost]
        public ActionResult nuevaCiudad(ciudadModel ciudad)
        {
            ciudadModel cd = new ciudadModel();
            ciudad cdd = new ciudad();
            cdd.descripcion = ciudad.descripcion;
            cdd.nombre = ciudad.nombre;
            cdd.idEstado = ciudad.idEstado;
            cd.guardarCiudad(cdd);
            return RedirectToAction("Index", "ciudad", new ciudadModel());
        }

        public ActionResult modificarCiudad(int id)
        {
            ciudad ciudad = null;
            ciudadModel model = new ciudadModel();
            ciudad =  new ciudadModel().obtenerCiudadPorId(id);
            model.id = ciudad.id;
            model.descripcion = ciudad.descripcion;
            model.nombre = ciudad.nombre;
            model.idEstado = ciudad.idEstado;
            model.state = new ciudadModel().obtenerNombreEstado(model.idEstado);

            return View(model);

        }

        [HttpPost]
        public ActionResult modificarCiudad(ciudadModel ciudad)
        {
            new ciudadModel().modificarCiudad(ciudad);
            return RedirectToAction("Index","ciudad",new ciudadModel());
        }

        public ActionResult eliminarCiudad(int id) 
        {
            new ciudadModel().eliminarEstado(id);
            return RedirectToAction("Index", "ciudad", new ciudadModel());
        }
        [HttpPost]
        public String obtenerEstadoPorIdCiudad(int id)
        {

            return new ciudadModel().obtenerNombreEstadoPorIdciudad(id);
        
        }
    }
}
