using System;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Cotizacion.Application.Commands.Cotizacion.Crear;
using Service.Cotizacion.Application.Commands.Cotizacion.Editar;
using Service.Cotizacion.Application.Commands.CotizacionDetalle.Crear;
using Service.Cotizacion.Application.validacion;

namespace Service.Cotizacion.Api.Controllers
{    [Route("api/v1/[controller]")]

    public class CotizacionDetalleController:Controller
    {
                private readonly IMediator _mediator;
        public CotizacionDetalleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CrearCotizacionDetalle", Name = "CrearCotizacionDetalle")]
        [ProducesResponseType(typeof(ValidarRespuestaDTO<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ValidarRespuestaDTO<string>>> CrearMarca([FromBody] CrearCotizacionDetalleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }
        //[HttpPut("EditarCotizacionDetalle", Name = "EditarCotizacionDetalle")]
        //[ProducesResponseType(typeof(ValidarRespuestaDTO<string>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<ValidarRespuestaDTO<string>>> EditarPersona([FromBody] EditarCotizacionCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}
    }
}