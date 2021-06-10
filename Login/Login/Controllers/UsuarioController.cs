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
        //Base de datos de los graficos
        private graficosEntities dbGrafico = new graficosEntities();

        //Constructor del controlador
        public UsuarioController()
        {

        }
        // GET: Usuario
        public ActionResult Index()
        {
            //Lista de productos de Shopify
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            //Nombre de Usuario
            ViewBag.User = User.Identity.GetUserName();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            {
                foreach (var item2 in item["line_items"])
                {
                    try
                    {
                        productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                    }
                    catch (Exception)
                    {

                        string hola = "";
                    }
                    
                }
            }
            //Objeto que separa Productos y Suscripciones
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
            //Productos
            productos = shopifyYSuscripciones.producto_Shopifies;
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            //Suscripciones
            Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            ViewBag.Resultado = productos;
            //ViewBag.Menu = dbGrafico.INDUSTRIA.ToList();
            //Menu que esta suscrito el usuario
            //ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => shopifyYSuscripciones.industrias.Contains(x.id)).ToList();
            //ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => x.id==10).ToList();
            int idExample = 1001;
            var grafico = dbGrafico.INDUSTRIA.Where(x => x.id == idExample / 100).ToList();
            foreach (var item in grafico)
            {
                item.SECTOR = (ICollection<SECTOR>)item.SECTOR.Where(x => x.id == 1001).ToArray();
            }
            ViewBag.Menu = grafico;
            return View();
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

        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************
        //
        //                                                    Desde Aqui todos los objetos son de pruebas para desarrollo
        //
        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************************

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
        public JsonResult MenuBusqueda(string id)
        {
            return Json(id, JsonRequestBehavior.AllowGet);
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

        public ActionResult Usuaria2()
        {
            ViewBag.Lista = dbGrafico.INDUSTRIA.ToList();

            //Lista de productos de Shopify
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            //Nombre de Usuario
            ViewBag.User = User.Identity.GetUserName();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail())
            {
                foreach (var item2 in item["line_items"])
                {
                    productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                }
            }
            //Objeto que separa Productos y Suscripciones
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
            //Productos
            productos = shopifyYSuscripciones.producto_Shopifies;
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            //Suscripciones
            Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            ViewBag.Resultado = productos;
            //ViewBag.Menu = dbGrafico.INDUSTRIA.ToList();
            //Menu que esta suscrito el usuario
            ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => shopifyYSuscripciones.industrias.Contains(x.id)).ToList();
            return View();
        }

        public ActionResult Dashboard(string id = null)
        {
            List<Producto_Shopify> productos = (List<Producto_Shopify>)Session["Productos"];
            if (productos == null)
            {
                 productos = new List<Producto_Shopify>();
                //Nombre de Usuario
                ViewBag.User = User.Identity.GetUserName();
                //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
                foreach (var item in APIShopify.BuscarOrdenesPorMail())
                {
                    foreach (var item2 in item["line_items"])
                    {
                        productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                    }
                }
                //Objeto que separa Productos y Suscripciones
                ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
                //Productos
                productos = shopifyYSuscripciones.producto_Shopifies;
                //ViewBag.url = (string)Session["url"];
                Session["Productos"] = productos;
                //Suscripciones
                Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            }
            string url = "";
            try
            {
                 url = productos.Where(x => x.ID == id).First().SKU;
            }
            catch (Exception)
            {

                url = productos[0].SKU;
            }
            

            ViewBag.url = url; //"https://www.c-sharpcorner.com/article/html-action-and-html-renderaction-in-Asp-Net-mvc/";
            string user = User.Identity.GetUserName();
            ShopifyYSuscripciones shopifyYSuscripciones2 = new ShopifyYSuscripciones(productos);
            ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => shopifyYSuscripciones2.industrias.Contains(x.id)).ToList();
            ViewBag.Resultado = productos;
            /*
            ViewBag.user = user;
            List<string> aux = correos.correos;
            if (!aux.Contains(user))
            {
                return View("Restriccion");
            }
            */
            if (ViewBag.url == null)
            {
                return View("Restriccion");
            }
            return View();
        }
        public PartialViewResult Bienvenido()
        {
            ViewBag.User = User.Identity.GetUserName();
            return PartialView();
        }
        public PartialViewResult GraficoUsuario()
        {
            //Lista de productos de Shopify
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            //Nombre de Usuario
            ViewBag.User = User.Identity.GetUserName();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            {
                foreach (var item2 in item["line_items"])
                {
                    try
                    {
                        productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                    }
                    catch (Exception)
                    {

                        string hola = "";
                    }

                }
            }
            //Objeto que separa Productos y Suscripciones
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
            //Productos
            productos = shopifyYSuscripciones.producto_Shopifies;
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            //Suscripciones
            Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            ViewBag.Resultado = productos;
            return PartialView();
        }

        public PartialViewResult InformesUsuario()
        {
            //Lista de productos de Shopify
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            //Nombre de Usuario
            ViewBag.User = User.Identity.GetUserName();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            {
                foreach (var item2 in item["line_items"])
                {
                    try
                    {
                        productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                    }
                    catch (Exception)
                    {

                        string hola = "";
                    }

                }
            }
            //Objeto que separa Productos y Suscripciones
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
            //Productos
            productos = shopifyYSuscripciones.producto_Shopifies;
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            //Suscripciones
            Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            ViewBag.Resultado = productos;
            return PartialView();
        }
        public PartialViewResult ReportesUsuario()
        {
            //Lista de productos de Shopify
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            //Nombre de Usuario
            ViewBag.User = User.Identity.GetUserName();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            {
                foreach (var item2 in item["line_items"])
                {
                    try
                    {
                        productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                    }
                    catch (Exception)
                    {

                        string hola = "";
                    }

                }
            }
            //Objeto que separa Productos y Suscripciones
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
            //Productos
            productos = shopifyYSuscripciones.producto_Shopifies;
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            //Suscripciones
            Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            ViewBag.Resultado = productos;

            return PartialView();
        }
        public PartialViewResult Facturados()
        {

            //Lista de productos de Shopify
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            //Nombre de Usuario
            ViewBag.User = User.Identity.GetUserName();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            {
                foreach (var item2 in item["line_items"])
                {
                    try
                    {
                        productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                    }
                    catch (Exception)
                    {

                        string hola = "";
                    }

                }
            }
            ViewBag.Facturados = productos;
           

            return PartialView();
        }
        public PartialViewResult PerfilUsuario()
        {
            ViewBag.User = User.Identity.GetUserName();
            return PartialView();
        }
        public PartialViewResult UsuarioSelectProducto()
        {
            //Lista de productos de Shopify
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            //Nombre de Usuario
            ViewBag.User = User.Identity.GetUserName();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            {
                foreach (var item2 in item["line_items"])
                {
                    try
                    {
                        productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                    }
                    catch (Exception)
                    {

                        string hola = "";
                    }

                }
            }
            //Objeto que separa Productos y Suscripciones
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
            //Productos
            productos = shopifyYSuscripciones.producto_Shopifies;
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            //Suscripciones
            Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            ViewBag.Resultado = productos;
            return PartialView();
        }

        public ActionResult resultados(int id= 220106007)
        {
            //Lista de productos de Shopify
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            //Nombre de Usuario
            ViewBag.User = User.Identity.GetUserName();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            {
                foreach (var item2 in item["line_items"])
                {
                    try
                    {
                        productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                    }
                    catch (Exception)
                    {

                        string hola = "";
                    }

                }
            }
            //Objeto que separa Productos y Suscripciones
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
            //Productos
            productos = shopifyYSuscripciones.producto_Shopifies;
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            //Suscripciones
            Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            ViewBag.Resultado = productos;
            //ViewBag.Menu = dbGrafico.INDUSTRIA.ToList();
            //Menu que esta suscrito el usuario
            //ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => shopifyYSuscripciones.industrias.Contains(x.id)).ToList();
            ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => x.id == 10).ToList();
            var url = dbGrafico.GRAFICO.Where(x => x.CATEGORIA_id == id).First();
            ViewBag.Grafico = url;
            return View();
        }
        public ActionResult Resultados2(int id = 2)
        {
            //Lista de productos de Shopify
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            //Nombre de Usuario
            ViewBag.User = User.Identity.GetUserName();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            {
                foreach (var item2 in item["line_items"])
                {
                    try
                    {
                        productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                    }
                    catch (Exception)
                    {

                        string hola = "";
                    }

                }
            }
            //Objeto que separa Productos y Suscripciones
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
            //Productos
            productos = shopifyYSuscripciones.producto_Shopifies;
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            //Suscripciones
            Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            ViewBag.Resultado = productos;
            ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => x.id == 10).ToList();
            return View();
        }
        public ActionResult Index2()
        {
            //Lista de productos de Shopify
            List<Producto_Shopify> productos = new List<Producto_Shopify>();
            //Nombre de Usuario
            ViewBag.User = User.Identity.GetUserName();
            //foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            foreach (var item in APIShopify.BuscarOrdenesPorMail(User.Identity.GetUserName()))
            {
                foreach (var item2 in item["line_items"])
                {
                    try
                    {
                        productos.Add(new Producto_Shopify(item2, (string)item["order_status_url"], item));
                    }
                    catch (Exception)
                    {

                        string hola = "";
                    }

                }
            }
            //Objeto que separa Productos y Suscripciones
            ShopifyYSuscripciones shopifyYSuscripciones = new ShopifyYSuscripciones(productos);
            //Productos
            productos = shopifyYSuscripciones.producto_Shopifies;
            //ViewBag.url = (string)Session["url"];
            Session["Productos"] = productos;
            //Suscripciones
            Session["Suscripcion"] = shopifyYSuscripciones.suscripcions;
            ViewBag.Resultado = productos;
            //ViewBag.Menu = dbGrafico.INDUSTRIA.ToList();
            //Menu que esta suscrito el usuario
            //ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => shopifyYSuscripciones.industrias.Contains(x.id)).ToList();
            ViewBag.Menu = dbGrafico.INDUSTRIA.Where(x => x.id == 10).ToList();
            return View();
        }
        public PartialViewResult UsuarioSelectProducto2( int id=1)
        {
            var NEW_GRAFICOS = dbGrafico.GRAFICO.Where(x => x.CATEGORIA_id == id);
            //var NEW_GRAFICOS = dbGrafico.GRAFICO.SqlQuery("SELECT * FROM GRAFICO WHERE titulo LIKE '% " + id + " %'");


            ViewBag.Resultado = NEW_GRAFICOS.Where(x => x.TIPO_GRAFICO_id < 3).Take(20); //.ToList();//Liberados/Gratis
            ViewBag.Resultado2 = NEW_GRAFICOS.Where(x => x.TIPO_GRAFICO_id == 3).Take(20); //.ToList();//Informes
            //ViewBag.Resultado3 = NEW_GRAFICOS.Where(x => x.TIPO_GRAFICO_id == 4).Take(50); //.ToList();//Reportes
            string NombreCategoria = "No hay información de esta categoria";
            if(NEW_GRAFICOS.Count() > 0)
            {
                NombreCategoria = NEW_GRAFICOS.ToList()[0].CATEGORIA.nombre;
            }
            ViewBag.saludo = NombreCategoria;

            return PartialView();
        }
        public PartialViewResult UsuarioSelectProducto3(int id = 220106007)
        {
            var url = dbGrafico.GRAFICO.Where(x => x.id == id).First();
            ViewBag.Grafico = url;

            return PartialView();
        }

        
        public PartialViewResult FormBuscador(string id = "1")
        {
            ViewBag.palabra = id;
            // = dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id) || x.titulo.Contains(id) || x.tags.Contains(id)).Take(2);
            var prioridad = dbGrafico.GRAFICO.SqlQuery("SELECT * FROM GRAFICO WHERE titulo LIKE '% " + id + " %'")
                                                .Take(50);
            IEnumerable<GRAFICO> NEW_GRAFICOS;
            IEnumerable<GRAFICO> union;
            if (prioridad.Count() < 50)
            {
                NEW_GRAFICOS = dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id) || x.titulo.Contains(id) || x.tags.Contains(id))
                                                 .OrderBy(x => x.id)
                                                 .Take(50 - prioridad.Count());
                int ent = NEW_GRAFICOS.Count();
                union = prioridad.Concat(NEW_GRAFICOS); //.Distinct();

            }
            else
            {
                union = prioridad;
            }
            int ent2 = union.Count();

            ViewBag.Resultado = union;
            //ViewBag.Resultado = NEW_GRAFICOS.ToList();//Liberados/Gratis
            //ViewBag.Resultado2= NEW_GRAFICOS.Where(x => x.TIPO_GRAFICO_id == 3).ToList();//Informes
            //ViewBag.Resultado3 = NEW_GRAFICOS.Where(x => x.TIPO_GRAFICO_id == 4).ToList();//Reportes
            //Listas de Filtros

            List<string> Paises = new List<string>();
            List<string> Escala = new List<string>();
            List<string> TipoGrafico = new List<string>();
            List<string> Temporalidad = new List<string>();
            List<string> Producto = new List<string>();
            List<string> Industria = new List<string>();
            List<string> Sector = new List<string>();
            List<string> Categoria = new List<string>();
            List<string> Parametro = new List<string>();
            foreach (var item in union)
            {
                if (!Paises.Contains(item.TERRITORIO.auxiliar))
                {
                    Paises.Add(item.TERRITORIO.auxiliar);
                }
                if (!Escala.Contains(item.TERRITORIO.nombre))
                {
                    Escala.Add(item.TERRITORIO.nombre);
                }
                if (!TipoGrafico.Contains(item.TIPO_GRAFICO.nombre))
                {
                    TipoGrafico.Add(item.TIPO_GRAFICO.nombre);
                }
                if (!Temporalidad.Contains(item.TEMPORALIDAD.nombre))
                {
                    Temporalidad.Add(item.TEMPORALIDAD.nombre);
                }
                if (!Producto.Contains(item.CATEGORIA.PRODUCTO.nombre))
                {
                    Producto.Add(item.CATEGORIA.PRODUCTO.nombre);
                }
                if (!Industria.Contains(item.CATEGORIA.PRODUCTO.SECTOR.INDUSTRIA.nombre))
                {
                    Industria.Add(item.CATEGORIA.PRODUCTO.SECTOR.INDUSTRIA.nombre);
                }
                if (!Sector.Contains(item.CATEGORIA.PRODUCTO.SECTOR.nombre))
                {
                    Sector.Add(item.CATEGORIA.PRODUCTO.SECTOR.nombre);
                }

                if (!Categoria.Contains(item.CATEGORIA.nombre))
                {
                    Categoria.Add(item.CATEGORIA.nombre);
                }
                if (!Parametro.Contains(item.PARAMETRO.nombre))
                {
                    Parametro.Add(item.PARAMETRO.nombre);
                }
            }
            ViewBag.Paises = Paises;
            ViewBag.Escala = Escala;
            ViewBag.TipoGrafico = TipoGrafico;
            ViewBag.Temporalidad = Temporalidad;
            ViewBag.Producto = Producto;
            ViewBag.Industria = Industria;
            ViewBag.Sector = Sector;
            ViewBag.Categoria = Categoria;
            ViewBag.Parametro = Parametro;

            return PartialView();
        }
        public ActionResult test2()
        {

            return View();
        }

        public ActionResult test3()
        {
            List<int> suscrip = new List<int>();
            suscrip.Add(1001);
            var resultado = dbGrafico.GRAFICO.Where(x => x.TIPO_GRAFICO_id == 3).ToList();
            foreach (var item in resultado)
            {
                item.suscripciones = suscrip;
            }
            ViewBag.Resultado = resultado;
            return View();
        }
        public PartialViewResult InformeSuscription(string id, string nombre)
            {
                ViewBag.urlReporte = id;
                ViewBag.TituloReporte = nombre;
            
                return PartialView();
        }

        public PartialViewResult InformeReporte(string id, string nombre)
        {
            ViewBag.urlReporte = id;
            ViewBag.TituloReporte = nombre;

            return PartialView();
        }
        public PartialViewResult UsuarioSelectProducto4(int id = 220106007)
        {
            var url = dbGrafico.GRAFICO.Where(x => x.id == id).First();
            ViewBag.Grafico = url;

            return PartialView();
        }
    }
}
   