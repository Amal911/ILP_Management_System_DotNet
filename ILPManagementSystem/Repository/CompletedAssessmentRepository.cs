using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;

namespace ILPManagementSystem.Repository
{
    public class CompletedAssessmentRepository : ICompletedAssessmentRepository
    {
        private readonly ApiContext _context;

        public CompletedAssessmentRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<CompletedAssessment> GetByIdAsync(int id)
        {
            return await _context.CompletedAssessment.FindAsync(id);
        }

        public async Task<IEnumerable<CompletedAssessment>> GetAllAsync()
        {
            return  _context.CompletedAssessment.ToList();
        }

        public async Task<CompletedAssessment> AddAsync(CompletedAssessment completedAssessment)
        {
            completedAssessment.Comments = null;
            completedAssessment.Created = DateTime.UtcNow;
            completedAssessment.SubmissionTime = DateTime.UtcNow;
            await _context.CompletedAssessment.AddAsync(completedAssessment);
            await _context.SaveChangesAsync();
            return completedAssessment;
        }
    }
}

