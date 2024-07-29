using FluentValidation;
using ILPManagementSystem.Models.DTO;

public class UserDTOValidator : AbstractValidator<UserDTO>
{
    public UserDTOValidator()
    {
        RuleFor(dto => dto.EmailId).NotEmpty().WithMessage("Email is required.");
        RuleFor(dto => dto.MobileNumber).NotEmpty().MinimumLength(10).WithMessage("Mobile number is invalid");
        RuleFor(dto => dto.RoleId).NotEmpty().WithMessage("Role ID is required.");
        RuleFor(dto => dto.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(dto => dto.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(dto => dto.Gender).NotEmpty().WithMessage("Gender is required.");
    }
}
