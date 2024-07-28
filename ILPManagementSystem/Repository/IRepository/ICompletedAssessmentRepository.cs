using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface ICompletedAssessmentRepository
    {
        Task<CompletedAssessment> GetByIdAsync(int id);
        Task<IEnumerable<CompletedAssessment>> GetAllAsync();
        Task<CompletedAssessment> AddAsync(CompletedAssessment completedAssessment);
    }
}
