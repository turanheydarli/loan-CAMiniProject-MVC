using AutoMapper;
using Loan.Application.Features.BranchServices.DTOs;
using Loan.Application.Features.MerchantServices.DTOs;
using Loan.DataAccess.Models;

namespace Loan.Application.MappingProfiles;

public class CustomProfile : Profile
{
    public CustomProfile()
    {
        CreateMap<Merchant, MerchantDto>().ReverseMap();
        CreateMap<Merchant, MerchantCreateDto>().ReverseMap();
        CreateMap<Merchant, MerchantUpdateDto>().ReverseMap();

        CreateMap<Branch, BranchDto>().ReverseMap();
        CreateMap<Branch, BranchCreateDto>().ReverseMap();
    }
}