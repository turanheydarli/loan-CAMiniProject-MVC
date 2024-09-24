using AutoMapper;
using Loan.Application.Features.AuthServices.Abstraction;
using Loan.Application.Features.AuthServices.DTOs;
using Loan.Application.Features.BranchServices.Abstraction;
using Loan.Application.Features.BranchServices.DTOs;
using Loan.Application.Features.MerchantServices.Abstraction;
using Loan.Application.Features.MerchantServices.DTOs;
using Loan.DataAccess.Models;
using Loan.DataAccess.Persistence;
using Loan.DataAccess.Persistence.Repositories;

namespace Loan.Application.Features.BranchServices;

public class BranchService : IBranchService
{
    private readonly IAsyncRepository<Branch, AppDbContext> _branchRepository;
    private readonly IMapper _mapper;
    private readonly IMerchantService _merchantService;

    public BranchService(IAsyncRepository<Branch, AppDbContext> branchRepository,
        IMapper mapper, IMerchantService merchantService)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
        _merchantService = merchantService;
    }

    public async Task<BranchDto> CreateBranchAsync(BranchCreateDto branchDto)
    {
        if (branchDto == null)
        {
            throw new ArgumentNullException(nameof(branchDto));
        }

        MerchantDto merchant = await _merchantService.GetMerchantByIdAsync(branchDto.MerchantId);

        if (merchant is null)
        {
            throw new ArgumentNullException(nameof(merchant));
        }

        var branch = new Branch
        {
            Name = branchDto.Name,
            MerchantId = merchant.Id,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };

        branch = await _branchRepository.AddAsync(branch);

        var createdBranch = _mapper.Map<BranchDto>(branch);

        return createdBranch;
    }

    public async Task<BranchDto> GetBranchByIdAsync(int branchId)
    {
        Branch branch = await _branchRepository.GetAsync(m => m.Id == branchId);

        if (branch == null)
        {
            throw new ApplicationException("Branch does not exist");
        }

        var branchDto = _mapper.Map<BranchDto>(branch);

        return branchDto;
    }

    public async Task<IEnumerable<BranchDto>> GetAllBranchesAsync()
    {
        var allBranches = await _branchRepository.GetListAsync();

        IEnumerable<BranchDto> branches = _mapper.Map<IEnumerable<BranchDto>>(allBranches);

        return branches;
    }

    public async Task<BranchDto> UpdateBranchAsync(BranchDto branch)
    {
        var branchToUpdate = await _branchRepository.GetAsync(m => m.Id == branch.Id);

        if (branchToUpdate == null)
        {
            throw new ApplicationException("branch does not exist");
        }

        branchToUpdate.Name = branch.Name;
        branchToUpdate.ModifiedDate = DateTime.UtcNow;

        return _mapper.Map<BranchDto>(branchToUpdate);
    }

    public async Task DeleteBranchAsync(int branchId)
    {
        var branchToDelete = await _branchRepository.GetAsync(m => m.Id == branchId);

        if (branchToDelete == null)
        {
            throw new ApplicationException("branch does not exist");
        }

        await _branchRepository.DeleteAsync(branchToDelete);
    }
}