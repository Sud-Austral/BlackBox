﻿using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class Data_UsuarioController : Controller
    {
        private graficosEntities dbGrafico = new graficosEntities();
        // GET: Data_Usuario
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Data_UsuarioGrafico(decimal id = 1234)
        {
            ViewBag.time1 = DateTime.Now;
            var rand = new Random();
            DATA_GRAFICO graf = new DATA_GRAFICO();
            try
            {
                graf = dbGrafico.DATA_GRAFICO.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                graf = null;
            }
            if (graf.TIPO_GRAFICO_id > 1 || graf == null)
            {
                var listaGraficoAuxiliar = dbGrafico.DATA_GRAFICO.Where(x => x.TIPO_GRAFICO_id < 3).ToList();
                graf = listaGraficoAuxiliar[rand.Next(listaGraficoAuxiliar.Count)];
            }
            ViewBag.Elemento = graf;//graficos
            // var listaAsociado = dbGrafico.PRODUCTO.Where(x => x.SECTOR_id == graf.CATEGORIA.PRODUCTO.SECTOR_id).ToList();
            //var listaAsociado = dbGrafico.DATA_GRAFICO.Where(x => x.CATEGORIA.PRODUCTO.SECTOR_id == graf.CATEGORIA.PRODUCTO.SECTOR_id).ToList();

            //List<int> aux = new List<int>();
            //for (int i = 0; i < 50; i++)
            //{
            //    aux.Add(rand.Next(dbGrafico.DATA_GRAFICO.Min(x => x.id), dbGrafico.DATA_GRAFICO.Max(x => x.id)));
            //}
            //var Graficos = dbGrafico.DATA_GRAFICO.Where(x => aux.Contains(x.id)).ToList();
            //ViewBag.Graficos = Graficos;//carrusel
            ViewBag.time2 = DateTime.Now;
            return PartialView();
        }
        public PartialViewResult VisualizarGraficoColecion_Usuario()
        {
            return PartialView();
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
    }
}