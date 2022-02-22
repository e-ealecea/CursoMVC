using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cursoNET.Models; //IMPORTAR EL ENTITNY FRAMEWORK

namespace cursoNET.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string pass) //Toma los valores de name
        {
            try
            {
                using ( cursoNetEntities db = new cursoNetEntities() ) //instancia del entity 
                {
                    var lista = from d in db.userTables //Linq lenguaje SQL consultas en c#
                                where d.userEmail == user && d.userPassword == pass && d.fkState == 1
                                select d;

                    if (lista.Count() > 0) //TRAE LOS DATOS DEL QUERY  si es mas que 0 significa que sí hay
                    {

                        userTable user1 = lista.First(); //TRAE UN MODELO DE MI TABLA userTable el primer elemento
                        Session["User"] = user1;
                        return Content("1");
                    }
                    else
                    {
                        return Content("No se encontró el usuario");
                    }

                }
                    
            }
            catch (Exception e)
            {
                return Content("Ocurrio error :(" + e.Message); // Content es una clase que regresa un string
            }
        }
    }
}