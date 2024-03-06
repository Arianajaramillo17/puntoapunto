using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
namespace Common.Application.Helpers
{
     public class DateTimeHelper
    {
        public DateTimeHelper() { }

        public DateTime ParseDateFromStringSpanish(string fechax)
        {
            string[] toFecha = fechax.Split('/');
            var fecha = new DateTime(
                Convert.ToInt32(toFecha[2]),
                Convert.ToInt32(toFecha[1]),
                Convert.ToInt32(toFecha[0])
            ).Date;

            return fecha;
        }

        /// <summary>
        /// Parses the date time from string.
        /// </summary>
        /// <returns>The date time from string 1993/02/22 05:33:23.</returns>
        /// <param name="fechax">Formato de fecha: 1993,02,22,05,33,23</param>
        public DateTime ParseDateTimeFromString(string fechax)
        {
            string[] toFecha = fechax.Split(',');
            var fecha = new DateTime(
                Convert.ToInt32(toFecha[0]),
                Convert.ToInt32(toFecha[1]),
                Convert.ToInt32(toFecha[2]),
                Convert.ToInt32(toFecha[3]),
                Convert.ToInt32(toFecha[4]),
                Convert.ToInt32(toFecha[5])
            );

            return fecha;
        }

        public DateTime ParseDateFromString(string fechax)
        {
            //if(!String.IsNullOrEmpty(fechax)){
            string[] toFecha = fechax.Split(',');
            var fecha = new DateTime(
                Convert.ToInt32(toFecha[0]),
                Convert.ToInt32(toFecha[1]),
                Convert.ToInt32(toFecha[2])
            ).Date;

            return fecha;
            //}
            //return null;
        }

        public DateTime? ParseDateFromStringNullable(string fechax)
        {
            if (!String.IsNullOrEmpty(fechax))
            {
                string[] toFecha = fechax.Split(',');
                var fecha = new DateTime(
                    Convert.ToInt32(toFecha[0]),
                    Convert.ToInt32(toFecha[1]),
                    Convert.ToInt32(toFecha[2])
                ).Date;

                return fecha;
            }
            return null;
        }

        /**Parse DD/MM/YY to DateTime */
        public DateTime? ParseDateFromStringNullableSpanish(string fechax)
        {
            if (!String.IsNullOrEmpty(fechax))
            {
                string[] toFecha = fechax.Split('/');
                var fecha = new DateTime(
                    Convert.ToInt32(toFecha[2]),
                    Convert.ToInt32(toFecha[1]),
                    Convert.ToInt32(toFecha[0])
                ).Date;
                return fecha;
            }

            return null;
        }

        public DateTime? ParseDateTimeFromTalentLMS(string fechax)
        {
            if (String.IsNullOrEmpty(fechax))
            {
                return null;
            }

            string[] toFecha = fechax.Split(',');

            string[] fecha = toFecha[0].Split('/');
            string[] hora = toFecha[1].Split(':');

            var fechaValue = new DateTime(
                Convert.ToInt32(fecha[2]),
                Convert.ToInt32(fecha[1]),
                Convert.ToInt32(fecha[0]),
                Convert.ToInt32(hora[0]),
                Convert.ToInt32(hora[1]),
                Convert.ToInt32(hora[2])
            );

            return fechaValue;
        }

