using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface ICompletedAssessmentRepository
    {
        Task<IEnumerable<CompletedAssessmentDTO>> GetCompletedAssessment();
        Task<CompletedAssessmentDTO> GetCompletedAssessmentById(int Id);
    }
}
