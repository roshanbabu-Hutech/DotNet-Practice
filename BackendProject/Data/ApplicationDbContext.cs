using BackendProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Data
{
	public class ApplicationDbContext: DbContext
	{
		private readonly IConfiguration _config;
		public ApplicationDbContext(IConfiguration config)
		{
			_config = config;
		}
		public virtual DbSet<UserDetails> UserDetails { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if(!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
				optionsBuilder => optionsBuilder.EnableRetryOnFailure());
			}
			else
			{
                Console.WriteLine("Connection to the database established succussfully");
            }
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("facebook");
			modelBuilder.Entity<UserDetails>()
			.ToTable("User Details","facebook")
			.HasKey(e => e.UserId);
            Console.WriteLine("User Details Table created Succussfully");
        }
	}
}
