using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CasgemMicroservice.Services.Discount.Models
{
    public class Context:DbContext
    {
        //private readonly IConfiguration _configuration;
        //private readonly string _connectionString;

        //public Context(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    _connectionString = _configuration.GetConnectionString("DefaultConnection");
        //}

      //public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=DiscountDb;User=sa;Password=123456Aa*;");
        }


        public DbSet<DiscountCoupons> DiscountCoupons { get; set; }


    }
}
