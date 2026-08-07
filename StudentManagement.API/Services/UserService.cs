using Microsoft.AspNetCore.Identity.Data;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;

namespace StudentManagement.API.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;
        public UserService(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }
        public async Task<string?> SignInAsync(SignInRequest request)
        {
            var user = await _repository.SignInAsync(
                request.UserName,
                request.Password);
            if (user == null)
            {
                return null;
            }
            return _jwtService.GenerateToken(user);
        }
    }
}
