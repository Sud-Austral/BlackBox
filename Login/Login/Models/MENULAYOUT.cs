using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class MENULAYOUT
    {
        private static graficosEntities dbGrafico = new graficosEntities();


        public static List<List<GRAFICO>> Menu()
        {
            //private graficosEntities dbGrafico = new graficosEntities();
            List<List<GRAFICO>> salida = new List<List<GRAFICO>>();
            foreach (var item in dbGrafico.INDUSTRIA)
            {
                List<GRAFICO> auxiliar = dbGrafico.GRAFICO.Where(x => x.CATEGORIA.PRODUCTO.SECTOR.INDUSTRIA_id == item.id).ToList();
                /*
                if (auxiliar.Count > 0)
                {

                }
                */
            }

            return salida;
        }
    }
}