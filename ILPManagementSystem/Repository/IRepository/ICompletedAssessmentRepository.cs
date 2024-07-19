using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface ICompletedAssessmentRepository
    {
        Task<IEnumerable<CompletedAssessment>> GetCompletedAssessments();
        Task<CompletedAssessment> GetCompletedAssessmentsById(int Id);
    }
}
