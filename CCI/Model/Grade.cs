namespace CCI.Model
{
    public class Grade
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public Student? Student { get; set; }

        public Guid DisciplineId { get; set; }

        public Discipline? Discipline { get; set; }

        public int Mark { get; set; }
    }
}