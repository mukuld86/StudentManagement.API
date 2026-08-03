//using StudentManagement.API.Data;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;
using StudentManagementSystem.Data;

namespace StudentManagement.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }
    }
}