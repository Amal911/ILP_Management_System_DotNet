using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IBatchRepository
    {
        Task<IEnumerable< Batch>> GetBatchData();
        Task<IEnumerable<object>> GetBatches();
        Task<IEnumerable<object>> GetDetailedBatchData();
        Task<IEnumerable<object>> GetBatchDetailById(int Id);
        Task<int> AddNewBatch(Batch batch);
        Task<IEnumerable<object>> GetBatchByProgram(int programId);
        Task<IEnumerable<object>> GetBatchTraineeList(int Id);
    }
}
