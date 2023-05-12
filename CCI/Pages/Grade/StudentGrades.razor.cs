using Microsoft.AspNetCore.Components;


namespace CCI.Pages.Grade
{
    public partial class StudentGrades
    {
        [Parameter]
        public Guid DisciplineId { get; set; }

        [Parameter]
        public Guid StudentId { get; set; }

        public Model.Student? Student { get; set; }

        public Model.Discipline? Discipline { get; set; }

        public List<Model.Grade> Grades = new();

        public Model.Grade Grade = new();

        protected override async Task OnParametersSetAsync()
        {
            Student = await StudentService.GetStudentById(StudentId);
            Discipline = await DisciplineService.GetDisciplineById(DisciplineId);
            Grades = await GradeService.GetGradesByStudentIdandDisciplineId(StudentId, DisciplineId);
        }

        async Task HandleSubmit()
        {
            Grade.Id = Guid.NewGuid();
            Grade.DisciplineId = DisciplineId;
            Grade.StudentId = StudentId;

            await GradeService.CreateGrade(Grade);
            Grades = await GradeService.GetGradesByStudentIdandDisciplineId(StudentId, DisciplineId);

            Grade = new();
        }

        async Task DeleteGrade(Model.Grade grade)
        {
            await GradeService.DeleteGrade(grade);
            Grades = await GradeService.GetGradesByStudentIdandDisciplineId(StudentId, DisciplineId);
        }
    }
}
