using FluentValidation;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Services
{
    public class PhaseService
    {
        private readonly IValidator<PhaseDTO> _phaseDTOValidator;

        public PhaseService(IValidator<PhaseDTO> phaseDTOValidator)
        {
            _phaseDTOValidator = phaseDTOValidator;
        }

        public void AddNewPhase(PhaseDTO phaseDTO)
        {
            FluentValidation.Results.ValidationResult result = _phaseDTOValidator.Validate(phaseDTO);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine($"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}");
                }
            }
            else
            {
                var phase = new Phase
                {
                    PhaseName = phaseDTO.PhaseName 
                };

                // Further processing of phase if needed
            }
        }
    }
}
