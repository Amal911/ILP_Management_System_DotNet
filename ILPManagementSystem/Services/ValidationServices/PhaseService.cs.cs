using FluentValidation;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Services.ValidationServices
{
    public class PhaseService
    {
        private readonly IValidator<PhaseDTO> _phaseDTOValidator;

        public PhaseService(IValidator<PhaseDTO> phaseDTOValidator)
        {
            _phaseDTOValidator = phaseDTOValidator;
        }

        public FluentValidation.Results.ValidationResult ValidateAddNewPhase(PhaseDTO phaseDTO)
        {
            return _phaseDTOValidator.Validate(phaseDTO);
        }
       
    }
}
