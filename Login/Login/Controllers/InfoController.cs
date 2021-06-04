﻿using Login.Models;
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
        public ActionResult Index(int id = 100, string id2 = "grafico", string id3 = "Geo_CL_provinces_.csv")
        {
            var rand = new Random();
            ViewBag.grafico = id2;
            ViewBag.file = id3;
            Graficos db = new Graficos();
            ViewBag.Resultado = null;  //db.BuscarGrafico(id);
            ViewBag.menu = dbGrafico.INDUSTRIA.ToList();
            ViewBag.menu2 = dbGrafico.SECTOR.ToList();
            ViewBag.menu3 = dbGrafico.PRODUCTO.ToList();
            GRAFICO graf = new GRAFICO();
            try
            {
                graf = dbGrafico.GRAFICO.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                graf = null;
            } 
            if(graf.TIPO_GRAFICO_id > 1 || graf == null)
            {
                var listaGraficoAuxiliar = dbGrafico.GRAFICO.Where(x => x.TIPO_GRAFICO_id < 3).ToList();
                graf = listaGraficoAuxiliar[rand.Next(listaGraficoAuxiliar.Count)];
            }            
            ViewBag.Elemento = graf;
            // var listaAsociado = dbGrafico.PRODUCTO.Where(x => x.SECTOR_id == graf.CATEGORIA.PRODUCTO.SECTOR_id).ToList();
            var listaAsociado = dbGrafico.GRAFICO.Where(x => x.CATEGORIA.PRODUCTO.SECTOR_id == graf.CATEGORIA.PRODUCTO.SECTOR_id).ToList();
            ViewBag.listaAsociado = listaAsociado;
            /* var listaOtrosContenidos = dbGrafico.CATEGORIA.Where(x => x.PRODUCTO_id == graf.CATEGORIA.PRODUCTO_id).ToList(); */
            //List<int> idproductos = new List<int>();
            
            List<CATEGORIA> listaCategorias = new List<CATEGORIA>();
            foreach (var item in dbGrafico.INDUSTRIA)
            {
               var listcatAuxiliar = dbGrafico.CATEGORIA.Where(x => x.PRODUCTO.SECTOR.INDUSTRIA_id == item.id).Take(10).ToList();
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

            var Graficos = dbGrafico.GRAFICO.ToList();
            var rand2 = new Random();
            List<GRAFICO> listaGraficos = new List<GRAFICO>();
            for (int i = 0; i < 15; i++)
            {
                listaGraficos.Add(Graficos[rand2.Next(Graficos.Count)]);
            }
            ViewBag.Graficos = listaGraficos;

            return View();
        }

        //public ActionResult Index2(int id = 1, string id2 = "grafico")
        

        
        public ActionResult PaginaBusqueda(string id = "1")
        {
            ViewBag.palabra = id;
            // = dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id) || x.titulo.Contains(id) || x.tags.Contains(id)).Take(2);
            
            var NEW_GRAFICOS = dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id) || x.titulo.Contains(id) || x.tags.Contains(id))
                                                .OrderBy(x => x.id)
                                                .Take(200);
            ViewBag.Resultado = NEW_GRAFICOS;
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
            foreach (var item in NEW_GRAFICOS)
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
            return View();
        }

        public PartialViewResult Paginacion(string id = "1", int id2 = 1)
        {
            
            //var NEW_GRAFICOS
            ViewBag.Resultado = dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id) || x.titulo.Contains(id) || x.tags.Contains(id))
                                                .OrderBy(x => x.id)
                                                .Skip(200 * id2)
                                                .Take(200);
            
            return PartialView();
        }

        public ActionResult PaginaBusqueda2(string id)
        {
            ViewBag.Resultado = dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id)).ToList();
            List<GRAFICO> salida = dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id)).ToList();
            List<string> nombres = new List<string>();
            foreach (var item in salida)
            {
                nombres.Add(item.nombre);
            }
            return Json(nombres, JsonRequestBehavior.AllowGet);
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
        //[OutputCache(Duration = int.MaxValue)]
        public ActionResult HomeOdoo()
        {
            var rand = new Random();
            List<int> aux = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                aux.Add(rand.Next(dbGrafico.GRAFICO.Min(x => x.id), dbGrafico.GRAFICO.Max(x => x.id)));
            }
            var Graficos = dbGrafico.GRAFICO.Where(x => aux.Contains(x.id)).ToList();

            //var Graficos = dbGrafico.GRAFICO.ToList();
            
            List<GRAFICO> listaGraficos = new List<GRAFICO>();
            for (int i = 0; i < 15; i++)
            {
                listaGraficos.Add(Graficos[rand.Next(Graficos.Count)]);
            }
            ViewBag.Graficos = listaGraficos;
            return View();
        }

        public PartialViewResult menuLayout()
        {
            ViewBag.MenuLayout = new MENULAYOUT();
            return PartialView();
        }

        public ActionResult Dashboard(int id=100)
        {
            string url = dbGrafico.GRAFICO.Where(x => x.id == id).First().url;
            ViewBag.url = url;
            //ViewBag.url = "https://analytics.zoho.com/open-view/2395394000000697928";
            //string user = User.Identity.GetUserName();

            /*
            ViewBag.user = user;
            List<string> aux = correos.correos;
            if (!aux.Contains(user))
            {
                return View("Restriccion");
            }
            */
          
            return View();
        }
       

        public ActionResult ResultadoNiveles(int id = 10, int id2 = 1)
        {
            List<GRAFICO> Graficos = new List<GRAFICO>();
            switch (id2)
            {
                case 1:
                    Graficos = dbGrafico.GRAFICO.Where(x => x.CATEGORIA.PRODUCTO.SECTOR.INDUSTRIA_id == id).ToList();
                    break;
                case 2:
                    Graficos = dbGrafico.GRAFICO.Where(x => x.CATEGORIA.PRODUCTO.SECTOR_id == id).ToList();
                    break;
                case 3:
                    Graficos = dbGrafico.GRAFICO.Where(x => x.CATEGORIA.PRODUCTO_id == id).ToList();
                    break;
                case 4:
                    Graficos = dbGrafico.GRAFICO.Where(x => x.CATEGORIA_id == id).ToList();
                    break;
                default:
                    break;
            }
            //ViewBag.Resultado = dbGrafico.GRAFICO.Where(x => x.CATEGORIA.PRODUCTO.SECTOR.INDUSTRIA_id == id).ToList();
            //var Graficos = dbGrafico.GRAFICO.Where(x => x.CATEGORIA.PRODUCTO.SECTOR.INDUSTRIA_id == id).ToList();
            List<string> Paises = new List<string>();
            List<string> Temporalidad = new List<string>();
            List<string> Producto = new List<string>();
            List<string> Industria = new List<string>();
            List<string> Sector = new List<string>();
            List<string> Categoria = new List<string>();
            List<string> TipoGrafico = new List<string>();
            
                
                
            foreach (var item in Graficos)
            {
                if (!TipoGrafico.Contains(item.TIPO_GRAFICO.nombre))
                {
                    TipoGrafico.Add(item.TIPO_GRAFICO.nombre);
                }
                if (!Paises.Contains(item.TERRITORIO.nombre))
                {
                    Paises.Add(item.TERRITORIO.nombre);
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
            }
            ViewBag.Paises = Paises;
            ViewBag.Temporalidad = Temporalidad;
            ViewBag.Producto = Producto;
            ViewBag.Industria = Industria;
            ViewBag.Sector = Sector;
            ViewBag.Categoria = Categoria;
            ViewBag.Resultado = Graficos;
            ViewBag.TipoGrafico = TipoGrafico;
            return View("PaginaBusqueda");
        }
        
        public PartialViewResult VisualizarGraficos(int id =1234)
        {
            ViewBag.time1 = DateTime.Now;
            var rand = new Random();

            GRAFICO graf = new GRAFICO();
            try
            {
                graf = dbGrafico.GRAFICO.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                graf = null;
            }
            if (graf.TIPO_GRAFICO_id > 1 || graf == null)
            {
                var listaGraficoAuxiliar = dbGrafico.GRAFICO.Where(x => x.TIPO_GRAFICO_id < 3).ToList();
                graf = listaGraficoAuxiliar[rand.Next(listaGraficoAuxiliar.Count)];
            }
            ViewBag.Elemento = graf;//graficos
            // var listaAsociado = dbGrafico.PRODUCTO.Where(x => x.SECTOR_id == graf.CATEGORIA.PRODUCTO.SECTOR_id).ToList();
            //var listaAsociado = dbGrafico.GRAFICO.Where(x => x.CATEGORIA.PRODUCTO.SECTOR_id == graf.CATEGORIA.PRODUCTO.SECTOR_id).ToList();

            //List<int> aux = new List<int>();
            //for (int i = 0; i < 50; i++)
            //{
            //    aux.Add(rand.Next(dbGrafico.GRAFICO.Min(x => x.id), dbGrafico.GRAFICO.Max(x => x.id)));
            //}
            //var Graficos = dbGrafico.GRAFICO.Where(x => aux.Contains(x.id)).ToList();
            //ViewBag.Graficos = Graficos;//carrusel

            ViewBag.time2 = DateTime.Now;
            return PartialView();
        }

        public PartialViewResult ContenidoGrafico(int id)
        {
            var rand = new Random();
            GRAFICO graf = new GRAFICO();
            try
            {
                graf = dbGrafico.GRAFICO.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                graf = null;
            }
            if (graf.TIPO_GRAFICO_id > 1 || graf == null)
            {
                var listaGraficoAuxiliar = dbGrafico.GRAFICO.Where(x => x.TIPO_GRAFICO_id < 3).ToList();
                graf = listaGraficoAuxiliar[rand.Next(listaGraficoAuxiliar.Count)];
            }
            ViewBag.Elemento = graf;//graficos

            return PartialView();
        }
        public PartialViewResult CarrucelBusqueda(int id=2345)
        {

            var rand = new Random();
            GRAFICO graf = new GRAFICO();
            try
            {
                graf = dbGrafico.GRAFICO.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                graf = null;
            }
            if (graf.TIPO_GRAFICO_id > 1 || graf == null)
            {
                var listaGraficoAuxiliar = dbGrafico.GRAFICO.Where(x => x.TIPO_GRAFICO_id < 3).ToList();
                graf = listaGraficoAuxiliar[rand.Next(listaGraficoAuxiliar.Count)];
            }
            ViewBag.Elemento = graf;//graficos
           
            return PartialView();
        }

        public ActionResult index2(int id = 1234)
        {
            //int id = 1234;
            var rand = new Random();

            GRAFICO graf = new GRAFICO();
            try
            {
                graf = dbGrafico.GRAFICO.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                graf = null;
            }
            if (graf.TIPO_GRAFICO_id > 1 || graf == null)
            {
                var listaGraficoAuxiliar = dbGrafico.GRAFICO.Where(x => x.TIPO_GRAFICO_id < 3).ToList();
                graf = listaGraficoAuxiliar[rand.Next(listaGraficoAuxiliar.Count)];
            }
            ViewBag.Elemento = graf;//graficos
            return View();
        }

        public PartialViewResult tresRelacionados(int id)
        {

            var listaNum = dbGrafico.CATEGORIA.Where(x => x.id == id).First().auxiliar.Split(',');
            ViewBag.tresRelacionados = dbGrafico.GRAFICO.Where(x => listaNum.Contains(x.id.ToString())).ToList();
            return PartialView();
        }

        public PartialViewResult carruselRelacionados(int id)
        {
            var listaNum = dbGrafico.PRODUCTO.Where(x => x.id == id).First().auxiliar.Split(',');
            ViewBag.Carrusel = dbGrafico.GRAFICO.Where(x => listaNum.Contains(x.id.ToString())).ToList();
           

            return PartialView();
        }

        public ActionResult VivianIfram()
        {
            return View();
        }
    }
}