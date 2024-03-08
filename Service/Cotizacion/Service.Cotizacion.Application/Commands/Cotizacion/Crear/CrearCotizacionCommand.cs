using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using  Service.Cotizacion.Application.validacion;
namespace Service.Cotizacion.Application.Commands.Cotizacion.Crear
{
    public class CrearCotizacionCommand:IRequest<ValidarRespuestaDTO<string>>
    {
        public CrearCotizacionCommand()
        {

        }
        public string Detalle { get; set; }
    }
}