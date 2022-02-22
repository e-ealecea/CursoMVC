using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cursoNET.Models.ViewModel;

namespace cursoNET.Controllers
{
    public class GetfileController : Controller
    {
        // GET: GetFile
        public ActionResult Index()
        {
            if(TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString(); //Vista
            }
            return View();
        }
        [HttpPost]
        public ActionResult Send(GetfileViewModel model)
        {
            string RutaSitio = Server.MapPath("~/"); //Ruta de la raiz de mi servidor
            string PathArchivo1 = Path.Combine(RutaSitio + "/Files/archivo1.png"); //Combinará ambas rutas
            string PathArchivo2 = Path.Combine(RutaSitio + "/Files/archivo2.png"); //Combinará ambas rutas


            if (!ModelState.IsValid)
                return View("Index", model);

            model.PostedFile.SaveAs(PathArchivo1);
            model.PostedFile2.SaveAs(PathArchivo2);

            @TempData["Message"] = "Se cargaron los archivos"; //Mensaje temporal

            return RedirectToAction("Index");
            
        }
    }
}