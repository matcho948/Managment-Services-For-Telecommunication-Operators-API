using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managment_Services_API.Models
{
    public class Bills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public Services Service { get; set; }
    }
}
