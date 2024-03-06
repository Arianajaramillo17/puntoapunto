using System;
using System.Collections.Generic;
using System.Globalization;
using static Common.Core.DTO.BaseDTO;
namespace Common.Application.Helpers
{
     public class BaseHelper
    {
        public static CultureInfo CultureInfoEs = new CultureInfo("es-ES");

        public List<DiaDTO> GetDiasMesAnioIntervalo(DateTime fechaInicio, DateTime fechaFin)
        {
            var dates = new List<DiaDTO>();
            var date = fechaInicio;
            int excp = 1;
            int month = fechaInicio.Month;

            //Loop desde el primer día del mes hasta que alcancemos el mes siguiente, avanzando un día a la vez
            for (int i = 0; date < fechaFin; i++)
            {
                try
                {
                    date = fechaInicio.AddDays(i);
                }
                catch
                {
                    month++;
                    date = new DateTime(DateTime.Now.Year, month, excp);
                    excp = 1;
                }
                var dia = new DiaDTO
                {
                    Nombre = String.Format("{0:dd-MM}", date),
                    NroDia = i,
                    Fecha = date
                };

                dates.Add(dia);
            }

            return dates;
        }
    }
}