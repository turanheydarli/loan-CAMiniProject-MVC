using FluentValidation;
using Loan.Application.DTOs;

namespace Loan.Application.Validators;

public class MerchantValidator : AbstractValidator<MerchantDto>
{
    public MerchantValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.User.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.User.PhoneNumber).Matches(@"^\+?\d{10,15}$");

        RuleFor(x => x.BusinessLicense.File)
            .NotNull().WithMessage("Please upload your Business License.")
            .Must(file =>
                file == null || (file.ContentType == "application/pdf" || file.ContentType.StartsWith("image/")))
            .WithMessage("Only PDF or image files are allowed for Business License.")
            .Must(file => file == null || file.Length <= 5 * 1024 * 1024)
            .WithMessage("Business License must be less than 5 MB.");

        RuleFor(x => x.RegistrationNotes)
            .MaximumLength(500).WithMessage("Additional Notes cannot exceed 500 characters.");
    }
}