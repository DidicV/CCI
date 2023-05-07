using CCI.Data;
using CCI.Model;
using CCI.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace CCI.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        private readonly NavigationManager _navigationManager;

        public StudentService(ApplicationDbContext context, NavigationManager navigationManager)
        {
            _context= context;
            _navigationManager = navigationManager;
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

            _navigationManager.NavigateTo("studentlist");
        }

        public async Task<Student?> GetStudentById(Guid id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task UpdateStudent(Student student)
        {
            _context.Update(student);
            await _context.SaveChangesAsync();

            _navigationManager.NavigateTo("studentlist");
        }

        public async Task DeleteStudent(Student student)
        {
            _context.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
