using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmolShirkeCrudOperationsAPI.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Required]
        [StringLength(50)]
        public string StateName { get; set; }

        [Required]
        public virtual Country Country { get; set; }
    }
}
