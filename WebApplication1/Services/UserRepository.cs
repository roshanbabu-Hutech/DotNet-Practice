using AutoMapper;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Services
{
	public class UserRepository : IUserRepository
	{
		public readonly ApplicationDbContext _db;
		public readonly IConfiguration _config;
		public readonly IMapper _mapper;
		public UserRepository(IConfiguration config, IMapper mapper)
		{
			_db = new ApplicationDbContext(config);
			_config = config;
			_mapper = mapper;
		}
		public int Save()
		{
			return _db.SaveChanges();
		}
		public void AddRecord<T>(T data)
		{
			if(data != null) 
			{
				User? user = data as User;
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Password);
				user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(_config.GetSection("Secret").Value);
				_db.Add(user);
			}
			else
			{
				throw new Exception("Pls.Enter some data");
			}
		}
		public void DeleteRecord(int userId) 
		{
				User? user = _db.Users.Where(t=>t.UserId == userId).FirstOrDefault();
				if(user != null)
				{
					_db.Remove(user);
				}else
			    {
				throw new Exception("There's no User record with the given id,Pls enter the valid id");
			}
		}
		public IEnumerable<User> GetUsers() 
		{
			IEnumerable<User> users = _db.Users.ToList<User>();
			return users;
		}
		public void UpdateRecord(User User)
		{
			User? user = _db.Users.Where(t=>t.UserId==User.UserId).FirstOrDefault();
			if(user != null)
			{
				Console.WriteLine(user);
				user.FirstName = User.FirstName;
				user.LastName = User.LastName;
				user.Email = User.Email;
				user.PhoneNumber = User.PhoneNumber;
				user.Password = User.Password;
				_db.Update(user);
			}
			else
			{
				throw new Exception("There's no User Record with the Id you've Provided");
			}
        }
		public UserRegistrationDto GetSingleUser(int UserId)
		{
			User? user = _db.Users.Where(t=> t.UserId == UserId).FirstOrDefault();	
			if(user != null)
			{
				UserRegistrationDto userDto = _mapper.Map<UserRegistrationDto>(user);
				return userDto;
			}
			else
			{
				throw new Exception("There's no user record with the id you've provided");
			}

		}
	}
}
