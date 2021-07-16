using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class Data_UsuarioController : Controller
    {
        private graficosEntities1 db = new graficosEntities1();
        private graficosEntities dbGrafico = new graficosEntities();
        // GET: Data_Usuario
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult VisualizarGraficos(decimal id = 1234)
        {
            var rand = new Random();
            TABLA_GENERICA_PRUEBA graf = new TABLA_GENERICA_PRUEBA();
            try
            {
                graf = db.TABLA_GENERICA_PRUEBA.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                graf = db.TABLA_GENERICA_PRUEBA.First();
            }
            ViewBag.Elemento = graf;//graficos 
            ViewBag.time2 = DateTime.Now;
            return PartialView();
        }
        public ActionResult VisualizarGraficoColecion_Usuario(decimal id = 1234)
        {
            var rand = new Random();
            TABLA_GENERICA_PRUEBA graf = new TABLA_GENERICA_PRUEBA();
            try
            {
                graf = db.TABLA_GENERICA_PRUEBA.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                graf = db.TABLA_GENERICA_PRUEBA.First();
            }
            ViewBag.Elemento = graf;//graficos 
            ViewBag.time2 = DateTime.Now;
            ViewBag.time2 = DateTime.Now;
            return View();
        }
        public PartialViewResult ContenidoColección()
        {
            return PartialView();
        }
        public PartialViewResult Gráfico_Contenido_Colección()
        {
            return PartialView();
        }
        public PartialViewResult FuentesUsuario()
        {
            return PartialView();
        }
        public PartialViewResult Recursos_Usuario()
        {
            return PartialView();
        }
        public PartialViewResult Tematica()
        {
            return PartialView();
        }
        public PartialViewResult Cosecha()
        {
            return PartialView();
        }
        public PartialViewResult Empresas()
        {
            return PartialView();
        }
        public PartialViewResult Empleados()
        {
            return PartialView();
        }
        public PartialViewResult Produccion()
        {
            return PartialView();
        }
        public PartialViewResult Precios()
        {
            return PartialView();
        }
        public PartialViewResult Importaciones()
        {
            return PartialView();
        }
        public PartialViewResult Exportaciones()
        {
            return PartialView();
        }
        public PartialViewResult Rendimiento()
        {
            return PartialView();
        }
        public ActionResult Suscripciones()
        {
            return View();
        }
        public ActionResult PaginaBusqueda(string id = "1")
        {
            ViewBag.palabra = id;
            IEnumerable<TABLA_GENERICA_PRUEBA> union = UtilBusqueda.PaginaBusquedaData(id);
            if (union.Count() == 0)
            {
                ViewBag.Concepto = id;
                return View("No_Resultado");
            }
            ViewBag.Resultado = union;

            var Coleccion = union.Select(x => x.coleccion).Distinct();
            var Sector = union.Select(x => x.sector).Distinct();
            var Tema = union.Select(x => x.tema).Distinct();
            var Contenido = union.Select(x => x.contenido).Distinct();
            var Escala = union.Select(x => x.escala).Distinct();
            var Territorio = union.Select(x => x.muestra_temporalidad).Distinct();
            ViewBag.Coleccion = Coleccion;
            ViewBag.Sector = Sector;
            ViewBag.Escala = Escala;
            ViewBag.Tema = Tema;
            ViewBag.Contenido = Contenido;
            ViewBag.Escala = Escala;
            ViewBag.Territorio = Territorio;

            return View();
        }

        public PartialViewResult Data_UsuarioGrafico(decimal id = 1234)
        {
            var rand = new Random();
            TABLA_GENERICA_PRUEBA graf = new TABLA_GENERICA_PRUEBA();
            try
            {
                graf = db.TABLA_GENERICA_PRUEBA.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                graf = db.TABLA_GENERICA_PRUEBA.First();
            }
            ViewBag.Elemento = graf;//graficos 
            ViewBag.time2 = DateTime.Now;
            ViewBag.time2 = DateTime.Now;
            return PartialView();
        }
        public PartialViewResult Paginacion(string id = "1", int id2 = 1)
        {
            //var NEW_GRAFICOS
            ViewBag.Resultado = db.TABLA_GENERICA_PRUEBA.Where(x => x.titulo.Contains(id) || x.tag.Contains(id))
                                                .OrderBy(x => x.id)
                                                .Skip(200 + 50 * id2)
                                                .Take(50);
            return PartialView();
        }
        public ActionResult PaginaBusqueda2(string id = "1", int id2 = 1)
        {
            //1 Coleccion
            //2 Sector
            //3 Tema
            //4 Contenido
            ViewBag.palabra = id;
            IEnumerable<TABLA_GENERICA_PRUEBA> union;
            switch (id2)
            {
                case 1:
                    union = db.TABLA_GENERICA_PRUEBA.Where(x => x.coleccion.Contains(id));
                    break;
                case 2:
                    union = db.TABLA_GENERICA_PRUEBA.Where(x => x.sector.Contains(id));
                    break;
                case 3:
                    union = db.TABLA_GENERICA_PRUEBA.Where(x => x.tema.Contains(id));
                    break;
                case 4:
                    union = db.TABLA_GENERICA_PRUEBA.Where(x => x.contenido.Contains(id));
                    break;
                default:
                    union = db.TABLA_GENERICA_PRUEBA.Take(200);
                    break;
            }
            ViewBag.Resultado = union;
            var Coleccion = union.Select(x => x.coleccion).Distinct();
            var Sector = union.Select(x => x.sector).Distinct();
            var Tema = union.Select(x => x.tema).Distinct();
            var Contenido = union.Select(x => x.contenido).Distinct();
            var Escala = union.Select(x => x.escala).Distinct();
            var Territorio = union.Select(x => x.coleccion).Distinct();
            ViewBag.Coleccion = Coleccion;
            ViewBag.Sector = Sector;
            ViewBag.Escala = Escala;
            ViewBag.Tema = Tema;
            ViewBag.Contenido = Contenido;
            ViewBag.Escala = Escala;
            ViewBag.Territorio = Territorio;
            return View("PaginaBusqueda");
        }
    }
}