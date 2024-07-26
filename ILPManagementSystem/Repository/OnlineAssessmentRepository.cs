using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository
{
    
    public class OnlineAssessmentRepository : IOnlineAssessmentRepository
    {
        private readonly ApiContext _context;
        private readonly IOnlineAssessmentRepository _onlineAssessmentRepository;
        private readonly IMapper _mapper;
        public OnlineAssessmentRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OnlineAssessment>> GetAllAsync()
        {
            return await _context.OnlineAssessments.ToListAsync();
        }
    }
}
