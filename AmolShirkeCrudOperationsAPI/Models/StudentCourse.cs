namespace AmolShirkeCrudOperationsAPI.Models
{
    public class StudentCourse
    {
        public int StudentCourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
