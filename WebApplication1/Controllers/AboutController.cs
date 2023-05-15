using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Profile()
		{
			return View();
		}
	}
}
