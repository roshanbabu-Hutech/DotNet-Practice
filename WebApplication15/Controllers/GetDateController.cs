using Microsoft.AspNetCore.Mvc;

namespace WebApplication15.Controllers
{
	public class GetDateController : Controller
	{
		public IActionResult DateNow()
		{
			//string date = DateTime.Now.ToString();
			//return Ok(date);
			return View();
		}
	}
}
