using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionBlanco.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Cliente()
        {

        }

        public Cliente(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}