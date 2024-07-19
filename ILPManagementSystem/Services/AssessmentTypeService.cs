using FluentValidation;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models.Validators;

namespace ILPManagementSystem.Services
{
    public class AssessmentTypeService
    {
        private readonly IValidator<AssessmentTypeDTO> _assessmentTypeDTOValidator;
        public AssessmentTypeService(IValidator<AssessmentTypeDTO> assessmentTypeDTOValidator)
        {
            _assessmentTypeDTOValidator = assessmentTypeDTOValidator;
        }
        public void AddNewAssessmentType(AssessmentTypeDTO assessmentTypeDTO) {


            FluentValidation.Results.ValidationResult result = _assessmentTypeDTOValidator.Validate(assessmentTypeDTO);


            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine($"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}");
                }
            }
            else
            {
                var assessmentType = new AssessmentType
                {
                    AssessmentTypeName = assessmentTypeDTO.AssessmentTypeName
                };

            }

        }

    }
}
