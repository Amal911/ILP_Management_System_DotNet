using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IPhaseRepository
    {
        Task<IEnumerable<Phase>> GetAllPhasesAsync();
    }
}
