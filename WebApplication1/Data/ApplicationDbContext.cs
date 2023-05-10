using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
	public class ApplicationDbContext : DbContext
	{
		public readonly IConfiguration _config;
		public ApplicationDbContext(IConfiguration config)
		{
			_config = config;
		}
		public virtual DbSet<User> Users { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
				opt=>opt.EnableRetryOnFailure());
				Console.WriteLine("Connection to the database established succussfully :)");
			}
			else
			{
                Console.WriteLine("Connected to database");
            }
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Products");
			modelBuilder.Entity<User>()
			.ToTable("Users", "Products")
			.HasKey(t => t.UserId);
            Console.WriteLine("Users Table Created Succussfully");
        }
	}
}
