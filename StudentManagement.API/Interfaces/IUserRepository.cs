using StudentManagement.API.Models;

namespace StudentManagement.API.Interfaces
{
    public interface IUserRepository
    {

        Task<User?> SignInAsync(string userName, string password);
    }
}
