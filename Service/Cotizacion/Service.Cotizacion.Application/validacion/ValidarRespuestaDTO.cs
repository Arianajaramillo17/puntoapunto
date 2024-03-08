using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Service.Cotizacion.Application.validacion
{
   
	public class ValidarRespuestaDTO<T>
    {
		public ValidarRespuestaDTO()
		{
		}
		public bool Success { get; set; }
        public string Mensaje { get; set; }
		public T? Data { get; set; }

    }
}