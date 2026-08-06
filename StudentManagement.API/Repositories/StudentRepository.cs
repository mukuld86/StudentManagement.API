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
        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
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
        public async Task<bool> DeleteAsync(int registrationNumber)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.RegistrationNumber == registrationNumber);
            if (student == null)
            {
                return false;
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}