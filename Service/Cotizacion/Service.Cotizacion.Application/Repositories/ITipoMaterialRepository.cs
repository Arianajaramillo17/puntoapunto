using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Entity = Service.Cotizacion.Core.Entities;
using  Service.Cotizacion.Application.Repositories;

namespace Service.Cotizacion.Application.Repositories
{
    public interface ITipoMaterialRepository:IRepositoryBase<Entity.TipoMaterial>
    {
        
    }
}