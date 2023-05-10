using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UpdateUserDataController : ControllerBase
	{
		public readonly IUserRepository _userRepository;
		public UpdateUserDataController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		[HttpPut("updateUser")]
		public IActionResult UpdateUser(User user)
		{
			_userRepository.UpdateRecord(user);
			if(_userRepository.Save() > 0)
			{
				return Ok("User Record Succussfully Updated");
			}
			else
			{
				throw new Exception("There's an error while Updating the User Record");
			}
		}
	}
}
