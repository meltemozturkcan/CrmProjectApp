using AutoMapper;
using CrmProject.Application.Features.Customers.Commands;
using CrmProject.Application.ViewModels;
using CrmProject.Domain.Entities;
using AutoMapper.Configuration;

namespace CrmProject.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to ViewModel
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // ViewModel to Domain
            CreateMap<CreateCustomerViewModel, Customer>()
                .ForMember(dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.RegistrationDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateCustomerViewModel, Customer>()
                .ForMember(dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.UtcNow));

            // Command to Domain
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();

            // Domain to Command
            CreateMap<Customer, UpdateCustomerCommand>();
        }
    }
}