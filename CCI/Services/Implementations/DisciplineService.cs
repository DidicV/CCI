using CCI.Data;
using CCI.Model;
using CCI.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace CCI.Services.Implementations
{
    public class DisciplineService : IDisciplineService
    {
        private readonly ApplicationDbContext _context;
        private readonly NavigationManager _navigationManager;

        public DisciplineService(ApplicationDbContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
        }

        public async Task<List<Discipline>> GetDisciplines()
        {
            return await _context.Disciplines.ToListAsync();
        }

        public async Task CreateDiscipline(Discipline discipline)
        {
            discipline.Id = Guid.NewGuid();

            await _context.Disciplines.AddAsync(discipline);
            await _context.SaveChangesAsync();

            _navigationManager.NavigateTo("disciplinelist");
        }

        public async Task<Discipline?> GetDisciplineById(Guid id)
        {
            return await _context.Disciplines.FindAsync(id);
        }

        public async Task UpdateDiscipline(Discipline discipline)
        {
            _context.Update(discipline);
            await _context.SaveChangesAsync();

            _navigationManager.NavigateTo("disciplinelist");
        }

        public async Task DeleteDiscipline(Discipline discipline)
        {
            _context.Remove(discipline);
            await _context.SaveChangesAsync();
        }
    }
}
