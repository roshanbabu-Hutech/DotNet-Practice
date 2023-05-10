using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GetUserDataController : ControllerBase
	{
		public readonly IUserRepository _userRepository;
		public GetUserDataController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		[HttpGet("getUsers")]
		public IEnumerable<User> GetUserData()
		{
			IEnumerable<User> users = _userRepository.GetUsers();
			return users;
		}
	}
}
