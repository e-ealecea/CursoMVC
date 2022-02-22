using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; //Para usar el action filter attribute
using cursoNET.Controllers; //Para hacer uso de los controladores que hay en el proyecto
using cursoNET.Models; //Para hacer uso de los modelos de la bd

namespace cursoNET.Filters
{
    public class Authenticator : ActionFilterAttribute //Se tiene que sobreescribe un metodo para que actue como filtro
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (userTable)HttpContext.Current.Session["User"]; //Me trae la informacion de la sesion tipo modelo de userTable

            //Verifica si no hay sesión te direcciona a Access si la tienes no puedes dirigirte a Access

            if (oUser == null) //No trae nada no hay nada en la variable de la sesion user
            {
                if (filterContext.Controller is AccessController == false) //Pregunta sobre el controlador que va dirigido, si es diferente a AccesController va a redirigirse a access controler sino no se hará un bucle infinito
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index"); //Redirecciona a la raiz
                }

            }
            else
            {
                if (filterContext.Controller is AccessController == true) //Pregunta sobre el controlador que va dirigido, si es igual a AccesController va a redirigirse a home controler sino no se hará un bucle infinito
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index"); //Redirecciona a la raiz
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}