using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using ILPManagementSystem.Data;
using AutoMapper;

namespace ILPManagementSystem.Repository
{
    public class AssessmentRepository:IAssessmentRepository
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public AssessmentRepository( ApiContext _context) { 
            this._context = _context;
        }
        public async Task<IEnumerable<Assessment>> GetAssessments()
        {
            return _context.Assessments;

        }

        public async Task<Assessment> GetAssessmentById(int id)
        {
            return _context.Assessments.Find(id);
        }
        public async Task CreateAssessment(Assessment assessment)
        {
            assessment.CreatedDate = DateTime.UtcNow;  
            _context.Assessments.Add(assessment);
            _context.SaveChanges();
        }
    }
}
