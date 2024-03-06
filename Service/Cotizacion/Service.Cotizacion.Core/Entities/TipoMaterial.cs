using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Enty= Common.Core.Base.EntityBase;

namespace Service.Cotizacion.Core.Entities
{
    public class TipoMaterial:Enty
    {
         
        public Guid TipoMaterialId { get; set; }
        public String Nombre { get; set; }
        public String Codigo { get; set; }
        public ICollection<MaterialPrimario> Materiales { get; set; }
 
    }
}