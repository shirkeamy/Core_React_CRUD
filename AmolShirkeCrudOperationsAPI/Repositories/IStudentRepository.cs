using AmolShirkeCrudOperationsAPI.Models;

namespace AmolShirkeCrudOperationsAPI.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentAsync();

        Task<Student> GetStudentByIdAsync(int studentId);

        Task AddStudentAsync(Student student);

        Task DeleteStudentAsync(int StudentId);

        Task UpdateStudentAsync(Student student);
    }
}
