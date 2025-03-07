using AmolShirkeCrudOperationsAPI.Context;
using AmolShirkeCrudOperationsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AmolShirkeCrudOperationsAPI.Repositories.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StudentRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        async Task<IEnumerable<Student>> IStudentRepository.GetAllStudentAsync()
        {
            return await _applicationDbContext.Students.ToListAsync();
        }

        async Task<Student> IStudentRepository.GetStudentByIdAsync(int studentId)
        {
            return await _applicationDbContext.Students.FindAsync(studentId);
        }

        async Task IStudentRepository.AddStudentAsync(Student student)
        {
            await _applicationDbContext.Students.AddAsync(student);
            await _applicationDbContext.SaveChangesAsync();
        }

        async Task IStudentRepository.DeleteStudentAsync(int studentId)
        {
            var student = _applicationDbContext.Students.FindAsync(studentId);
            if (student != null)
            {
                _applicationDbContext.Remove(student);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        async Task IStudentRepository.UpdateStudentAsync(Student student)
        {
            _applicationDbContext.Update(student);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
