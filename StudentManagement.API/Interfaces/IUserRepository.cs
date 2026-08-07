using StudentManagement.API.Models;

namespace StudentManagement.API.Interfaces
{
    public interface IUserRepository
    {

        Task<User?> LoginAsync(string userName, string password);
    }
}
