using CasgemMicroservice.Services.Cargo.DataAccessLayer.Abstract;
using CasgemMicroservice.Services.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Cargo.DataAccessLayer.Concrete
{
	public class EfCargoStateDal:BaseRepository<CargoState>,ICargoStateDal
	{
	}
}
