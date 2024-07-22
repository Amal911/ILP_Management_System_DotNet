using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IAssessmentTypeRepository
    {
        Task<IEnumerable<AssessmentType>> GetAllAssessmentTypeAsync();
        Task AddNewAssessmentType(AssessmentType assessmentType);
        Task DeleteAssessmentTypeById(int id);

        Task<AssessmentType> UpdateAssessmentType(AssessmentType assessmentType);


    }
}
