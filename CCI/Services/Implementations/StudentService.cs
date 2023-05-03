using CCI.Data;
using CCI.Model;
using CCI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CCI.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context= context;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task CreateStudent(Student student)
        {
            student.Id = Guid.NewGuid();

            await _context.Students.AddAsync(student);

            await _context.SaveChangesAsync();
        }
    }
}
