using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IAssessmentRepository
    {
        Task<IEnumerable<Assessment>> GetAssessments();
        Task<Assessment> GetAssessmentById(int id);
        Task CreateAssessment(Assessment assessment);
        Task SubmitMarks(CompletedAssessment completedAssessment);
        Task<IEnumerable<Assessment>> GetAssessmentsByBatchId(int batchId); 
    }
}
