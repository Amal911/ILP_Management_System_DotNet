using FluentValidation;
using ILPManagementSystem.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace ILPManagementSystem.Models.Validators
{
    public class PhaseDTOValidator:AbstractValidator<PhaseDTO>
    {
        public PhaseDTOValidator()
        {
            RuleFor(phase=>phase.PhaseName)
                .NotEmpty().WithMessage("Phase Name is required")
                .MaximumLength(50).WithMessage("Phase name should not exeed 50 characters");
        }

        internal ValidationResult Validate(PhaseDTO phaseDTO)
        {
            throw new NotImplementedException();
        }
    }
}
