using System.ComponentModel.DataAnnotations;
namespace Managment_Services_API.Dtos
{
    public class AddServiceDto
    {
        [Required]
        public TypeOfServiceDto Type { get; set; }
        [Required]
        public DateTime StartServices { get; set; }
        [Required]
        public DateTime EndServices { get; set; }
    }
}
