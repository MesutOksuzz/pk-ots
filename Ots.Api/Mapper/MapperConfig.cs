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

        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>();
        
        CreateMap<CountryRequest, Country>();
        CreateMap<Country, CountryResponse>();

        
        
        CreateMap<CustomerPhoneRequest, CustomerPhone>();
        CreateMap<CustomerPhone, CustomerPhoneResponse>()
            .ForMember(dest => dest.CustomerName,
                opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
            .ForMember(dest => dest.CustomerNumber, 
                opt => opt.MapFrom(src => src.Customer.CustomerNumber));
        
        
        CreateMap<CustomerAddressRequest, CustomerAddress>();
        CreateMap<CustomerAddress, CustomerAddressResponse>()
            .ForMember(dest => dest.CustomerName,
                opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
            .ForMember(dest => dest.CustomerNumber, 
                opt => opt.MapFrom(src => src.Customer.CustomerNumber));
        
        
        CreateMap<AccountRequest, Account>();
        CreateMap<Account, AccountResponse>()
            .ForMember(dest => dest.CustomerName,
                opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
            .ForMember(dest => dest.CustomerNumber,
                opt => opt.MapFrom(src => src.Customer.CustomerNumber));
        
        CreateMap<AccountTransaction, AccountTransactionResponse>()
            .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.Name))
            .ForMember(dest => dest.AccountIban, opt => opt.MapFrom(src => src.Account.IBAN))
            .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.Account.AccountNumber))
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Account.CustomerId))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Account.Customer.FirstName + " " + src.Account.Customer.LastName))
            .ForMember(dest => dest.CustomerNumber, opt => opt.MapFrom(src => src.Account.Customer.CustomerNumber));
        
        CreateMap<EftTransaction, EftTransactionResponse>()
            .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.Name))
            .ForMember(dest => dest.AccountIban, opt => opt.MapFrom(src => src.Account.IBAN))
            .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.Account.AccountNumber))
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Account.CustomerId))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Account.Customer.FirstName + " " + src.Account.Customer.LastName))
            .ForMember(dest => dest.CustomerNumber, opt => opt.MapFrom(src => src.Account.Customer.CustomerNumber));

        CreateMap<MoneyTransfer, MoneyTransferResponse>();
    }
}