        public DateTime DateTimePst()
        {
            try
            {
                DateTime fServer = DateTime.UtcNow;
                TimeZoneInfo timeLima = TimeZoneInfo.FindSystemTimeZoneById(
                    "SA Pacific Standard Time"
                );
                return fServer = TimeZoneInfo.ConvertTimeFromUtc(fServer, timeLima);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// FECHA LOCAL CON FORMATO DE ZONA HORARIA PACIFIC STANDARD TIME
        /// </summary>
        /// <returns></returns>
        public DateTime DatePst()
        {
            try
            {
                DateTime fServer = DateTime.UtcNow;
                TimeZoneInfo timeLima = TimeZoneInfo.FindSystemTimeZoneById(
                    "SA Pacific Standard Time"
                );
                fServer = TimeZoneInfo.ConvertTimeFromUtc(fServer, timeLima);
                DateTime date = new DateTime(fServer.Year, fServer.Month, fServer.Day);
                return date;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public string FormatDateTo(DateTime? fecha, string formato = "")
        {
            if (fecha == null)
                return "";

            string result = default(string);

            switch (formato)
            {
                case "12":
                    result = $"{fecha:dd/MM/yyyy hh:mm tt}";
                    break;
                case "24":
                    result = $"{fecha:dd/MM/yyyy HH:mm}";
                    break;
                case ",":
                    result = $"{fecha:yyyy,MM,dd}";
                    break;
                case "H":
                    result = $"{fecha:HH:mm}";
                    break;
                case "s":
                    result = $"{fecha:dd/MM/yyyy HH:mm:ss}";
                    break;
                default:
                    result = $"{fecha:dd/MM/yyyy}";
                    break;
            }

            return result;
        }

        public string FormatTick(Int64 ticks, string format)
        {
            var retorno = "";
            switch (format)
            {
                case "H":
                    int diasST = TimeSpan.FromTicks(ticks).Days;
                    var horasST = TimeSpan.FromTicks(ticks).Hours + (diasST * 24);
                    var minutosST = TimeSpan.FromTicks(ticks).Minutes;

                    retorno =
                        horasST.ToString("00") + ":" + System.Math.Abs(minutosST).ToString("00");
                    break;
                default:
                    retorno = "";
                    break;
            }
            return retorno;
        }

        public string FormatTickNull(TimeSpan? ticks)
        {
            if (ticks != null)
            {
                TimeSpan timeSpan = ticks.Value;
                DateTime localTime = DateTime.Today.Add(timeSpan);
                string formattedTime = localTime.ToString("HH:mm");
                return formattedTime;
            }

            return null;
        }

        public TimeSpan ParseTimeFromString(string hora)
        {
            string[] toFecha = hora.Split(':');
            var fecha = new TimeSpan(Convert.ToInt32(toFecha[0]), Convert.ToInt32(toFecha[1]), 0);

            return fecha;
        }

        public DateTime? ParseDateFromStringISO(string fechax)
        {
            if (!String.IsNullOrEmpty(fechax))
            {
                string[] toFecha = fechax.Split('-');
                var fecha = new DateTime(
                    Convert.ToInt32(toFecha[0]),
                    Convert.ToInt32(toFecha[1]),
                    Convert.ToInt32(toFecha[2])
                ).Date;

                return fecha;
            }
            return null;
        }

        public string ParseDateTimeToHora(DateTime? fecha)
        {
            if (fecha == null)
            {
                return null;
            }
            var result = $"{fecha:dd/MM/yyyy hh:mm tt}";
            string[] toFecha = result.Split(' ');

            return $"{toFecha[1]} {toFecha[2]}";
        }

        public DateTime ParseDateFromStringTime(string fechax)
        {
            //if(!String.IsNullOrEmpty(fechax)){
            string[] toFecha = fechax.Split(',');
            var fecha = new DateTime(
                Convert.ToInt32(toFecha[0]),
                Convert.ToInt32(toFecha[1]),
                Convert.ToInt32(toFecha[2]),
                0,
                0,
                0
            );

            return fecha;
            //}
            //return null;
        }
public DateTime DateTimeFromADMS(string fechax)
        {
            try
            {
                string[] toFecha = fechax.Split(' ');
                string[] fecha = toFecha[0].Split('-');
                string[] tiempo = toFecha[1].Split(':');

                var fechav = new DateTime(
                    Convert.ToInt32(fecha[0]),
                    Convert.ToInt32(fecha[1]),
                    Convert.ToInt32(fecha[2]),
                    Convert.ToInt32(tiempo[0]),
                    Convert.ToInt32(tiempo[1]),
                    Convert.ToInt32(tiempo[2])
                );

                return fechav;
            }
            catch (Exception /*e*/
            )
            {
                return DateTimePst();
            }
        }

        public String DateTimeResta(DateTime fechaRegistro, DateTime fechaActual)
        {
            TimeSpan resultadoResta = fechaActual.Subtract(fechaRegistro); //Con String.Emmpy es igual que ""

            string dias = resultadoResta.Days.ToString();
            int diasEnHoras = int.Parse(dias) * 24;
            string horas = resultadoResta.Hours.ToString();
            int totalHoras = int.Parse(horas) + diasEnHoras - 5;
            string minutos = resultadoResta.Minutes.ToString();
            string segundos = resultadoResta.Seconds.ToString();

            return totalHoras.ToString() + ":" + minutos + ":" + segundos;
        }

        public string RestaFechaEnHora(DateTime fecha1, DateTime fecha2, int horas)
        {
            if (
                !string.IsNullOrEmpty(fecha1.ToString()) || !string.IsNullOrEmpty(fecha2.ToString())
            )
            {
                DateTime sum = fecha1.AddHours(horas);
                TimeSpan result = fecha2.Subtract(sum);
                return result.ToString();
            }
            return "";
        }

        public TimeSpan ParseTimeSpanFromString(string time)
        {
            if (!String.IsNullOrEmpty(time))
            {
                string[] toFecha = time.Split(':'); //04:30
                TimeSpan fecha = new TimeSpan(
                    Convert.ToInt32(toFecha[0]),
                    Convert.ToInt32(toFecha[1]),
                    0
                );

                return fecha;
            }
            return TimeSpan.MinValue;
        }

        public string FormatDateTimeOffsetTo(DateTimeOffset? fecha, string formato = "")
        {
            DateTimeOffset offsetDate = fecha.Value;
            DateTime fecha1 = offsetDate.DateTime;

            if (fecha1 == null)
                return "";

            string result = default(string);

            switch (formato)
            {
                case "12":
                    result = $"{fecha1:dd/MM/yyyy hh:mm tt}";
                    break;
                case "24":
                    result = $"{fecha1:dd/MM/yyyy HH:mm}";
                    break;
                case ",":
                    result = $"{fecha1:yyyy,MM,dd}";
                    break;
                case "H":
                    result = $"{fecha1:HH:mm}";
                    break;
                case "s":
                    result = $"{fecha1:dd/MM/yyyy HH:mm:ss}";
                    break;
                default:
                    result = $"{fecha1:dd/MM/yyyy}";
                    break;
            }

            return result;
        }


    }
}