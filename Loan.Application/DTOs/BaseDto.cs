namespace Loan.Application.DTOs;

public abstract record BaseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}