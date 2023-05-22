using System.ComponentModel.DataAnnotations;

namespace BackendProject.Dtos
{
	public class UserDto
	{
		[Required]
		public string? UserEmail { get; set; }
		[Required]
		public string? Profession { get; set; }
		[Required]
		public string? Salary { get; set; }
	}
}
