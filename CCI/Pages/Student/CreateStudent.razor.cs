using Microsoft.AspNetCore.Components;

namespace CCI.Pages.Student
{
    public partial class CreateStudent
    {
        public Model.Student Student = new();

        async Task HandleSubmit()
        {
            await StudentService.CreateStudent(Student);
        }

        void GoBack()
        {
            NavigationManager.NavigateTo("notes/list");
        }
    }
}
