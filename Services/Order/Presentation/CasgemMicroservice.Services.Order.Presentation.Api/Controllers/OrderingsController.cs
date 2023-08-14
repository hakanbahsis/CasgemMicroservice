using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Commands;
using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Order.Presentation.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderingsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public OrderingsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("getOrderList")]
		public async Task<IActionResult> GetOrderList()
		{
			var values=await _mediator.Send(new GetAllOrderingQueryRequest());
			return Ok(values);
		}

		[HttpGet("getById/{id}")]
		public async Task<IActionResult> GetOrderById(int id)
		{
			var values =await _mediator.Send(new GetByIdOrderingQueryRequest(id));
			return Ok(values);
		}

		[HttpPost("addOrder")]
		public async Task<IActionResult> AddOrder(CreateOrderCommandRequest request)
		{
			await _mediator.Send(request);
			return Ok("Sipariş Eklendi");
		}

		[HttpPut("updateOrder")]
		public async Task<IActionResult> UpdateOrder(UpdateOrderingCommandRequest request)
		{
			await _mediator.Send(request);
			return Ok("Sipariş Güncellendi");
		}

		[HttpDelete("deleteOrder/{id}")]
		public async Task<IActionResult> DeleteOrder(int id)
		{
			await _mediator.Send(new RemoveOrderingCommandRequest(id));
			return Ok("Sipariş Silindi");
		}
	}
}
