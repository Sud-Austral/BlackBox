using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class Producto_Shopify
    {
        public string ID { get; set; }
        public string NOMBRE { get; set; }
        public string SKU { get; set; }
        public string COMPROBANTE { get; set; }
        public string PRODUCT_ID { get; set; }

        public Producto_Shopify(JToken json, string comprobante)
        {
            ID = (string)json["variant_id"];
            NOMBRE = (string)json["name"];
            SKU = (string)json["sku"];
            PRODUCT_ID = (string)json["product_id"];
            COMPROBANTE = comprobante;
        }

        public Producto_Shopify(JToken json)
        {
            ID = (string)json["variant_id"];
            NOMBRE = (string)json["name"];
            SKU = (string)json["sku"];
            PRODUCT_ID = (string)json["product_id"];
        }

    }
}