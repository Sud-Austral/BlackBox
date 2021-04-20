using Login.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private graficosEntities dbGrafico = new graficosEntities();
        public UsuarioController()
        {

        }
        // GET: Usuario
        public ActionResult Index()
        {

            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            ViewBag.User = User.Identity.GetUserName();
            //ViewBag.Resultado = APIShopify.BuscarOrdenes();
            //ViewBag.Resultado = APIShopify.BuscarOrdenesPorMail();
            //var test = APIShopify.BuscarOrdenesPorMail();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail())
            {
                foreach (var item2 in item["line_items"])
                {

                    productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                }
            }
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
            productos = shopifyYSuscripciones.producto_Shopifies;
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            ViewBag.Resultado = productos;
            //ViewBag.Menu = dbGrafico.INDUSTRIA.ToList();
            ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => shopifyYSuscripciones.industrias.Contains(x.id)).ToList();
            return View();
        }

        public JsonResult GetNombre()
        {
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            ViewBag.User = User.Identity.GetUserName();
            //ViewBag.Resultado = APIShopify.BuscarOrdenes();
            //ViewBag.Resultado = APIShopify.BuscarOrdenesPorMail();
            //var test = APIShopify.BuscarOrdenesPorMail();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail())
            {
                foreach (var item2 in item["line_items"])
                {

                    productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                }
            }
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);

            //return Json(shopifyYSuscripciones.producto_Shopifies, JsonRequestBehavior.AllowGet);
            //return Json(productos[0].SKU.Contains("datasuscripcion"), JsonRequestBehavior.AllowGet);
            //return Json(dbGrafico.INDUSTRIA.Where(x => shopifyYSuscripciones.industrias.Contains(x.id)).ToList(), JsonRequestBehavior.AllowGet);
            return Json(productos, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Suscripcion()
        {
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            ViewBag.User = User.Identity.GetUserName();
            //ViewBag.Resultado = APIShopify.BuscarOrdenes();
            //ViewBag.Resultado = APIShopify.BuscarOrdenesPorMail();
            //var test = APIShopify.BuscarOrdenesPorMail();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (Newtonsoft.Json.Linq.JToken item in APIShopify.BuscarOrdenesPorMail())
            {
                foreach (var item2 in item["line_items"])
                {

                    productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                }
            }
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            ViewBag.Resultado = productos;

            return View();
        }

        public JsonResult MenuBusqueda(int id, int id2)
        {
            //var salida;
            switch (id2)
            {
                case 1:
                    string salida = dbGrafico.INDUSTRIA.Where(x => x.id == id).First().nombre;
                    return Json(salida, JsonRequestBehavior.AllowGet);
                    //break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
            return null;
            
        }
    }
}