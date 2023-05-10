using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
	public class ApplicationMapper : Profile
	{
		public ApplicationMapper()
		{
			CreateMap<User,UserRegistrationDto>();
		}
	}
}
