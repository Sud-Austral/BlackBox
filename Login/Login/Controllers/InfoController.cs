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
        public ActionResult PaginaBusqueda(string id = "1")
        {
            ViewBag.Resultado = dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id)).ToList();

            List<string> Paises = new List<string>();
            foreach (var item in dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id)).ToList())
            {
                if (!Paises.Contains(item.TERRITORIO.nombre))
                {
                    Paises.Add(item.TERRITORIO.nombre);
                }
            }
            ViewBag.Paises = Paises;

            List<string> Temporalidad = new List<string>();
            foreach (var item2 in dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id)).ToList())
            {
                if (!Temporalidad.Contains(item2.TEMPORALIDAD.nombre))
                {
                    Temporalidad.Add(item2.TEMPORALIDAD.nombre);
                }
            }
            ViewBag.Temporalidad = Temporalidad;

            List<string> Producto = new List<string>();
            foreach (var item3 in dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id)).ToList())
            {
                if (!Producto.Contains(item3.CATEGORIA.PRODUCTO.nombre))
                {
                    Producto.Add(item3.CATEGORIA.PRODUCTO.nombre);
                }
            }
            ViewBag.Producto = Producto;

            List<string> Industria = new List<string>();
            foreach (var item5 in dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id)).ToList())
            {
                if (!Industria.Contains(item5.CATEGORIA.PRODUCTO.SECTOR.INDUSTRIA.nombre))
                {
                    Industria.Add(item5.CATEGORIA.PRODUCTO.SECTOR.INDUSTRIA.nombre);
                }
            }
            ViewBag.Industria = Industria;


            List<string> Sector = new List<string>();
            foreach (var item4 in dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id)).ToList())
            {
                if (!Sector.Contains(item4.CATEGORIA.PRODUCTO.SECTOR.nombre))
                {
                    Sector.Add(item4.CATEGORIA.PRODUCTO.SECTOR.nombre);
                }
            }
            ViewBag.Sector = Sector;


            List<string> Categoria = new List<string>();
            foreach (var item6 in dbGrafico.GRAFICO.Where(x => x.nombre.Contains(id)).ToList())
            {
                if (!Categoria.Contains(item6.CATEGORIA.nombre))
                {
                    Categoria.Add(item6.CATEGORIA.nombre);
                }
            }
            ViewBag.Categoria = Categoria;
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

    }
}