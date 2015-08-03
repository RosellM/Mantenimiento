using Entidades;
using Mantenimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mantenimiento.Controllers
{
    public class estadoController : Controller
    {
        //
        // GET: /estado/

        public ActionResult Index()
        {
            estadoModel estado = new estadoModel();

            return View(estado);
        }

        public ActionResult Nuevo() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(estadoModel estado) 
        {
            if (ModelState.IsValid) 
            {
                estados est = new estados();
                est.nombre = estado.nombre;
                est.descripcion = estado.descripcion;
                new estadoModel().nuevoEstado(est);
                return View("Index", new estadoModel());
            }
            else{
                return View("Nuevo");
            }

          
        }

        public ActionResult eliminarEstado(int id) 
        {
            new estadoModel().eliminarEstado(id);
            return View("Index",new estadoModel());
        }

        public ActionResult modificarEstado(int id)
        {
            estados estado = null;
            estadoModel estm = new estadoModel();
            estado = new estadoModel().obtenerEstadoPorId(id);
            estm.id = estado.id;
            estm.nombre = estado.nombre;
            estm.descripcion = estado.descripcion;
            return View(estm);
        }

        [HttpPost]
        public ActionResult modificarEstado(estadoModel estado) 
        {
            if (ModelState.IsValid) 
            {
                estados est = new estados();
                est.descripcion = estado.descripcion;
                est.nombre = estado.nombre;
                est.id = estado.id;
                new estadoModel().modificarEstado(est);
                return View("Index",new estadoModel());
            }

            return View("modificarEstado");

        }

    }
}
