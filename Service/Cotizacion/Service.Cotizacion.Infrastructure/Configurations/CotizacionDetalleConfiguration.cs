using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.Cotizacion.Core.Entities;

namespace Service.Cotizacion.Infrastructure.Configurations
{
    public class CotizacionDetalleConfiguration
    {
              public  CotizacionDetalleConfiguration(EntityTypeBuilder<CotizacionDetalle> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.CotizacionDetalleId);


        }
    }
}