using Entidades;
using Mantenimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Mantenimiento.Controllers
{
    public class rolController : Controller
    {
        //
        // GET: /rol/

        public ActionResult Index()
        {
            RolModel rol = new RolModel();
            return View(rol);
        }

        [HttpPost]
        public ActionResult Nuevo(RolModel rol) 
        {
            RolModel rl = new RolModel();
            roles Rol = new roles();
            Rol.nombre = rol.nombre;
            Rol.descripcion = rol.descripcion;
            rl.nuevoRol(Rol);
            ViewBag.Rol = rl;
            return View("All");

        }

        public ActionResult All() 
        {
            RolModel rl = new RolModel();
            ViewBag.Rol = rl;
            return View();
        
        }

        public ActionResult Eliminar(int id) 
        {

            RolModel rl = new RolModel();
            rl.eliminarRol(id);
            ViewBag.Rol = rl;
            return View("All");
        }

        [HttpPost]
        public ActionResult modificarRol(RolModel rol)
        {
            RolModel rl = new RolModel();
            roles Rol = new roles();
            Rol.id = rol.id;
            Rol.descripcion = rol.descripcion;
            Rol.nombre = rol.nombre;
            rl.modificarRol(Rol);
            ViewBag.Rol = rl;
            return View("All");

        }


        public ActionResult modificarRol(int id) {
            int aux = id;
            roles Rol = new roles();
            RolModel rl = new RolModel();
            Rol = rl.obtenerRolById(id);
            rl.nombre = Rol.nombre;
            rl.descripcion = Rol.descripcion;
            rl.id = aux;
            return View(rl);
        }
    }
}
