using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Models;
using WebApplication1.Dtos;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GetSingleUserDataController : ControllerBase
	{
		public readonly IUserRepository _userRepository;
		public GetSingleUserDataController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		[HttpGet("getSingleUser")]
		public UserRegistrationDto GetSingleUserData(int id)
		{
			return _userRepository.GetSingleUser(id);
		}
	}
}
