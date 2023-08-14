using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Cargo.EntityLayer.Concrete
{
	public class CargoDetail
	{
        public int CargoDetailId { get; set; }
        public int OrderId { get; set; }


        public int CargoStateId { get; set; }
        public virtual CargoState CargoState { get; set; }

    }
}
