using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface ILeaveRepository
    {
        Task<IEnumerable<Leave>> GetAllLeavesAsync();
        Task<Leave> GetLeaveByIdAsync(int id);
        Task<Leave> AddLeaveAsync(Leave leave);
        Task<Leave> UpdateLeaveAsync(Leave leave);
        Task<bool> DeleteLeaveAsync(int id);
    }
}
