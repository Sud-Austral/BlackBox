using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class GraficoPortada
    {
        public string url { get; set; }
        public string titulo { get; set; }
        public string ideaFuerza { get; set; }
        public string descripcion { get; set; }
        public string color { get; set; }

        public GraficoPortada(string url, string titulo, string ideaFuerza, string descripcion, string color)
        {
            this.url = url;
            this.titulo = titulo;
            this.ideaFuerza = ideaFuerza;
            this.descripcion = descripcion;
            this.color = color;
        }

        public GraficoPortada(string url, string titulo, string ideaFuerza, string descripcion)
        {
            this.url = url;
            this.titulo = titulo;
            this.ideaFuerza = ideaFuerza;
            this.descripcion = descripcion;
            this.color = "#e63a60";
        }

        public GraficoPortada()
        {
            this.url = "https://analytics.zoho.com/open-view/2395394000007224567";
            this.titulo = "Pandemia en Chile";
            this.ideaFuerza = "¡Iquique duplicó sus contagios en un año!";
            this.descripcion = "Texto de 25 palabras. Amet, consectetuer adipiscing elit, sed diam nonummy nibh "+
                               "euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Ut wisi enim ad.";
            this.color = "#e63a60";
        }

        public GraficoPortada(string url)
        {
            this.url = url;
            this.titulo = "Pandemia en Chile";
            this.ideaFuerza = "¡Iquique duplicó sus contagios en un año!";
            this.descripcion = "Texto de 25 palabras. Amet, consectetuer adipiscing elit, sed diam nonummy nibh " +
                               "euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.Ut wisi enim ad.";
            this.color = "#e63a60";
        }
    }
}