using System;
using System.Linq.Expressions;
using Common.Application.Helpers;
using MediatR;
using Service.Cotizacion.Application.Repositories;
using Service.Cotizacion.Application.validacion;
using Entity = Service.Cotizacion.Core.Entities;

namespace Service.Cotizacion.Application.Commands.CotizacionDetalle.Crear
{
	public class CrearCotizacionDetallesCommandHandler : IRequestHandler< CrearCotizacionDetalleCommand ,ValidarRespuestaDTO<string>>
	{
        private readonly ICotizacionRepository _cotizacionRepository;
        private readonly IEstadoCotizacionRepository _estadoCotizacionRepository;
        private readonly ICotizacionDetalleRepository _cotizacionDetalleRepository;
        private readonly DateTimeHelper dateTimeHelper = new DateTimeHelper();
        public CrearCotizacionDetallesCommandHandler(ICotizacionRepository cotizacionRepository,
            IEstadoCotizacionRepository estadoCotizacionRepository,
            ICotizacionDetalleRepository cotizacionDetalleRepository)
        {
            _cotizacionRepository = cotizacionRepository;
            _estadoCotizacionRepository = estadoCotizacionRepository;
            _cotizacionDetalleRepository = cotizacionDetalleRepository;
        }

        public async Task<ValidarRespuestaDTO<string>> Handle(CrearCotizacionDetalleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ValidarRespuestaDTO<string> respuestaDTO = new ValidarRespuestaDTO<string>();

                Expression<Func<Entity.CotizacionDetalle, Boolean>> param = x => x.Deleted == null && x.MaterialPrimarioId == request.MaterialTipoId && x.CotizacionId == request.CotizacionId;

                var ECot = await _cotizacionDetalleRepository.GetEntityAsync(param);

                if (ECot != null)
                {
                    Entity.CotizacionDetalle coti = new Entity.CotizacionDetalle
                    {
                        CotizacionId = request.CotizacionId,
                       CotizacionDetalleId= Guid.NewGuid(),
                       MaterialPrimarioId=request.MaterialTipoId,
                       Created=dateTimeHelper.DatePst(),

                    };
                    await _cotizacionDetalleRepository.AddAsync(coti);
                    respuestaDTO = new ValidarRespuestaDTO<string>
                    {
                        Mensaje = "Detalle creado con exito.",
                        Success = true
                    };
                }
                else
                {
                    respuestaDTO = new ValidarRespuestaDTO<string>
                    {
                        Mensaje = "Detalle registrado previamente",
                        Success = true
                    };
                }

                return respuestaDTO;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}

