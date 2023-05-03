using CCI.Model;

namespace CCI.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();

        Task CreateStudent(Student student);
    }
}
