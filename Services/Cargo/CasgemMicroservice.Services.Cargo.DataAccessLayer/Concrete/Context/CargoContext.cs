using CasgemMicroservice.Services.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Cargo.DataAccessLayer.Concrete.Context
{
	public class CargoContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost,1433;Database=CargoDb;User=sa;Password=123456Aa*;");
		}

        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoState> CargoStates { get; set; }
    }
}
