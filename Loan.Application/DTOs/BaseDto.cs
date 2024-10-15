namespace Loan.Application.DTOs;

public abstract record BaseDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}