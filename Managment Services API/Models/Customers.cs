using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managment_Services_API.Models
{
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual List<Services> Services { get; set; }
        public Customers()
        {
            Services = new List<Services>();
        }
    }
}
