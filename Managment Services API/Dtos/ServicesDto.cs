using Managment_Services_API.Models;

namespace Managment_Services_API.Dtos
{
    public class ServicesDto
    {
        public TypeOfServices type { get; set; }
        public DateTime StartServices { get; set; }
        public DateTime EndServices { get; set; }
        public ServicesDto(TypeOfServices type,DateTime start, DateTime end)
        {
            this.type = type;
            StartServices = start;
            EndServices = end;
        }
    }
}
