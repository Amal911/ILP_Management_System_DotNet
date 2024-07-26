using FluentValidation;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Models.Validators
{
    public class BatchPhaseDTOValidators: AbstractValidator<BatchPhaseDTO>
    {
        public BatchPhaseDTOValidators()
        {
            RuleFor(batchPhase => batchPhase.NumberOfDays)
                .NotEmpty().WithMessage("Number of Days is required")
                .GreaterThan(0).WithMessage("Number of Days must be greater than 0");

            RuleFor(batchPhase => batchPhase.StartDate)
                .NotEmpty().WithMessage("Start Date is required")
                .LessThan(batchPhase => batchPhase.EndDate).WithMessage("Start Date must be before End Date");

            RuleFor(batchPhase => batchPhase.EndDate)
                .NotEmpty().WithMessage("End Date is required")
                .GreaterThan(batchPhase => batchPhase.StartDate).WithMessage("End Date must be after Start Date");
        }

    }
}
