using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionBlanco.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public Cliente cliente { get; set; }
        public Producto producto { get; set; }

        public Pedido(int id, Cliente cliente, Producto producto)
        {
            this.id = id;
            this.cliente = cliente;
            this.producto = producto;
        }
    }
}