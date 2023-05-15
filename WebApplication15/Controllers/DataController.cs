using Microsoft.AspNetCore.Mvc;

namespace WebApplication15.Controllers
{
	public class Datacontroller : Controller
	{
		public IActionResult NewData()
		{
			return View();
		}
	}
}
