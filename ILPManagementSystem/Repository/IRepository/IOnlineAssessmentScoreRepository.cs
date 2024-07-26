using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IOnlineAssessmentScoreRepository
    {
        Task<IEnumerable<OnlineAssessmentScore>> GetAllAsync();
    }
}
