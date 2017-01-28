using Practica1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica1.Controllers
{
    public class APIProductosController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //GET: APIProductos
    
        public JsonResult getJsonList()
        {
            var productos = db.productos.ToList();
            return Json(productos, JsonRequestBehavior.AllowGet);
        }
        public JsonResult createProducto(Producto producto)
        {
            var respuesta = new { Funciono = false };
            try
            {
                db.productos.Add(producto);
                int registrosModificados = db.SaveChanges();
                //se logro modiicar el query,pero, se hicieron cambios?
                if (registrosModificados > 0)
                {
                    respuesta = new { Funciono = true };
                }
            }
            catch{ }
            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult eliminarProduto(int id)
        {
            Producto eliminar = db.productos.Find(id);
            var result = db.productos.Remove(eliminar);
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult editarProducto(int id)
        {
            var ProductoEditado = db.productos.Find(id);
            var result = new { id = ProductoEditado.productoID, nombre = ProductoEditado.nombre, precio = ProductoEditado.precio };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //[ActionName("editarProducto")]
        public JsonResult editarProduto(Producto producto)
        {
            //Producto modificar = db.productos.Find(id);
            //var resultado = db.Entry(modificar).State = EntityState.Modified;

            //db.SaveChanges();
            var resultado = db.Entry(producto).State = EntityState.Modified;
            db.SaveChanges();

            return Json(resultado, JsonRequestBehavior.AllowGet);

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