using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Core.DTO
{
   
         public class BaseDTO
    {
        public class TableDTO<T>
        {
            public int Total { get; set; }
            public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();
            public string Mensaje { get; set; }
        }
        public class InfoDTO<T>
        {
            public T Data { get; set; }
            public string Color { get; set; }
        }
        public class DiaDTO
        {
            public string Nombre { get; set; }
            public int NroDia { get; set; }
            public DateTime Fecha { get; set; }
        }
    }
}
