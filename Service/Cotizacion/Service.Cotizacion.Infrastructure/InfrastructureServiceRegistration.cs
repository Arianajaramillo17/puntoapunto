using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Cotizacion.Infrastructure.Repositories;
using Common.Application;
namespace Service.Cotizacion.Infrastructure
{


    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
              this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CotizacionDbContext>(opts => opts.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection"),
                  x => x.MigrationsHistoryTable("__EFMigrationHistory", "crm")

            //la cadena de conexion

            ));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
      

            return services; 
        }
    }
}

