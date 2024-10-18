using Loan.Application.DTOs;

namespace Loan.WebMVC.Models;

public class CreateEmployeeViewModel
{
    public Guid BranchId { get; set; }
    public EmployeeDto Employee { get; set; }
    public List<BranchDto> Branches { get; set; }
}