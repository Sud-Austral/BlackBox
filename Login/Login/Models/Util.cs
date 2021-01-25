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
            DateTime fechaInicio = DateTime.Now;
            try
            {
                fechaInicio = DateTime.Parse(fecha);
            }
            catch (Exception)
            {
                return false;
            }            
            DateTime fechaActual = DateTime.Now;
            //Calculo de dias.
            TimeSpan td = fechaActual - fechaInicio;
            salida = td.Days <= cantidadDias;
            return salida;
        }

        public static bool fechaLimite(string fecha, int cantidadDias)
        {
            bool salida = false;
            //int cantidadDias = 1;
            DateTime fechaInicio = DateTime.Now;
            try
            {
                fechaInicio = DateTime.Parse(fecha);
            }
            catch (Exception)
            {
                return false;
            }
            DateTime fechaActual = DateTime.Now;
            //Calculo de dias.
            TimeSpan td = fechaActual - fechaInicio;
            salida = td.Days <= cantidadDias;
            return salida;
        }

        public static bool fechaLimite(string fecha, string nombre)
        {
            if (!nombre.Contains("mensual"))
            {
                return true;
            }
            bool salida = false;
            //int cantidadDias = 1;
            DateTime fechaInicio = DateTime.Now;
            try
            {
                fechaInicio = DateTime.Parse(fecha);
            }
            catch (Exception)
            {
                return false;
            }
            DateTime fechaActual = DateTime.Now;
            //Calculo de dias.
            TimeSpan td = fechaActual - fechaInicio;
            salida = td.Days <= 32;
            return salida;
        }
    }
}