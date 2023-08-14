using CasgemMicroservice.Services.Cargo.BusinessLayer.Abstract;
using CasgemMicroservice.Services.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Cargo.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CargoDetailsController : ControllerBase
	{
		private readonly ICargoDetailService _cargoDetailService;

		public CargoDetailsController(ICargoDetailService cargoDetailService)
		{
			_cargoDetailService = cargoDetailService;
		}

		[HttpGet("getList")]
		public IActionResult GetList()
		{
			var values=_cargoDetailService.TGetList();
			return Ok(values);
		}

		[HttpGet("getById/{id}")]
		public IActionResult GetById(int id)
		{
			var value=_cargoDetailService.TGetById(id);
			return Ok(value);
		}

		[HttpPost("addCargoDetail")]
		public IActionResult AddCargoDetail(CargoDetail cargoDetail)
		{
			_cargoDetailService.TInsert(cargoDetail);
			return Ok("Kargo detayları eklendi");
		}

		[HttpPut("updateCargoDetail")]
		public IActionResult UpdateCargoDetail(CargoDetail cargoDetail)
		{
			_cargoDetailService.TUpdate(cargoDetail);
			return Ok("Kargo Detayı Güncellendi");
		}

		[HttpDelete("deleteCargoDetail")]
		public IActionResult DeleteCargoDetail(CargoDetail cargoDetail)
		{
			_cargoDetailService.TDelete(cargoDetail);
			return Ok("Kargo detayı silindi");
		}
	}
}
