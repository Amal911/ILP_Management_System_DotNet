using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IBatchPhaseRepository
    {
        Task<IEnumerable<BatchPhase>> GetAllBatchPhasesAsync();
        Task<IEnumerable<object>> GetBatchPhasesByBatchIdAsync(int batchID);
        Task<int> AddNewBatchPhase(BatchPhase batchPhase);

    }
}
