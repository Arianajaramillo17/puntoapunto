using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Base;
namespace Service.Cotizacion.Core.Entities
{
    public class EstadoCotizacion:EntityBase
    {
        
        public Guid EstadoCotizacionId { get; set; }
        public String Nombre { get; set; }
        public String Codigo { get; set; }
        public ICollection<Cotizacion> Cotizaciones { get; set; }
 
    }                                                                                
}