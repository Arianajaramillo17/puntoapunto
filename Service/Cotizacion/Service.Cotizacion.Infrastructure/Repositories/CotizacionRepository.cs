using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Cotizacion.Application.Repositories;
using Entity = Service.Cotizacion.Core.Entities;
namespace Service.Cotizacion.Infrastructure.Repositories
{
    public class CotizacionRepository: RepositoryBase<Entity.Cotizacion>,ICotizacionRepository
    {
         public CotizacionRepository(CotizacionDbContext dbContext):base(dbContext)
    {
        
    }
    }
}