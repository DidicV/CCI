using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CCI.Pages.Charts
{
    public partial class LinesChart
    {
        public List<Model.Discipline> Disciplines = new();

        public Guid DisciplineId;

        public List<Model.Student> Students { get; set; } = new();

        private List<Guid> selectedIds = new List<Guid>();


        class ScatterData
        {
            public List<int> x { get; set; } = new();

            public List<int> y { get; set; } = new();

            public string mode { get; set; } = string.Empty;

            public string name { get; set; } = string.Empty;
        }

        protected override async Task OnInitializedAsync()
        {
            Students = await StudentService.GetStudents();
            Disciplines = await DisciplineService.GetDisciplines();
        }

        private void OnSelectionChanged(ChangeEventArgs e)
        {
            selectedIds = ((string[])e.Value).Select(Guid.Parse).ToList();
        }

        private void FirstDiscipline(object id)
        {
            DisciplineId = (Guid)id;
        }

        private async void ButtonClick(MouseEventArgs args)
        {
            var data = new List<ScatterData>();

            if (selectedIds.Any() && DisciplineId != Guid.Empty)
            {
                foreach (var studentId in selectedIds)
                {
                    var grades = await GradeService.GetGradesByStudentIdandDisciplineId(studentId, DisciplineId);

                    var scatterData = new ScatterData();

                    scatterData.y = grades.Select(g => g.Mark).ToList();

                    for (int i = 0; i < grades.Count; i++)
                    {
                        scatterData.x.Add(i + 1);
                    }

                    scatterData.name = Students.FirstOrDefault(s => s.Id == studentId).Name ?? "";

                    scatterData.mode = "lines+markers";

                    data.Add(scatterData);
                }

                await JsRunTime.InvokeVoidAsync("GenerateScatterChart", data);
            }
        }
    }
}
