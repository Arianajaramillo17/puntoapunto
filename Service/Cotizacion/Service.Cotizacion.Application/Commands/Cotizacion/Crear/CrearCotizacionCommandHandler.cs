using System.Linq.Expressions;
using Service.Cotizacion.Application.Repositories;
using Entity = Service.Cotizacion.Core.Entities;
using Service.Cotizacion.Application.validacion;
using MediatR;

namespace Service.Cotizacion.Application.Commands.Cotizacion.Crear
{
    public class CrearCotizacionCommandHandler:IRequestHandler<CrearCotizacionCommand,ValidarRespuestaDTO<string>>
    {
        private readonly ICotizacionRepository _cotizacionRepository;
        private readonly IEstadoCotizacionRepository _estadoCotizacionRepository;

        public CrearCotizacionCommandHandler(ICotizacionRepository cotizacionRepository,
            IEstadoCotizacionRepository estadoCotizacionRepository)
        {
            _cotizacionRepository = cotizacionRepository;
            _estadoCotizacionRepository = estadoCotizacionRepository;
        }
        public async Task<ValidarRespuestaDTO<string>> Handle(CrearCotizacionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ValidarRespuestaDTO<string> respuestaDTO = new ValidarRespuestaDTO<string>();
                Expression<Func<Entity.EstadoCotizacion, Boolean>> param = x => x.Deleted == null && x.Codigo == "01";

                var ECot = await _estadoCotizacionRepository.GetEntityAsync(param);

if (ECot != null)
{
     Entity.Cotizacion coti = new Entity.Cotizacion
                {
                    CotizacionId = Guid.NewGuid(),
                    Detalle = request.Detalle,
                    EstadoCotizacionId = ECot.EstadoCotizacionId,

                };
                await _cotizacionRepository.AddAsync(coti);
                respuestaDTO = new ValidarRespuestaDTO<string>
                {
                    Mensaje = "Cotización creada con exito.",
                    Success = true
                };}
else
{
    respuestaDTO = new ValidarRespuestaDTO<string>
                {
                    Mensaje = "Cotización sin exito de creado.",
                    Success = false
                };}
           
                return respuestaDTO;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }   
        }
    }
}