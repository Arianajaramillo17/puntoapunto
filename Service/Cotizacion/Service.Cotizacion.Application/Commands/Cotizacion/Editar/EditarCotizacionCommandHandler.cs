using System;
using System.Linq.Expressions;
using MediatR;
using Service.Cotizacion.Application.Repositories;
using Service.Cotizacion.Application.validacion;
using Entity = Service.Cotizacion.Core.Entities;

namespace Service.Cotizacion.Application.Commands.Cotizacion.Editar;
public class EditarCotizacionCommandHandler : IRequestHandler<EditarCotizacionCommand, ValidarRespuestaDTO<string>>
{

private readonly ICotizacionRepository _cotizacionRepository;

public EditarCotizacionCommandHandler(
    ICotizacionRepository cotizacionRepository)
{
    _cotizacionRepository = cotizacionRepository;

}

public async Task<ValidarRespuestaDTO<string>> Handle(EditarCotizacionCommand request, CancellationToken cancellationToken)
    {
		try
		{
            ValidarRespuestaDTO<string> respuestaDTO = new ValidarRespuestaDTO<string>();
            Expression<Func<Entity.Cotizacion, Boolean>> param = x => x.Deleted == null && x.CotizacionId == request.CotizacionId;

            var ECot = await _cotizacionRepository.GetEntityAsync(param);

            if (ECot == null)
            {
                respuestaDTO = new ValidarRespuestaDTO<string>
                {
                    Mensaje = "Cotización no encontrada.",
                    Success = true
                };
                return respuestaDTO;

            }
        
            else
            {

                if (String.IsNullOrEmpty(request.Detalle))
                {
                    respuestaDTO = new ValidarRespuestaDTO<string>
                    {
                        Mensaje = "Sin data por editar.",
                        Success = true
                    };
                    return respuestaDTO;
                }
                else
                {
                    ECot.Detalle = request.Detalle;
                }
               await _cotizacionRepository.UpdateAsync(ECot);
            respuestaDTO = new ValidarRespuestaDTO<string>
            {
                Mensaje = "Cotización editada con exito.",
                Success = true
            };
            return respuestaDTO;

        }

    }catch(Exception e)
		{
			throw new Exception(e.ToString());
		}
    }
}


