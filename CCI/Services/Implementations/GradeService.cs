using CCI.Data;
using CCI.Model;
using CCI.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace CCI.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private readonly ApplicationDbContext _context;
        private readonly NavigationManager _navigationManager;

        public GradeService(ApplicationDbContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
        }

        public async Task<List<Grade>> GetGradesByDisciplineId(Guid id)
        {
            return await _context.Grades.Where(g => g.DisciplineId == id).ToListAsync();
        }

        public async Task<List<Grade>> GetGradesByStudentIdandDisciplineId(Guid studentId, Guid disciplineId)
        {
            return await _context.Grades
                                 .Where(g => g.DisciplineId == disciplineId)
                                 .Where(g => g.StudentId == studentId)
                                 .ToListAsync();
        }

        public async Task CreateGrade(Grade grade)
        {
            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGrade(Grade grade)
        {
            _context.Remove(grade);
            await _context.SaveChangesAsync();
        }
    }
}
