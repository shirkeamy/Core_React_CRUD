using AmolShirkeCrudOperationsAPI.Models;

namespace AmolShirkeCrudOperationsAPI.Repositories.StudentRepository
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
