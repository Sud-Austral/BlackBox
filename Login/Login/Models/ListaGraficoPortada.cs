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
            var aux = new GraficoPortada();
            aux.url = "https://analytics.zoho.com/open-view/2395394000000943308?ZOHO_CRITERIA=%22Trasposicion_4.1%22.%22C%C3%B3digo_Regi%C3%B3n%22%20%3D%201";
            Graficos.Add(aux);
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(new GraficoPortada());
            Graficos.Add(aux);
        }
    }
}