namespace CCI.Pages.Student
{
    public partial class StudentList
    {
        List<Model.Student> Students = new();

        protected override async Task OnInitializedAsync()
        {
            Students = await StudentService.GetStudents();
        }
        void CreateStudent()
        {
            NavigationManager.NavigateTo("createstudent");
        }

        public void UpdateStudent(Guid id)
        {
            NavigationManager.NavigateTo($"updatestudent/{id}");
        }

        public async void DeleteStudent(Model.Student student) 
        {
            await StudentService.DeleteStudent(student);
            Students = await StudentService.GetStudents();
            Students = Students.Where(x => x.Id != student.Id).ToList();
            StateHasChanged();
        }
    }
}
