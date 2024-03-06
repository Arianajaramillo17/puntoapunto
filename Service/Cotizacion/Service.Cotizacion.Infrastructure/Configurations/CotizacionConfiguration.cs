using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Enty=Service.Cotizacion.Core.Entities;

namespace Service.Cotizacion.Infrastructure.Configurations
{
    public class CotizacionConfiguration
    {
          public  CotizacionConfiguration(EntityTypeBuilder<Enty.Cotizacion> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.CotizacionId);


        }
    }
}