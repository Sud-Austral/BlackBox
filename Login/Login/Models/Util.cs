using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class Util
    {
        public static bool fechaLimite(string fecha)
        {
            bool salida = false;
            int cantidadDias = 1;

            DateTime fechaInicio = DateTime.Parse(fecha);
            DateTime fechaActual = DateTime.Now;

            //Calculo de dias.
            TimeSpan td = fechaActual - fechaInicio;

            salida = td.Days <= cantidadDias;

            return salida;
        }
    }
}