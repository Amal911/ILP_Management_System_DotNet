using FluentValidation;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;

namespace ILPManagementSystem.Services.ValidationServices
{
    public class BatchPhaseService
    {
        private readonly IValidator<BatchPhaseDTO> _batchPhaseDTOValidator;

        public BatchPhaseService(IValidator<BatchPhaseDTO> batchPhaseDTOValidator)
        {
            _batchPhaseDTOValidator = batchPhaseDTOValidator;
        }

        public void AddNewBatchPhase(BatchPhaseDTO batchPhaseDTO)
        {
            FluentValidation.Results.ValidationResult result = _batchPhaseDTOValidator.Validate(batchPhaseDTO);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine($"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}");
                }
            }
            else
            {
                var batchphase = new BatchPhase
                {
                    PhaseId = batchPhaseDTO.PhaseId
                };

                // Further processing of phase if needed
            }
        }
    }
}

