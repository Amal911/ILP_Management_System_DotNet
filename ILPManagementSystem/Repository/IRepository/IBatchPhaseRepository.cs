using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IBatchPhaseRepository
    {
        Task<IEnumerable<BatchPhase>> GetAllBatchPhasesAsync();
    }
}
