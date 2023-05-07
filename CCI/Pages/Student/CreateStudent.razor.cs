using Microsoft.AspNetCore.Components;

namespace CCI.Pages.Student
{
    public partial class CreateStudent
    {
        public Model.Student Student = new();

        async Task HandleSubmit()
        {
            await StudentService.CreateStudent(Student);
            GoBack();
        }

        void GoBack()
        {
            NavigationManager.NavigateTo("/studentlist");
        }
    }
}
