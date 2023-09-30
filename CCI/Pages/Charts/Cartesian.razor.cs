using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace CCI.Pages.Charts
{
    public partial class Cartesian
    {
        public List<Model.Discipline> disciplines = new();
        public Guid FirstDisciplineId;
        public Guid SecondDisciplineId;

        public List<Model.Student> Students { get; set; } = new();

        public List<double> mediaX { get; set; } = new();
        public List<double> mediaY { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            disciplines = await DisciplineService.GetDisciplines();
        }

        private void FirstDiscipline(object id)
        {
            FirstDisciplineId = (Guid)id;
        }

        private void SecondDiscipline(object id)
        {
            SecondDisciplineId = (Guid)id;
        }

        private async void ButtonClick(MouseEventArgs args)
        {
            if (FirstDisciplineId != SecondDisciplineId)
            {
                if (FirstDisciplineId != Guid.Empty && SecondDisciplineId != Guid.Empty)
                {
                    Students.Clear();
                    mediaX.Clear();
                    mediaY.Clear();

                    Students = await StudentService.GetStudents();

                    foreach (var student in Students)
                    {
                        var firstGrades = await GradeService.GetGradesByStudentIdandDisciplineId(student.Id, FirstDisciplineId);
                        var secondGrades = await GradeService.GetGradesByStudentIdandDisciplineId(student.Id, SecondDisciplineId);

                        var fisrtSum = firstGrades.Sum(g => g.Mark);

                        if (firstGrades.Any())
                        {
                            var mean = (double)fisrtSum / firstGrades.Count;
                            mediaX.Add(mean);
                        }
                        else
                        {
                            mediaX.Add(0);
                        }

                        var secondSum = secondGrades.Sum(g => g.Mark);

                        if (secondGrades.Any())
                        {
                            var mean = (double)secondSum / secondGrades.Count;
                            mediaY.Add(mean);
                        }
                        else
                        {
                            mediaY.Add(0);
                        }
                    }

                    var courseX = disciplines.FirstOrDefault(d => d.Id == FirstDisciplineId);
                    var courseY = disciplines.FirstOrDefault(d => d.Id == SecondDisciplineId);

                    await JsRunTime.InvokeVoidAsync("GenerateCartesianChart", mediaX, mediaY, Students.Select(s => s.Name), courseX.Name, courseY.Name);
                }
            }
            StateHasChanged();
        }
    }
}
