using Microsoft.AspNetCore.Identity.Data;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;

namespace StudentManagement.API.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User?> LoginAsync(SignInRequest request)
        {
            return await _repository.LoginAsync(
                request.UserName,
                request.Password);
        }
    }
}
