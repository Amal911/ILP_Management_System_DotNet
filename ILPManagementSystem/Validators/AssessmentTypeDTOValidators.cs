using FluentValidation;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Models.Validators
{
    public class AssessmentTypeDTOValidator : AbstractValidator<AssessmentTypeDTO>
    {
        public AssessmentTypeDTOValidator()
        {
            RuleFor(x => x.AssessmentTypeName)
                .NotEmpty().WithMessage("Assessment type name is required.")
                .MaximumLength(100).WithMessage("Assessment type name cannot exceed 100 characters.");
        }
    }
}
