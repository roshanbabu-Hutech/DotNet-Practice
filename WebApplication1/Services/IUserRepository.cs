using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Services
{
	public interface IUserRepository
	{
		public int Save();
		public void AddRecord<T>(T data);
		public void DeleteRecord(int userId);
		public IEnumerable<User> GetUsers();
		public void UpdateRecord(User UserId);
		public UserRegistrationDto GetSingleUser(int UserId);

	}
}
