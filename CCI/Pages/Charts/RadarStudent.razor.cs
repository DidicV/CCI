﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CCI.Pages.Charts
{
    public partial class RadarStudent
    {
        [Parameter]
        public Guid StudentId { get; set; }

        public Model.Student? Student { get; set; }

        public List<Model.Discipline> Disciplines { get; set; } = new();

        public List<Model.Grade> Grades { get; set; } = new();

        public List<string> disciplineName { get; set; } = new();

        public List<double> gradesavarage { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Student = await StudentService.GetStudentById(StudentId);

            Disciplines = await DisciplineService.GetDisciplines();

            foreach (var discipline in Disciplines)
            {
                Grades = await GradeService.GetGradesByStudentIdandDisciplineId(StudentId, discipline.Id);

                var sum = Grades.Sum(g => g.Mark);

                if (Grades.Any())
                {
                    var mean = (double)sum / Grades.Count;
                    gradesavarage.Add(mean);
                }
                else
                {
                    gradesavarage.Add(0);
                }

                disciplineName.Add(discipline.Name);
            }

            if (gradesavarage.Any() && disciplineName.Any())
            {
                gradesavarage.Add(gradesavarage.First());
                disciplineName.Add(disciplineName.First());
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            JsRunTime.InvokeVoidAsync("GenerateRadarChart", gradesavarage, disciplineName);
        }
    }
}
