using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Managment_Services_API.Models
{
    public class Services
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public TypeOfServices Type { get; set; }
        [Required]
        public DateTime StartServices { get; set; }
        [Required]
        public DateTime EndServices { get; set; }

    }
}
