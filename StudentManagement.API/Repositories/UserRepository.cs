using Microsoft.EntityFrameworkCore;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;
using StudentManagement.API.Data;

namespace StudentManagement.API.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User?> LoginAsync(string username, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.UserName == username &&
                    u.Password == password);
            //return await _context.Users.FirstOrDefaultAsync();
        }

    }
}
