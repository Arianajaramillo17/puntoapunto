﻿using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace Service.Cotizacion.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }

}

