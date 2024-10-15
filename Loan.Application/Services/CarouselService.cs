using AutoMapper;
using Loan.Application.DTOs;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;

namespace Loan.Application.Services;

public class CarouselService : GenericService<CarouselItem, CarouselItemDto>, ICarouselService
{
    public CarouselService(IAsyncRepository<CarouselItem, AppDbContext> repository, IMapper mapper) : base(repository,
        mapper)
    {
    }
}