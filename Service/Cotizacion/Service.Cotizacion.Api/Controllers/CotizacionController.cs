using System;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Cotizacion.Application.Commands.Cotizacion.Crear;
using Service.Cotizacion.Application.validacion;

namespace Service.Cotizacion.Api.Controllers
{
    [Route("api/v1/[controller]")]

    public class CotizacionController : Controller
    {
        private readonly IMediator _mediator;

        public CotizacionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CrearCotizacion", Name = "CrearCotizacion")]
        [ProducesResponseType(typeof(ValidarRespuestaDTO<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ValidarRespuestaDTO<string>>> CrearMarca([FromBody] CrearCotizacionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }
    }
}