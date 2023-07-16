using Microsoft.AspNetCore.Components;

namespace CCI.Pages.Discipline
{
    public partial class UpdateDiscipline
    {
        [Parameter]
        public Guid Id { get; set; }

        public Model.Discipline? Discipline { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Discipline = await DisciplineService.GetDisciplineById(Id);
            }
            catch
            {

            }
        }

        async Task HandleSubmit()
        {
            if (Discipline != null)
            {
                await DisciplineService.UpdateDiscipline(Discipline);
            }
        }
    }
}
