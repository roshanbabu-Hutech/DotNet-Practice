using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class DataController : Controller
	{
		public async Task<IActionResult> GetData()
		{
			var client = new HttpClient();

			// set the base address of the API endpoint
			client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");

			// make a GET request to the API endpoint
			HttpResponseMessage response = await client.GetAsync("posts");

			// read the response content as a string
			string responseContent = await response.Content.ReadAsStringAsync();

			// deserialize the JSON string into a list of User objects
			List<User>? users = JsonConvert.DeserializeObject<List<User>>(responseContent);

			// pass the list of User objects to the view
			return View(users);
		}
	}
}
