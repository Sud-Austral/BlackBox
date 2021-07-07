using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class ListaGraficoPortada
    {
        public List<GraficoPortada> Graficos { get; set; }

        public ListaGraficoPortada()
        {
            Graficos = new List<GraficoPortada>();
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
        }
    }
}