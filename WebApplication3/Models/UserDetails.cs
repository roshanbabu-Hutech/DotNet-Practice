using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
	public class UserDetails
	{
		[Key]
        public int UserID { get; set; }
		[Required]
		public string? UserName { get; set; }
		[Required]
		public string? Password { get; set; }
		[Required]
		public string? Email { get; set; }
		[Required]
		public long PhoneNumber { get; set; }

    }
}
