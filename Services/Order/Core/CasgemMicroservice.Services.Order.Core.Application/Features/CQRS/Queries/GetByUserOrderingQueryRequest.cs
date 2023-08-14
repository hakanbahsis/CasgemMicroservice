using CasgemMicroservice.Services.Order.Core.Application.Dtos.OrderDetailDtos;
using CasgemMicroservice.Services.Order.Core.Application.Dtos.OrderDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Queries
{
	public class GetByUserOrderingQueryRequest:IRequest<List<ResultOrderDto>>
	{
        public string Id { get; set; }

		
	}
}
