//using StudentManagement.API.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student?> GetByRegistrationNumberAsync(int registrationNumber)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.RegistrationNumber == registrationNumber);
        }
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public async Task<bool> UpdateAsync(Student student)
        {
            var existingStudent = await _context.Students
                .FirstOrDefaultAsync(s =>
            s.RegistrationNumber == student.RegistrationNumber);
            if (existingStudent == null)
            {
                return false;
            }
            existingStudent.Name = student.Name;
            existingStudent.Course = student.Course;
            existingStudent.Age = student.Age;
            existingStudent.Email = student.Email;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}