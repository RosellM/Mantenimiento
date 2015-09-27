using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantenimiento.Models;
namespace Mantenimiento.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string username) 
        {

            UsuarioModel model = new UsuarioModel();

            if (model.obtenerUsuario(username))
            {

                if (model.rol.nombre == "admin")
                {
                    System.Web.HttpContext.Current.Session["usuario"] = model.rol.nombre; 
                    return RedirectToAction("Index","principal");
                }
                else 
                {
                    return RedirectToAction("user", "principal", new {user= username });
                    
                }

            }
            else {

                return RedirectToAction("Registrarse", "Home");
            
            }


         

        }

        public ActionResult Registrarse() 
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registrarse(string[] array_data) 
        {
            try
            {
                UsuarioModel model = new UsuarioModel();
                model.nombre = array_data[0].ToString();
                model.nombreApellidoMaterno = array_data[1].ToString();
                model.nombreApellidoPaterno = array_data[2].ToString();
                model.idRol = Int32.Parse(array_data[3]);
                model.nuevoUser();
                 return this.RedirectToAction("Index","Home");
            }
            
            catch (Exception e) 
            {
                return this.RedirectToAction("Index","Home");
            }


           

          
        }

    }
}
