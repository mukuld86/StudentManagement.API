using StudentManagement.API.Models;

namespace StudentManagement.API.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByRegistrationNumberAsync(int registrationNumber);
        void Add(Student student);
        Task<bool> UpdateAsync(Student student);
    }
}