using Loan.DataAccess.Models;

namespace Loan.Application.Features.EmployeeServices.DTOs;

public record EmployeeDto()
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } 
    public DateTime ModifiedDate { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }

    public Branch Branch { get; set; }
    public AppUser User { get; set; }
}

public record EmployeeCreateDto()
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    public string Position { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }

    public Branch Branch { get; set; }
    public AppUser User { get; set; }
}
