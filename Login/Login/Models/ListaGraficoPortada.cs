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
            Graficos.Add(new GraficoPortada("https://herokuinstance.herokuapp.com/"));
            
            Graficos.Add(new GraficoPortada("https://analytics.zoho.com/open-view/2395394000000824986?ZOHO_CRITERIA=%22Trasposicion_4.1%22.%22Id_Categor%C3%ADa%22%20%3D%20100105003"));

            
            var aux = new GraficoPortada();
            aux.url = "https://analytics.zoho.com/open-view/2395394000000943308?ZOHO_CRITERIA=%22Trasposicion_4.1%22.%22C%C3%B3digo_Regi%C3%B3n%22%20%3D%201";
            Graficos.Add(aux);
            Graficos.Add(new GraficoPortada("https://analytics.zoho.com/open-view/2395394000000943308?ZOHO_CRITERIA=%22Trasposicion_4.1%22.%22C%C3%B3digo_Regi%C3%B3n%22%20%3D%202"));
            Graficos.Add(new GraficoPortada("https://analytics.zoho.com/open-view/2395394000005736091?ZOHO_CRITERIA=%22Trasposicion_4.1%22.%22Id_Procesamiento%22%20%3D%202"));
            Graficos.Add(new GraficoPortada("https://analytics.zoho.com/open-view/2395394000006082576?ZOHO_CRITERIA=%22Trasposicion_4.2%22.%22ID_territorio%22%3D11"));
            Graficos.Add(new GraficoPortada("https://analytics.zoho.com/open-view/2395394000006082576?ZOHO_CRITERIA=%22Trasposicion_4.2%22.%22ID_territorio%22%3D89"));
            Graficos.Add(new GraficoPortada("https://analytics.zoho.com/open-view/2395394000006080903?ZOHO_CRITERIA=%22Trasposicion_4.2%22.%22Id_Categor%C3%ADa%22%20%3D%20100106002"));
            Graficos.Add(new GraficoPortada());
            
            //Graficos.Add(new GraficoPortada());
            
        }
    }
}