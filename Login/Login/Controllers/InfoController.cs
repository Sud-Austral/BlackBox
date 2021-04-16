using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AplicacionBlanco.Controllers
{
    public class InfoController : Controller
    {
        private graficosEntities dbGrafico = new graficosEntities();
        public InfoController()
        {
            
        }

        // GET: Info
        public ActionResult Index(int id = 1, string id2 = "grafico", string id3 = "Geo_CL_provinces_.csv")
        {

            ViewBag.grafico = id2;
            ViewBag.file = id3;
            Graficos db = new Graficos();
            ViewBag.Resultado = null;  //db.BuscarGrafico(id);

            ViewBag.menu = dbGrafico.INDUSTRIA.ToList();

            ViewBag.menu2 = dbGrafico.SECTOR.ToList();

            ViewBag.menu3 = dbGrafico.PRODUCTO.ToList();

            GRAFICO graf = dbGrafico.GRAFICO.Where(x => x.id == id).First();
            ViewBag.Elemento = graf;

            // var listaAsociado = dbGrafico.PRODUCTO.Where(x => x.SECTOR_id == graf.CATEGORIA.PRODUCTO.SECTOR_id).ToList();
            var listaAsociado = dbGrafico.GRAFICO.Where(x => x.CATEGORIA.PRODUCTO.SECTOR_id == graf.CATEGORIA.PRODUCTO.SECTOR_id).ToList();
            ViewBag.listaAsociado = listaAsociado;
            /* var listaOtrosContenidos = dbGrafico.CATEGORIA.Where(x => x.PRODUCTO_id == graf.CATEGORIA.PRODUCTO_id).ToList(); */
            //List<int> idproductos = new List<int>();
            var rand = new Random();
            List<CATEGORIA> listaCategorias = new List<CATEGORIA>();

            foreach (var item in dbGrafico.INDUSTRIA)
            {
               var listcatAuxiliar = dbGrafico.CATEGORIA.Where(x => x.PRODUCTO.SECTOR.INDUSTRIA_id == item.id).ToList();
                try
                {
                    CATEGORIA catAuxiliar = listcatAuxiliar[rand.Next(listcatAuxiliar.Count)];
                    listaCategorias.Add(catAuxiliar);
                }
                catch (Exception)
                {

                    
                }
                
            }
            var listaOtrosContenidos = listaCategorias;  

            ViewBag.listaOtrosContenidos=listaOtrosContenidos ;
            return View();
        }

        //public ActionResult Index2(int id = 1, string id2 = "grafico")
        public ActionResult Index2(int id = 1, string id2 = "mapadechile_engeochart_2021.csv")
        {
            ViewBag.grafico = id2;
            Graficos db = new Graficos();
            ViewBag.Resultado = db.BuscarGrafico(id);
            return View();
        }

        public ActionResult Index3()
        {
            ViewBag.Twitter = "@data_int";
            return View();
        }

        public ActionResult mapa(int id = 6, string id2 = "mapa")
        {
            ViewBag.grafico = id2;
            Graficos db = new Graficos();
            ViewBag.Resultado = db.BuscarGrafico(id);
            return View();
        }
        public ActionResult PaginaBusqueda()
        {
            ViewBag.Resultado = dbGrafico.GRAFICO.ToList();
            return View();
        }

        public ActionResult HomeBusqueda()
        {
            return View();
        }
        public ActionResult gustavo()
        {
            ViewBag.test = dbGrafico.INDUSTRIA.ToList();
            return View();
        }
        public ActionResult Industrias(int id = 10)
        {
            INDUSTRIA iNDUSTRIA = dbGrafico.INDUSTRIA.Where(e => e.id == id).First();
            ViewBag.INDUSTRIA = iNDUSTRIA;
            return View();
        }

        public ActionResult menuprueba()
        {
            return View();
        }

    }
}