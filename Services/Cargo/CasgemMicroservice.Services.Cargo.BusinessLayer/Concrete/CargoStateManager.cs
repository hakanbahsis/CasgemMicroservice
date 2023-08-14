using CasgemMicroservice.Services.Cargo.BusinessLayer.Abstract;
using CasgemMicroservice.Services.Cargo.DataAccessLayer.Abstract;
using CasgemMicroservice.Services.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Cargo.BusinessLayer.Concrete
{
	public class CargoStateManager : ICargoStateService
	{
		private readonly ICargoStateDal _cargoStateDal;

		public CargoStateManager(ICargoStateDal cargoStateDal)
		{
			_cargoStateDal = cargoStateDal;
		}

		public void TDelete(CargoState entity)
		{
			throw new NotImplementedException();
		}

		public CargoState TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<CargoState> TGetList()
		{
			throw new NotImplementedException();
		}

		public void TInsert(CargoState entity)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(CargoState entity)
		{
			throw new NotImplementedException();
		}
	}
}
