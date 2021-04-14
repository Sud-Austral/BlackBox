//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Login.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GRAFICO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string titulo { get; set; }
        public string subtitulo { get; set; }
        public string tags { get; set; }
        public string url { get; set; }
        public string iso_pais { get; set; }
        public string nivel_administrativo { get; set; }
        public string descripcion_larga { get; set; }
        public string fecha_publicacion { get; set; }
        public string idioma { get; set; }
        public string responsable { get; set; }
        public string shopify { get; set; }
        public string auxiliar { get; set; }
        public string rango_edad { get; set; }
        public int CATEGORIA_id { get; set; }
        public int PARAMETRO_id { get; set; }
        public int DETALLE_id { get; set; }
        public int TERRITORIO_id { get; set; }
        public int TEMPORALIDAD_id { get; set; }
        public int TIPO_GRAFICO_id { get; set; }
        public int FUENTE_id { get; set; }
        public string unidad_medida { get; set; }
        public string tamanio_muestra { get; set; }
        public string caracteristica_especial { get; set; }
        public string auxiliar_1 { get; set; }
        public int RESPONSABLE_id { get; set; }
        public int UNIDAD_MEDIDA_id { get; set; }
    
        public virtual CATEGORIA CATEGORIA { get; set; }
        public virtual DETALLE DETALLE { get; set; }
        public virtual FUENTE FUENTE { get; set; }
        public virtual PARAMETRO PARAMETRO { get; set; }
        public virtual RESPONSABLE RESPONSABLE1 { get; set; }
        public virtual TEMPORALIDAD TEMPORALIDAD { get; set; }
        public virtual TERRITORIO TERRITORIO { get; set; }
        public virtual TIPO_GRAFICO TIPO_GRAFICO { get; set; }
        public virtual UNIDAD_MEDIDA UNIDAD_MEDIDA1 { get; set; }

        public string GetURL()
        {
            string industria_id = CATEGORIA.PRODUCTO.SECTOR.INDUSTRIA_id.ToString("D2");
            string sector_id = CATEGORIA.PRODUCTO.SECTOR_id.ToString("D2");
            string producto_id = CATEGORIA.PRODUCTO_id.ToString("D2");
            string categoria_id = CATEGORIA_id.ToString("D3");
            //https://raw.githubusercontent.com/Sud-Austral/MPG/main/Datos/001Agricultura/001001Agricultura/0010010001Palta/001001000100001Primera_Palta/paltas3.csv

            string industria_nombre = CATEGORIA.PRODUCTO.SECTOR.INDUSTRIA.nombre;
            string sector_nombre = CATEGORIA.PRODUCTO.SECTOR.nombre;
            string producto_nombre = CATEGORIA.PRODUCTO.nombre;
            string categoria_nombre = CATEGORIA.nombre;

            string salida = industria_id + industria_nombre + "/" +
                            sector_id + sector_nombre + "/" +
                            producto_id + producto_nombre + "/" +
                            categoria_id + categoria_nombre + "/" +
                            url;
            string accentedStr = salida;
            byte[] tempBytes;
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr);
            string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);
            salida = asciiStr.ToLower();
            return salida.Replace(" ", "_");
        }
    }
}
