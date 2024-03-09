using System;
using MediatR;
using Service.Cotizacion.Application.validacion;

namespace Service.Cotizacion.Application.Commands.Cotizacion.Editar
{
	public class EditarCotizacionCommand : IRequest<ValidarRespuestaDTO<string>>
    {
		public EditarCotizacionCommand()
		{
		}
        public string Detalle { get; set; }
        public Guid CotizacionId { get; set; }

    }
}

