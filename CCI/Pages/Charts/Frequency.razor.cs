using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CCI.Pages.Charts
{
    public partial class Frequency
    {
        [Parameter]
        public Guid DisciplineId { get; set; }

        public List<Model.Grade> Grades { get; set; } = new();

        protected override async Task OnParametersSetAsync()
        {
            base.OnParametersSet();

            Grades = await GradeService.GetGradesByDisciplineId(DisciplineId);

            await JsRunTime.InvokeVoidAsync("GenerateFrequencyChart", Grades.Select(g => g.Mark));
        }
    }
}
