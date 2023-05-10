using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DeleteUserDataController : ControllerBase
	{
		public readonly IUserRepository _userRepository;
		public readonly IMapper _mapper;
		public DeleteUserDataController(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}
		[HttpDelete("deleteUser")]
		public IActionResult DeleteUser(int id)
		{
			_userRepository.DeleteRecord(id);
			if(_userRepository.Save() > 0)
			{
				return Ok("User Succussfully deleted");
			}
			else
			{
				throw new Exception("There's no User with the id you Provided");
			}
		}
	}
}
