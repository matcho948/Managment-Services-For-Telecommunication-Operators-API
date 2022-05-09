using System.ComponentModel.DataAnnotations;
namespace Managment_Services_API.Dtos
{
    public class AddCustomerDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
