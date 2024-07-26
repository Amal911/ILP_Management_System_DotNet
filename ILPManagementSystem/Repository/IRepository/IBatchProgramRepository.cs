using ILPManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IBatchProgramRepository
    {
        Task<IEnumerable<BatchProgram>> GetBatchProgramsAsync();
        Task<BatchProgram> GetBatchProgramsAsync(int Id);
        Task CreateBatchProgramAsync(BatchProgram batchProgram);
        Task UpdateBatchProgramAsync(int Id,BatchProgram batchProgram);
        Task DeleteBatchProgramAsync(int Id);
    }
}
