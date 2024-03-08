using System;
using System.Net;
using MediatR;
namespace Service.Cotizacion.Api.Controllers;

        [Route("api/v1/[controller]")]


    public class TipoMaterialController : Controller
    {
        private readonly IMediator _mediator;

        public TipoMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] // Example route for GET request
        public IActionResult Get()
        {
            // Your GET logic here
            return Ok("GET request handled");
        }
    }
