using System;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Service.Cotizacion.Api.Controllers
{    [Route("api/v1/[controller]")]
        private readonly IMediator _mediator;

    public class MaterialPrimarioController:Controller
    {        private readonly IMediator _mediator;
        public MaterialPrimarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}