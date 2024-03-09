using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Base;

namespace Service.Cotizacion.Core.Entities
{
    public class Cotizacion:EntityBase
    {

      public Guid  CotizacionId { get; set; }   
      public string Detalle { get; set; } 
      public Guid  EstadoCotizacionId { get; set; }   

     public EstadoCotizacion EstadoCotizacion   { get; set; }   
  

    }
}