using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Service.Cotizacion.Api.Controllers;
        [Route("api/v1/[controller]")]

    public class MaterialPrimarioController: Controller
    {
        private readonly IMediator _mediator;

        public MaterialPrimarioController(IMediator mediator)
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
