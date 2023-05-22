using System.ComponentModel.DataAnnotations;

namespace BackendProject.Models
{
	public class UserDetails
	{
		public int UserId { get; set; }
		[Required]
		public string? UserName { get; set; }
		[Required]
		public string? UserEmail { get; set; }
		[Required]
		public string? CompanyName { get; set; }
		[Required]
		public string? Profession { get; set; }
		[Required]
		public int Salary { get; set; }
	}
}
