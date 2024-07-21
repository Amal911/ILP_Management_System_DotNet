using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Repository
{
    public class PhaseAssessmentTypeMappingRepository
    {

        private readonly ApiContext _context;

        public PhaseAssessmentTypeMappingRepository(ApiContext _context)
        {
            this._context = _context;
        }

        public async Task AddPhaseAssessmentMapping(PhaseAssessmentTypeMapping phaseAssessment)
        {
            _context.PhaseAssessmentTypeMappings.Add(phaseAssessment);
            _context.SaveChanges();

        }
    }
}
