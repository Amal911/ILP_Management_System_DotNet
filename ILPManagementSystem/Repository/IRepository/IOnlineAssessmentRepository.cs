using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IOnlineAssessmentRepository
    {
        Task<IEnumerable<OnlineAssessment>> GetAllAsync();
        Task CreateAsync(OnlineAssessment onlineAssessment);
        Task<bool> SaveAsync();


    }
}
