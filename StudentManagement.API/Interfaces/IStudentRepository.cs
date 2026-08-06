using StudentManagement.API.Models;

namespace StudentManagement.API.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByRegistrationNumberAsync(int registrationNumber);
        Task AddAsync(Student student);
        Task<bool> UpdateAsync(Student student);
        Task<bool> DeleteAsync(int registrationNumber);
    }
}