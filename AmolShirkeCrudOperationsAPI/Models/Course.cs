using System.ComponentModel.DataAnnotations;

namespace AmolShirkeCrudOperationsAPI.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }
    }
}
