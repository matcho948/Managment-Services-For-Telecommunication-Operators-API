using AutoMapper;
using Managment_Services_API.Dtos;
using Managment_Services_API.Models;

namespace Managment_Services_API.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddCustomerDto, Customers>();
            CreateMap<TypeOfServiceDto, TypeOfServices>();
            CreateMap<ServicesDto, Services>();
        }
    }
}
