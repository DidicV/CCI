namespace CCI.Pages.Student
{
    public partial class StudentList
    {
        List<Model.Student> Students = new();

        protected override async Task OnInitializedAsync()
        {
            Students = await StudentService.GetStudents();
        }
    }
}
