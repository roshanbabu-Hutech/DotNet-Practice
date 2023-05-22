using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
	public class ApplicationDbContext : DbContext
	{
		public readonly IConfiguration _config;
		public ApplicationDbContext(IConfiguration config)
		{
			_config = config;
		}
		public virtual DbSet<UserDetails> UserDetails { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
				optionsBuilder => optionsBuilder.EnableRetryOnFailure());
				Console.WriteLine("Connection to the database established successfully");
				string? token = _config.GetSection("TokenKey").Value;
				Console.WriteLine(token);
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Data");
			modelBuilder.Entity<UserDetails>()
				.ToTable("User Details", "Data")
				.HasKey(t => t.UserID);
            Console.WriteLine("User Details Table created Succussfully");
        }
	}
}
