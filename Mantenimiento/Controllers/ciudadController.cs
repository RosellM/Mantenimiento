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
            return View("Index",new ciudadModel());
        }

        public ActionResult modificarCiudad(int id)
        {
            ciudadModel model = new ciudadModel();
            ciudad cd = model.obtenerCiudadPorId(id);
            model.nombre = cd.nombre;
            model.descripcion = cd.descripcion;
            model.id = cd.id;
            model.idEstado = cd.idEstado;
            model.state = model.obtenerNombreEstado(model.idEstado);
            return View(model);
        }

        [HttpPost]
        public ActionResult modificarCiudad(ciudadModel ciudad)
        {
            new ciudadModel().modificarCiudad(ciudad);
            return View("Index",new ciudadModel());
        }

        public ActionResult eliminarCiudad(int id) 
        {
            new ciudadModel().eliminarEstado(id);
            return View("Index", new ciudadModel());
        }
    }
}
