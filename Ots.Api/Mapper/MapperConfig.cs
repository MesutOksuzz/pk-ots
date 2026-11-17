using AutoMapper;
using Ots.Api.Domain;
using Ots.Schema;

namespace Ots.Api.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<CustomerRequest, Customer>();
        CreateMap<Customer, CustomerResponse>();

        CreateMap<CustomerPhoneRequest, CustomerPhone>();
        CreateMap<CustomerPhone, CustomerPhoneResponse>()
            .ForMember(dest => dest.CustomerName,
                opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
            .ForMember(dest => dest.CustomerName, 
                opt => opt.MapFrom(src => src.Customer.CustomerNumber));

    }
}