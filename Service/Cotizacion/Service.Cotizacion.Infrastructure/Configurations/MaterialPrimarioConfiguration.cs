using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Cotizacion.Core.Entities;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Service.Cotizacion.Infrastructure.Configurations
{
    public class MaterialPrimarioConfiguration
    {
               public MaterialPrimarioConfiguration(EntityTypeBuilder<MaterialPrimario> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.MaterialPrimarioId);


        }
    }
}