using CCI.Model;

namespace CCI.Services.Interfaces
{
    public interface IGradeService
    {
        Task<List<Grade>> GetGradesByDisciplineId(Guid id);

        Task<List<Grade>> GetGradesByStudentIdandDisciplineId(Guid studentId, Guid disciplineId);

        Task CreateGrade(Grade grade);

        Task DeleteGrade(Grade grade);

    }
}
