using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
	public class UserRegistrationDto
	{
		public string? Email { get; set; }
		public string? Password { get; set; }
		public long PhoneNumber { get; set; }
	}
}
