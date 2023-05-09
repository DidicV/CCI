using CCI.Model;

namespace CCI.Services.Interfaces
{
    public interface IDisciplineService
    {
        Task<List<Discipline>> GetDisciplines();

        Task CreateDiscipline(Discipline discipline);

        Task<Discipline?> GetDisciplineById(Guid id);

        Task UpdateDiscipline(Discipline discipline);

        Task DeleteDiscipline(Discipline discipline);
    }
}
