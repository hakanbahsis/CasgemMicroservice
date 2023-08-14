using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Commands;
using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Queries;
using CasgemMicroservice.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Order.Presentation.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ISharedIdentityService _sharedIdentityService;
		public OrderDetailsController(IMediator mediator,  ISharedIdentityService sharedIdentityService)
		{
			_mediator = mediator;
			_sharedIdentityService = sharedIdentityService;
		}


		[HttpGet("getOrderDetailsList")]
		public async Task<IActionResult> GetOrderDetailList()
		{
			var values = await _mediator.Send(new GetAllOrderDetailQueryRequest());
			return Ok(values);
		}

		[HttpGet("getByIdOrderDetails/{id}")]
		public async Task<IActionResult> GetByIdOrderDetails(int id)
		{
			var values = await _mediator.Send(new GetByIdOrderDetailQueryRequest(id));
			return Ok(values);
		}

		[HttpPost("addOrderDetails")]
		public async Task<IActionResult> AddOrderDetail(CreateOrderDetailCommandRequest request)
		{
			await _mediator.Send(request);
			return Ok("Order Detail Oluşturuldu.");
		}

		[HttpPut("updateOrderDetails")]
		public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommandRequest request)
		{
			await _mediator.Send(request);
			return Ok("Order Detail Güncellendi");
		}

		[HttpDelete("deleteOrderDetails/{id}")]
		public async Task<IActionResult> DeleteOrdeDetail(int id)
		{
			await _mediator.Send(new RemoveOrderDetailCommandRequest(id));
			return Ok("Order Details Silindi");
		}
	}
}
