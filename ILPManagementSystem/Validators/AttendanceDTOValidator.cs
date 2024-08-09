using FluentValidation;
using ILPManagementSystem.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace ILPManagementSystem.Models.Validators
{
    public class AttendanceDTOValidator:AbstractValidator<AttendanceDTO>
    {
        public AttendanceDTOValidator()
        {
                RuleFor(x => x.TraineeId)
                    .NotNull()
                    .WithMessage("TraineeId is required.");

                RuleFor(x => x.IsPresent)
                    .NotNull()
                    .WithMessage("IsPresent is required.");

        }
        internal ValidationResult Validate(AttendanceDTO attendanceDTO)
        {
            throw new NotImplementedException();
        }

    }
}

