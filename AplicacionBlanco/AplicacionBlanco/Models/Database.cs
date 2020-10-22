using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionBlanco.Models
{
    public class Database
    {
        public List<Pedido> pedidos;

        public Database()
        {
            Producto producto1 = new Producto("1", "https://training-dataintelligence.odoo.com", "Test");
            Producto producto2 = new Producto("2", "https://training-dataintelligence.odoo.com/forum/ayuda-1", "Test");
            Producto producto3 = new Producto("3", "http://52.173.85.103:8069/test1", "Test");
            Cliente cliente1 = new Cliente("1", "Test1");
            Cliente cliente2 = new Cliente("2", "Test2");
            //Pedido pedido1 = new Pedido(1, cliente1, producto1);
            this.pedidos = new List<Pedido>();
            pedidos.Add(new Pedido(1, cliente1, producto1));
            pedidos.Add(new Pedido(2, cliente1, producto2));
            pedidos.Add(new Pedido(3, cliente1, producto3));
           // pedidos.Add(new Pedido(4, cliente2, producto1));
            pedidos.Add(new Pedido(5, cliente2, producto2));
        }
    }
}