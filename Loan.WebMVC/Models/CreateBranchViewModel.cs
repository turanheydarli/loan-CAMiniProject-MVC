using Loan.Application.DTOs;

namespace Loan.WebMVC.Models;

public class CreateBranchViewModel
{
    public BranchDto Branch { get; set; }
    public AddressDto Address { get; set; }
}