using System.ComponentModel.DataAnnotations;

namespace AmolShirkeCrudOperationsAPI.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailId { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public virtual Country Country { get; set; }

        public virtual State State { get; set; }

        public virtual City City { get; set; }

    }
}
