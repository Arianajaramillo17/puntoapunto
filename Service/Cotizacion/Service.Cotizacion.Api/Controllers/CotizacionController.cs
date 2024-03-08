using System;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Service.Cotizacion.Api.Controllers
{    [Route("api/v1/[controller]")]

    public class CotizacionController:Controller
    {
                private readonly IMediator _mediator;

        public CotizacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

    }
}