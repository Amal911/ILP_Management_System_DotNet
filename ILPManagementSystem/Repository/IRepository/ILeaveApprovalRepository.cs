using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface ILeaveApprovalRepository
    {
        Task<IEnumerable<LeaveApproval>> GetAllApprovalsAsync();
        Task<LeaveApproval> GetApprovalByIdAsync(int id);
        Task<LeaveApproval> AddApprovalAsync(LeaveApproval leaveApproval);
        Task<LeaveApproval> UpdateApprovalAsync(LeaveApproval leaveApproval);
        Task<bool> DeleteApprovalAsync(int id);
    }
}
