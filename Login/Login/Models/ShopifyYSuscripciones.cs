using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class ShopifyYSuscripciones
    {
        public List<Producto_Shopify> producto_Shopifies { get; set; }
        public List<int> industrias { get; set; }
        public List<Suscripcion> suscripcions { get; set; }

        public ShopifyYSuscripciones(List<Producto_Shopify> entrada)
        {
            this.producto_Shopifies = new List<Producto_Shopify>();
            this.industrias = new List<int>();
            this.suscripcions = new List<Suscripcion>();
            foreach (var item in entrada)
            {
                
                try
                {
                    if (item.SKU.Contains("datasuscripcion"))
                    {
                        int aux = Int32.Parse(item.SKU.Split('-')[2]);
                        string nivel = item.SKU.Split('-')[1];
                        this.industrias.Add(aux);
                        this.suscripcions.Add(new Suscripcion(aux, nivel));
                    }
                    else
                    {
                        this.producto_Shopifies.Add(item);
                    }
                }
                catch (Exception)
                {
                }
                
                
            }
        }
    }
}