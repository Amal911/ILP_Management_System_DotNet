using ILPManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IBatchTypeRepository
    {
        Task<IEnumerable<BatchType>> GetBatchTypeData();
        Task AddBatchType(BatchType batchType);
        Task DeleteBatchType(int id);
    }
}
