using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;

namespace ILPManagementSystem.Repository
{
    public class AssessmentTypeRepository : IAssessmentTypeRepository
    {
        private ApiContext _context;
        public AssessmentTypeRepository(ApiContext _context)
        {
            this._context = _context;
        }
       

        public async Task AddNewAssessmentType(AssessmentType newAssessmentType) { 
            _context.AssessmentTypes.Add(newAssessmentType);
            await this._context.SaveChangesAsync();
        }
        public async Task<IEnumerable<AssessmentType>> GetAllAssessmentTypeAsync()
        {
            return this._context.AssessmentTypes;
        }
        public async Task DeleteAssessmentTypeById(int id)
        {
            var assessmentType = await _context.AssessmentTypes.FindAsync(id);
            if (assessmentType != null)
            {
                _context.AssessmentTypes.Remove(assessmentType);
                await _context.SaveChangesAsync();
            }
        }

    }
}
