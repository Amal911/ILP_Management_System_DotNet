using FluentValidation;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Services.ValidationServices
{
    public class AssessmentTypeService
    {
        private readonly IValidator<AssessmentTypeDTO> _assessmentTypeDTOValidator;
        public AssessmentTypeService(IValidator<AssessmentTypeDTO> assessmentTypeDTOValidator)
        {
            _assessmentTypeDTOValidator = assessmentTypeDTOValidator;
        }
        public void ValidationAddNewAssessmentType(AssessmentTypeDTO assessmentTypeDTO)
        {


            FluentValidation.Results.ValidationResult result = _assessmentTypeDTOValidator.Validate(assessmentTypeDTO);


            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine($"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}");
                }
            }

        }

    }
}
