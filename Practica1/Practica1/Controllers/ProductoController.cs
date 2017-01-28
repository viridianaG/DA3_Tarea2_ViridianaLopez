using Practica1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica1.Controllers
{
    public class ProductoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [AllowCrossSiteJsonAttribute]
        // GET: Producto
        public JsonResult JsonList()
        {
            var productos = db.productos.ToList();
            return Json(productos,JsonRequestBehavior.AllowGet);
        }

        public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
                base.OnActionExecuting(filterContext);
            }
        }
    }
}