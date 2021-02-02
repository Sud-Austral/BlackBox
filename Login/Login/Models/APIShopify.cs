﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Login.Models
{
    public class APIShopify
    {
        public static JObject BuscarOrden(string orden)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //var url = "https://5b4e5f28876dd9a9bdbc6b1e0b2d6de0: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@data-intelligence.myshopify.com/admin/api/2021-01/orders.json";
            string url = "https://data-intelligence.myshopify.com/admin/api/2021-01/orders/" + orden + ".json";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers["X-Shopify-Access-Token"] = "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";
            //HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            JObject json = JObject.Parse(responseBody);
                            return json; //.GetValue("orders").Count();   //[0];
                            // Do something with responseBody
                            //Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return null;
                // Handle error
            }
            //return View();
        }

        public static bool ValidarCorreo(string orden, string correo)
        {
            JObject json = BuscarOrden(orden);
            if(json == null)
            {
                return false;
            }
            return JObject.Parse(json.GetValue("order").ToString()).GetValue("email").ToString() == correo;
        }
    }
}