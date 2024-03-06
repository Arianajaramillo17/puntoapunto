using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Common.Core.Base;
using Enty= Service.Cotizacion.Core.Entities.TipoMaterial;
namespace Service.Cotizacion.Core.Entities
{
    public class MaterialPrimario:EntityBase
    {
         public Guid MaterialPrimarioId { get; set; }
        public String Nombre { get; set; }
        public Guid TipoMaterialId { get; set; }
        public Enty TipoMaterial { get; set; }
	
        public Double Precio { get; set; }

        public ICollection<CotizacionDetalle> CotizacionDetalles{get; set;}

    }
}