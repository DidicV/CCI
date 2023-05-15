namespace CCI.Pages.Discipline
{
    public partial class DisciplineList
    {
        List<Model.Discipline> Disciplines = new();

        protected override async Task OnInitializedAsync()
        {
            Disciplines = await DisciplineService.GetDisciplines();
        }

        void CreateDiscipline()
        {
            NavigationManager.NavigateTo("creatediscipline");
        }

        public void UpdateDiscipline(Guid id)
        {
            NavigationManager.NavigateTo($"updatediscipline/{id}");
        }

        public void GradeDisciplineFrequency(Guid id)
        {
            NavigationManager.NavigateTo($"frequency/{id}");
        }

        public async void DeleteDiscipline(Model.Discipline discipline)
        {
            await DisciplineService.DeleteDiscipline(discipline);
            Disciplines = await DisciplineService.GetDisciplines();
            Disciplines = Disciplines.Where(x => x.Id != discipline.Id).ToList();
            StateHasChanged();
        }
    }
}
