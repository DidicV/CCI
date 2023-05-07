using CCI.Model;

namespace CCI.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();

        Task CreateStudent(Student student);

        Task<Student?> GetStudentById(Guid id);

        Task UpdateStudent(Student student);

        Task DeleteStudent(Student student);
    }
}
