using Microsoft.EntityFrameworkCore;
//using NuGet.Protocol;
using Microsoft.Data.SqlClient;

namespace WebApplication15.Data
{
	public class ApplicationDbContext : DbContext
	{
		public readonly IConfiguration _config;
		public ApplicationDbContext(IConfiguration config)
		{
			_config = config;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
				opt => opt.EnableRetryOnFailure());
				Console.WriteLine("Connection to the database established succussfully :)");
			}
			else
			{
				Console.WriteLine("Connected to database");
			}
		}
	}
}
