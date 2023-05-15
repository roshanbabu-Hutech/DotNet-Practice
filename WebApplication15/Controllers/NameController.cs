using Microsoft.AspNetCore.Mvc;

namespace WebApplication15.Controllers
{
	public class NameController : ControllerBase
	{
		public IActionResult GetName()
		{
			string name = "hello from apple";
			return Ok(name);
		}
	}
}
