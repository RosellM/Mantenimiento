using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Mantenimiento.Models;
using Entidades;
namespace Mantenimiento.Controllers
{
    public class personasController : Controller
    {
        //
        // GET: /personas/

        public ActionResult Index()
        {
            return View(new personasModel());
        }

        public ActionResult Nuevo() 
        {

            return View(new personasModel());
        }

        [HttpPost]
        public ActionResult Nuevo(personasModel persona) 
        {
            personas p = new personas();
            p.Apellidos = persona.Apellidos;
            p.Nombres = persona.Nombres;
            p.Direccion = persona.Direccion;
            p.idCiudad = persona.idCiudad;
            new personasNeg().NuevaPersona(p);
            return View("Index",new personasModel());
        }
       
        public ActionResult modificarPersona(int id) 
        {
            personasModel pm = new personasModel();
            personas per = pm.obtenerPersonaPorID(id);
            pm.id = id;
            pm.idCiudad = per.idCiudad;
            pm.Nombres = per.Nombres;
            pm.Apellidos = per.Apellidos;
            pm.Direccion = per.Direccion;
            return View(pm);
        }

        [HttpPost]
        public ActionResult modificarPersona(personasModel persona) 
        {

            personas p = new personas();
            p.id = persona.id;
            p.idCiudad = persona.idCiudad;
            p.Nombres = persona.Nombres;
            p.Apellidos = persona.Apellidos;
            p.Direccion = persona.Direccion;
            new personasModel().modificarPersonas(p);
            return View("Index", new personasModel());
        }

        public ActionResult eliminarPersona(int id)
        {
            new personasModel().eliminarPersonas(id);
            return View("Index",new personasModel());
        }

      
    }
}
