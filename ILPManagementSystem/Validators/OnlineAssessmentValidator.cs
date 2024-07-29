using FluentValidation;
using ILPManagementSystem.Models;

namespace ILPManagementSystem.Validators
{
    public class OnlineAssessmentValidator : AbstractValidator<OnlineAssessment>
    {
        public OnlineAssessmentValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be a positive integer.");

            RuleFor(x => x.OnlineAssessmentName)
                .NotEmpty()
                .WithMessage("Online Assessment Name is required.")
                .MaximumLength(100)
                .WithMessage("Online Assessment Name cannot exceed 100 characters.");

            RuleFor(x => x.CreatedByName)
                .NotEmpty()
                .WithMessage("Created By Name is required.")
                .MaximumLength(100)
                .WithMessage("Created By Name cannot exceed 100 characters.");

            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate)
                .WithMessage("Start Date must be on or before End Date.");


            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("End Date must be a future date.");

            RuleFor(x => x.OnlineAssessmentStatus)
                .InclusiveBetween(0, 5)
                .WithMessage("Online Assessment Status must be between 0 and 5.");

            RuleFor(x => x.link)
                .Matches(@"^(http|https)://")
                .WithMessage("Link must be a valid URL.");

            RuleFor(x => x.batchId)
                .GreaterThan(0)
                .WithMessage("Batch Id must be a positive integer.");
        }
    }
}
