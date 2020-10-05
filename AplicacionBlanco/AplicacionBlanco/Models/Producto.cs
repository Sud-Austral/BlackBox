using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionBlanco.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string url { get; set; }
        public string nombre { get; set; }

        public Producto(int id, string url, string nombre)
        {
            this.id = id;
            this.url = url;
            this.nombre = nombre;
        }
    }
}