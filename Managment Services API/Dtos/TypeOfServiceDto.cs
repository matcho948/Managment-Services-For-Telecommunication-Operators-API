using System.ComponentModel.DataAnnotations;

namespace Managment_Services_API.Dtos
{
    public class TypeOfServiceDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public float Cost { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
    }
}
