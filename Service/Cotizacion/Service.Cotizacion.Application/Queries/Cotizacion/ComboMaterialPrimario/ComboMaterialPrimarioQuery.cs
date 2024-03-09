using System;
using MediatR;

namespace Service.Cotizacion.Application.Queries.Cotizacion.ComboMaterialPrimario
{
	public class ComboMaterialPrimarioQuery:IRequest<List<ComboMaterialPrimarioDTO>>
	{
		public ComboMaterialPrimarioQuery()
		{
		}
	}
}

