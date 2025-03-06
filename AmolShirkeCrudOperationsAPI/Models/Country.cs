using System.ComponentModel.DataAnnotations;

namespace AmolShirkeCrudOperationsAPI.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }
    }
}
