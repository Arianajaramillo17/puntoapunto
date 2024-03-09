using System;
using System.Linq.Expressions;
using MediatR;
using Service.Cotizacion.Application.Repositories;
using Entity = Service.Cotizacion.Core.Entities;

namespace Service.Cotizacion.Application.Queries.Cotizacion.ComboMaterialPrimario
{
	public class ComboMaterialPrimarioQueryHandler: IRequestHandler<ComboMaterialPrimarioQuery ,List<ComboMaterialPrimarioDTO>>
    {
        private readonly IMaterialPrimarioRepository _materialPrimarioRepository;
		public ComboMaterialPrimarioQueryHandler(IMaterialPrimarioRepository materialPrimarioRepository)
		{
            _materialPrimarioRepository = materialPrimarioRepository;
		}

        public async Task<List<ComboMaterialPrimarioDTO>> Handle(ComboMaterialPrimarioQuery request, CancellationToken cancellationToken)
        {
            try {
             
                List<ComboMaterialPrimarioDTO> data = new List<ComboMaterialPrimarioDTO>();
                Expression<Func<Entity.MaterialPrimario, bool>> fAct = x => x.Deleted == null;
                Func<IQueryable<Entity.MaterialPrimario>, IOrderedQueryable<Entity.MaterialPrimario>> orderby = x => (IOrderedQueryable<Entity.MaterialPrimario>)x.OrderBy(x => x.Nombre);
                var personaRegistro = await _materialPrimarioRepository.GetAsync(fAct, orderby);

                var list = personaRegistro.Select(x => new ComboMaterialPrimarioDTO
                {
                    Id = x.MaterialPrimarioId,
                    Nombre = x.Nombre
                }).ToList();
                data = list;

                return data;
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
            }
            }
    }
}

