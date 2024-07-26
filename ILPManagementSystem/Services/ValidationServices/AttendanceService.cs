using FluentValidation;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Services.ValidationServices
{
    public class AttendanceService
    {
        private readonly IValidator<AttendanceDTO> _attendanceValidator;
        public AttendanceService(IValidator<AttendanceDTO> _attendanceValidator)
        {
            this._attendanceValidator = _attendanceValidator;

        }
        public void AddAttendance(AttendanceDTO attendanceDTO)
        {
            FluentValidation.Results.ValidationResult result = _attendanceValidator.Validate(attendanceDTO);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine($"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}");
                }
            }
            else
            {
                var attendance = new Attendance
                {
                    SessionId=attendanceDTO.SessionId,
                    TraineeId = attendanceDTO.TraineeId,
                    IsPresent = attendanceDTO.IsPresent,
                    Remarks = attendanceDTO.Remarks
                };
            }
        }


        public async Task UpdateAttendance(AttendanceDTO attendanceDTO)
        {
            FluentValidation.Results.ValidationResult result = _attendanceValidator.Validate(attendanceDTO);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine($"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}");
                }
            }
            else
            {
                var attendance = new Attendance
                {
                    SessionId = attendanceDTO.SessionId,
                    TraineeId = attendanceDTO.TraineeId,
                    IsPresent = attendanceDTO.IsPresent,
                    Remarks = attendanceDTO.Remarks
                };

            }
        }
    }
}
