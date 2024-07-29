using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository
{
    public class OnlineAssessmentRepository : IOnlineAssessmentRepository
    {
        private ApiContext _context;
        public OnlineAssessmentRepository(ApiContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(OnlineAssessment onlineAssessment)
        {
            _context.OnlineAssessments.Add(onlineAssessment);
        }

        public async Task<ICollection<OnlineAssessment>> GetAllAsync()
        {
            return await _context.OnlineAssessments.ToListAsync();
        }

        public async Task<OnlineAssessment> GetAsync(int batchId)
        {
            return await _context.OnlineAssessments.FirstOrDefaultAsync(c => c.batchId == batchId);
        }
        
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
