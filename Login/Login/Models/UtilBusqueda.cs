using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class UtilBusqueda
    {
        private static graficosEntities dbGrafico = new graficosEntities();
        private static Random rand = new Random();


        public static IEnumerable<GRAFICO> PaginaBusqueda(string concepto)
        {
            var prioridad = dbGrafico.GRAFICO.SqlQuery("SELECT * FROM GRAFICO WHERE titulo LIKE '% " + concepto + " %'")
                                                .Take(200);
            
            IEnumerable<GRAFICO> NEW_GRAFICOS;
            IEnumerable<GRAFICO> union;
            if (prioridad.Count() < 200)
            {
                NEW_GRAFICOS = dbGrafico.GRAFICO.Where(x => x.nombre.Contains(concepto) || x.titulo.Contains(concepto) || x.tags.Contains(concepto))
                                                 .OrderBy(x => x.id)
                                                 .Take(200 - prioridad.Count());
                int ent = NEW_GRAFICOS.Count();
                union = prioridad.Concat(NEW_GRAFICOS); //.Distinct();

            }
            else
            {
                union = prioridad;
            }

            if(union.Count() == 0)
            {
                concepto = concepto.Substring(0, concepto.Length - 3);
                union = dbGrafico.GRAFICO.Where(x => x.nombre.Contains(concepto) || x.titulo.Contains(concepto) || x.tags.Contains(concepto))
                                                 .Take(200);
            }
            return union;
        }

        public static IEnumerable<GRAFICO> ResultadoNiveles(int id, int tabla)
        {
            IEnumerable<GRAFICO> Graficos;
            switch (tabla)
            {
                case 1:
                    Graficos = dbGrafico.GRAFICO.Where(x => x.CATEGORIA.PRODUCTO.SECTOR.INDUSTRIA_id == id).Take(200);
                    break;
                case 2:
                    Graficos = dbGrafico.GRAFICO.Where(x => x.CATEGORIA.PRODUCTO.SECTOR_id == id).Take(200);
                    break;
                case 3:
                    Graficos = dbGrafico.GRAFICO.Where(x => x.CATEGORIA.PRODUCTO_id == id).Take(200);
                    break;
                case 4:
                    Graficos = dbGrafico.GRAFICO.Where(x => x.CATEGORIA_id == id).Take(200);
                    break;
                default:
                    Graficos = dbGrafico.GRAFICO.Take(200);
                    break;
            }
            return Graficos;
        }


        public static List<GRAFICO> Relacionados3importantes(int id, int id2)
        {
            List<GRAFICO> aux = new List<GRAFICO>();
            var query = dbGrafico.GRAFICO.SqlQuery("SELECT TOP 20 * FROM grafico WHERE categoria_id = " + id.ToString() + " AND id <> " + id2.ToString()).ToList();           
            for (int i = 0; i < 3; i++)
            {
                aux.Add(query[rand.Next(query.Count())]);
            }
            return aux;
        }

        public static List<GRAFICO> Relacionados12Carrusel(int id, int id2)
        {
            List<GRAFICO> aux = new List<GRAFICO>();
            //SELECT* FROM grafico WHERE categoria_id IN(SELECT id FROM categoria WHERE PRODUCTO_id = 100101) AND id<> 1033
            var query = dbGrafico.GRAFICO.SqlQuery("SELECT TOP 50 * FROM grafico WHERE categoria_id IN (SELECT id FROM categoria WHERE PRODUCTO_id = " + id.ToString() + ") AND id <> " + id2.ToString()).ToList();
            for (int i = 0; i < 12; i++)
            {
                aux.Add(query[rand.Next(query.Count())]);
            }
            return aux;
        }

        public static List<GRAFICO> Relacionados3importantes(int id)
        {
            List<GRAFICO> aux = new List<GRAFICO>();
            var query = dbGrafico.GRAFICO.SqlQuery("SELECT TOP 20 * FROM grafico WHERE categoria_id = " + id.ToString()).ToList();
            for (int i = 0; i < 3; i++)
            {
                aux.Add(query[rand.Next(query.Count())]);
            }
            return aux;
        }

        public static List<GRAFICO> Relacionados12Carrusel(int id)
        {
            List<GRAFICO> aux = new List<GRAFICO>();
            //SELECT* FROM grafico WHERE categoria_id IN(SELECT id FROM categoria WHERE PRODUCTO_id = 100101) AND id<> 1033
            var query = dbGrafico.GRAFICO.SqlQuery("SELECT TOP 50 * FROM grafico WHERE categoria_id IN (SELECT id FROM categoria WHERE PRODUCTO_id = " + id.ToString() + ")").Take(50).ToList();
            for (int i = 0; i < 12; i++)
            {
                aux.Add(query[rand.Next(query.Count())]);
            }
            return aux;
        }
    }
}