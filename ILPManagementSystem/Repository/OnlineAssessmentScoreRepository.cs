using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository
{
    public class OnlineAssessmentScoreRepository : IOnlineAssessmentScoreRepository
    {
        private readonly ApiContext _context;
        private readonly IOnlineAssessmentScoreRepository _onlineAssessmentScoreRepository;
        private readonly IMapper _mapper;
        public OnlineAssessmentScoreRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OnlineAssessmentScore>> GetAllAsync()
        {
            return await _context.OnlineAssessmentScores.ToListAsync();
        }
    }
}
