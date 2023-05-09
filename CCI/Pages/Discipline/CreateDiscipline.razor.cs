namespace CCI.Pages.Discipline
{
    public partial class CreateDiscipline
    {
        public Model.Discipline Discipline = new();

        async Task HandleSubmit()
        {
            await DisciplineService.CreateDiscipline(Discipline);
        }
    }
}
