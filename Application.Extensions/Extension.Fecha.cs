using System;

namespace Application.Extensions
{
    public class Fecha
    {
        public static string ToShortDate(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }

        public static string ToShortTime(DateTime fecha)
        {
            return fecha.ToShortTimeString();
        }

        public static int DiferenciaEnDias(DateTime fechaInicio, DateTime fechaFin)
        {
            return fechaFin.Subtract(fechaInicio).Days;
        }
    }
}
