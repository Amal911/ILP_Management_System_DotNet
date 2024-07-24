using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IPhaseRepository
    {
        Task<IEnumerable<Phase>> GetAllPhasesAsync();
        Task AddNewPhase(Phase phase);
        Task DeletePhase(int id);

        Task<Phase> UpdatePhase(Phase phase);
    }
}
