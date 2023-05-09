using System.ComponentModel.DataAnnotations;

namespace CCI.Model
{
    public class Discipline
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
