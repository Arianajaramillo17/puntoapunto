using System;
using MediatR;
using Service.Cotizacion.Application.Repositories;
using Service.Cotizacion.Application.validacion;

namespace Service.Cotizacion.Application.Commands.CotizacionDetalle.Crear
{
	public class CrearCotizacionDetalleCommand : IRequest<ValidarRespuestaDTO<string>>
    {
       
        public CrearCotizacionDetalleCommand()
		{
		}

		public Guid MaterialTipoId { get; set; }
		public Guid CotizacionId { get; set; }
	}
}

