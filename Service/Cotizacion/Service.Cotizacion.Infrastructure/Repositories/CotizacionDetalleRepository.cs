using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity = Service.Cotizacion.Core.Entities;
using Service.Cotizacion.Application.Repositories;
namespace Service.Cotizacion.Infrastructure.Repositories
{
    public class CotizacionDetalleRepository: RepositoryBase<Entity.CotizacionDetalle>,ICotizacionDetalleRepository
    {
           public CotizacionDetalleRepository(CotizacionDbContext dbContext):base(dbContext)
        {
        }
    }
}