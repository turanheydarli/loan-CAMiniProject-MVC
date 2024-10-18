using Loan.DataAccess.Models;

namespace Loan.Application.DTOs;

public record EmployeeDto : BaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }
    public Guid BranchId { get; set; }
    public Guid UserId { get; set; }

    public BranchDto Branch { get; set; }
    public AppUser User { get; set; }
}