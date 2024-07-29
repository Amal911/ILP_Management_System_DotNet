using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IOnlineAssessmentRepository
    {
        Task<ICollection<OnlineAssessment>> GetAllAsync();
        Task<List<OnlineAssessment>> GetAsync(int batchId);

        Task CreateAsync(OnlineAssessment onlineAssessment);

        Task<bool> SaveAsync();
    }
}
