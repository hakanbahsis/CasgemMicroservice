using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Commands;
using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Order.Presentation.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AddressController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("getAddressList")]
		public async Task<IActionResult> AddressList()
		{
			var values = await _mediator.Send(new GetAllAddressQueryRequest());
			return Ok(values);
		}

		[HttpGet("getById/{id}")]
		public async Task<IActionResult> GetAddressById(int id)
		{
			var values = await _mediator.Send(new GetByIdAddressQueryRequest(id));
			return Ok(values);
		}

		[HttpPost("addAddress")]
		public async Task<IActionResult> CreateAddress(CreateAddressCommandRequest request)
		{
			await _mediator.Send(request);
			return Ok("Address Eklendi.");
		}

		[HttpPut("updateAddress")]
		public async Task<IActionResult> UpdateAddress(UpdateAddressCommandRequest request)
		{
			await _mediator.Send(request);
			return Ok();
		}

		[HttpDelete("deleteAddress")]
		public async Task<IActionResult> DeleteAddress(int id)
		{
			await _mediator.Send(new RemoveAddressCommandRequest(id));
			return Ok("Address Silindi");
		}
	}
}
