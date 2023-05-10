using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Collections;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GetExternalPostsController : ControllerBase
	{
		[HttpGet("getPosts")]
		public async Task<string> GetExternalPosts() 
		{
			var client = new HttpClient();

			// set the base address of the API endpoint
			client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts");

			// make a GET request to the API endpoint
			HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

			// read the response content as a string
			string responseContent = await response.Content.ReadAsStringAsync();

			// print the response content to the console
			Console.WriteLine(responseContent);
			Console.WriteLine(typeof(StaticFileResponseContext));
			return responseContent;
		}
	}
}
