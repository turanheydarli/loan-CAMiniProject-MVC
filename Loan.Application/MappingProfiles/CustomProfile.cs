using AutoMapper;
using Loan.Application.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.MappingProfiles;

public class CustomProfile : Profile
{
    public CustomProfile()
    {
        CreateMap<Merchant, MerchantDto>().ReverseMap();
        CreateMap<Branch, BranchDto>().ReverseMap();
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<CarouselItem, CarouselItemDto>().ReverseMap();
        CreateMap<AppUser, UserDto>().ReverseMap();
    }
}