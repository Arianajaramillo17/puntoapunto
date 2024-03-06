using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Base;
namespace Service.Cotizacion.Core.Entities
{
    public class CotizacionDetalle:EntityBase
    {
        public Guid CotizacionDetalleId { get; set; }
        public Guid CotizacionId { get; set; }
        public Cotizacion Cotizacion { get; set; }
         public Guid MaterialPrimarioId { get; set; }
        public MaterialPrimario MaterialPrimario { get; set; }
    }
}