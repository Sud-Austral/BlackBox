using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        //created_at
        public string FECHA_CREADO { get; set; }
        public DateTime FECHA_CREADO2 { get; set; }

        public Producto_Shopify(JToken json, string comprobante, JToken ORDEN)
        {
            ID = (string)json["variant_id"];
            NOMBRE = (string)json["name"];
            SKU = (string)json["sku"];
            PRODUCT_ID = (string)json["product_id"];
            FECHA_CREADO = (string)ORDEN["created_at"];
            //FECHA_CREADO2 = DateTime.ParseExact((string)ORDEN["created_at"],
            //            "MM-dd-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            COMPROBANTE = comprobante;
        }


        public Producto_Shopify(JToken json, string comprobante)
        {
            ID = (string)json["variant_id"];
            NOMBRE = (string)json["name"];
            SKU = (string)json["sku"];
            PRODUCT_ID = (string)json["product_id"];
            FECHA_CREADO = (string)json["created_at"];
            COMPROBANTE = comprobante;
        }

        public Producto_Shopify(JToken json)
        {
            ID = (string)json["variant_id"];
            NOMBRE = (string)json["name"];
            SKU = (string)json["sku"];
            PRODUCT_ID = (string)json["product_id"];
            FECHA_CREADO = (string)json["created_at"];
        }

    }
}