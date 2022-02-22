using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cursoNET.Models;
using cursoNET.Models.TableViewModel;
using cursoNET.Models.ViewModel;

namespace cursoNET.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            dynamic resultModel = new ExpandoObject();
            //var lst = new BigViewModel();

            List<UserTableViewModel> userlst = null;
            List<SelectListItem> itemlst = new List<SelectListItem>();

            using (cursoNetEntities db = new cursoNetEntities())
            {
                userlst = (from d in db.userTables
                                     where d.fkState == 1
                                     orderby d.userEmail
                                     select new UserTableViewModel
                                     {
                                         Email = d.userEmail,
                                         Edad = d.userAge,
                                         Id = d.idUser
                                     }).ToList(); //Se va a castear
                resultModel.Users = userlst;

                //Select list item es una clase para los items de los selects en html (combobox), el metodo value es el valor y el texto lo que mostrará
                itemlst = (from d in db.citiesTables
                       select new SelectListItem
                       {
                           Value = d.id.ToString(),
                           Text = d.city
                       }).ToList();
                resultModel.ListItemsCity = itemlst; 
            }

            return View(resultModel); // se tiene que regresar a la vista el dato
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost] //Metodo para pasar los datos aquí entrará
        public ActionResult Add(UserViewModel model)
        {
            //Checar si son válidos los campos, sino se tiene que volver a llenar el formulario
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new cursoNetEntities())
            {
                userTable oUser = new userTable();
                oUser.fkState = 1;
                oUser.userEmail = model.Email;
                oUser.userAge = model.Edad;
                oUser.userPassword = model.Password;
                db.userTables.Add(oUser);
                db.SaveChanges();
                
            }

            return Redirect(Url.Content("~/User/"));

        }

        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            //var es un tipo de dato múltiple, no necesitamos afirmar que es de cursoNetEntities
            using (var db = new cursoNetEntities())
            {
                var oUser = db.userTables.Find(Id); //Buscará el objeto si es que existe
                model.Email = oUser.userEmail;
                model.Edad = (int)oUser.userAge;
                model.Id = oUser.idUser;
            }

            return View(model);

        }
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new cursoNetEntities())
            {
                var oUser = db.userTables.Find(model.Id); //Buscará el objeto si es que existe
                oUser.userEmail  = model.Email;
                oUser.userAge = (int)model.Edad;

                if (model.Password != null && model.Password.Trim() != "")
                {
                    oUser.userPassword = model.Password;

                }
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified; //Le decimos al entity framework que se editó
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/User/"));

        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new cursoNetEntities())
            {
                var oUser = db.userTables.Find(Id);
                oUser.fkState = 3; //eliminaremos
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                
            }
            return Content("1");
        }

        
   
}
}