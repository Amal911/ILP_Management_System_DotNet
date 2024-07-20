using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IAssessmentTypeRepository
    {
        Task<IEnumerable<AssessmentType>> GetAllAssessmentTypeAsync();
        Task DeleteAssessmentTypeById(int id);

    }
}
