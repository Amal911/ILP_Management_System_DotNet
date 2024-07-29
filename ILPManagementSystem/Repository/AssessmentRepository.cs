using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using ILPManagementSystem.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            await _context.Assessments.AddAsync(assessment);
            await _context.SaveChangesAsync();
        }

        public async Task SubmitMarks(CompletedAssessment completedAssessment)
        {
            await _context.CompletedAssessment.AddAsync(completedAssessment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Assessment>> GetAssessmentsByBatchId(int batchId)
        {
            return await _context.Assessments.Where(a => a.BatchId == batchId).ToListAsync();
        }

    }
}
