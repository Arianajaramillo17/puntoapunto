using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Entity = Service.Cotizacion.Core.Entities;
namespace Service.Cotizacion.Application.Repositories
{
    public interface IMaterialPrimarioRepository:IRepositoryBase<Entity.MaterialPrimario>
    {
        
    }
}