using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IBatchRepository
    {
        Task<IEnumerable< Batch>> GetBatchData();
    }
}
