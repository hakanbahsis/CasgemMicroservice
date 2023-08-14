using CasgemMicroservice.Services.Cargo.BusinessLayer.Abstract;
using CasgemMicroservice.Services.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Cargo.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CargoStateController : ControllerBase
	{
		private readonly ICargoStateService _cargoStateService;

		public CargoStateController(ICargoStateService cargoStateService)
		{
			_cargoStateService = cargoStateService;
		}

		[HttpGet("getList")]
		public IActionResult GetList()
		{
			var values=_cargoStateService.TGetList();
			return Ok(values);
		}

		[HttpGet("getById/{id}")]
		public IActionResult GetById(int id)
		{
			var value=_cargoStateService.TGetById(id);
			return Ok(value);
		}

		[HttpPost("addCargoState")]
		public IActionResult AddCargoState(CargoState cargoState)
		{
			_cargoStateService.TInsert(cargoState);
			return Ok("Kargo Durumu Eklendi");
		}

		[HttpPut("updateCargoState")]
		public IActionResult UpdateCargoState(CargoState cargoState)
		{
			_cargoStateService.TUpdate(cargoState);
			return Ok("Kargo Durumu Güncellendi");
		}

		[HttpDelete("deleteCargoState")]
		public IActionResult DeleteCargoState(CargoState cargoState)
		{
			_cargoStateService.TDelete(cargoState);
			return Ok("Kargo Durumu Silindi");
		}
	}
}
