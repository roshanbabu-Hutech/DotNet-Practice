using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
	[ApiController]
	[Route("controller")]
	public class AddUserController : ControllerBase
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
