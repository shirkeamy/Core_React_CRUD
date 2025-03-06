using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmolShirkeCrudOperationsAPI.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [StringLength(50)]
        public string CityName { get; set; }

        [Required]
        public virtual State State { get; set; }
    }
}
