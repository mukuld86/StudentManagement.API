using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;

namespace StudentManagement.API.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Student?> GetStudentByRegistrationNumberAsync(int registrationNumber)
        {
            return await _repository.GetByRegistrationNumberAsync(registrationNumber);
        }
        public async Task AddStudentAsync(Student student)
        {
            await _repository.AddAsync(student);
        }
        public async Task<bool> UpdateStudentAsync(Student student)
        {
            return await _repository.UpdateAsync(student);
        }
    }
}