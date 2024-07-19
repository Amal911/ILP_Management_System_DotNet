using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;

namespace ILPManagementSystem.Repository
{
    public class CompletedAssessmentRepository:ICompletedAssessmentRepository
    {
        private readonly ApiContext _context;
        private readonly ICompletedAssessmentRepository _completedAssessmentRepository;
        private readonly IMapper _mapper;

        public CompletedAssessmentRepository()
        {
            this._context = _context;
        }
        public async Task<IEnumerable<CompletedAssessment>> GetCompletedAssessments()
        {
            return _context.CompletedAssessment;
        }

        public async Task<CompletedAssessment> GetCompletedAssessmentsById(int Id)
        {
            return _context.CompletedAssessment.Find(Id);
        }

       

       
    }
}
