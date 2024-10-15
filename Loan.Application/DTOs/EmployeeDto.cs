using Loan.DataAccess.Models;

namespace Loan.Application.DTOs;

public record EmployeeDto:BaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }

    public Branch Branch { get; set; }
    public AppUser User { get; set; }
}

