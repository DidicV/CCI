using CCI.Model;

namespace CCI.Services.Interfaces
{
    public interface IGradeService
    {
        Task<List<Grade>> GetGradesByDisciplineId(Guid id);

        Task<List<Grade>> GetGradesByStudentIdandDisciplineId(Guid studentId, Guid disciplineId);

        Task<Grade?> GetGradeById(Guid id);

        Task CreateGrade(Grade grade);

        Task UpdateGrade(Grade grade);

        Task DeleteGrade(Grade grade);
    }
}
