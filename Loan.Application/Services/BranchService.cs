using AutoMapper;
using Loan.Application.DTOs;
using Loan.Application.MimeServer;
using Loan.Application.Services.Abstraction;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Loan.Application.Services;

public class BranchService : GenericService<Branch, BranchDto>, IBranchService
{
    private readonly IUserService _userService;
    private readonly IMediaService _mediaService;
    private readonly IMerchantService _merchantService;

    public BranchService(IAsyncRepository<Branch, AppDbContext> repository, IMapper mapper, IUserService userService,
        IMediaService mediaService, IMerchantService merchantService) : base(repository, mapper)
    {
        _userService = userService;
        _mediaService = mediaService;
        _merchantService = merchantService;
    }

    public async Task<BranchDto> CreateAsync(BranchDto branch, Guid merchantId)
    {
        var merchant = await _merchantService.GetByIdAsync(merchantId);

        if (merchant == null)
        {
            throw new ApplicationException($"Merchant with id {branch.MerchantId} not found");
        }

        var address = _mapper.Map<Address>(branch.Address);

        var branchEntity = new Branch()
        {
            Name = branch.Name,
            Address = address,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow,
            MerchantId = merchant.Id,
        };

        var createdBranch = await _repository.AddAsync(branchEntity);

        return _mapper.Map<BranchDto>(createdBranch);
    }

    public async Task<List<BranchDto>> GetAllByMerchantId(Guid merchantId)
    {
        var branches = await _repository.GetListAsync(b => b.MerchantId == merchantId);

        return _mapper.Map<List<BranchDto>>(branches);
    }
}