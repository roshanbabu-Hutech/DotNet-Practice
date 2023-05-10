using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AddUserDataController : ControllerBase
	{
		public readonly IUserRepository _userRepository;
		public AddUserDataController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		[HttpPost("addUser")]
		public IActionResult addUser(User user)
		{
			_userRepository.AddRecord(user);
			if (_userRepository.Save() > 0)
			{
				return Ok($"User Succussfully added to the database");
			}
			else
			{
				throw new Exception("There's an error while adding the user to the database");
			}
		}
	}
}
