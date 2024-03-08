using System;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Service.Cotizacion.Api.Controllers
{    [Route("api/v1/[controller]")]

    public class EstadoCotizacionController:Controller
    {        private readonly IMediator _mediator;

        public EstadoCotizacionController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}