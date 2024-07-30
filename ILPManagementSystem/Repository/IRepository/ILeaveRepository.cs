using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface ILeaveRepository
    {
        Task<IEnumerable<LeaveRequestDTO>> GetLeavesByUserIdAsync(int userId);
        Task<IEnumerable<Leave>> GetAllLeavesAsync();
        Task<Trainee> GetTraineeWithBatchByIdAsync(int traineeId);
        Task<User> GetUserByIdAsync(int userId);
        Task<Trainee> GetTraineeByUserIDAsync(int UserID);
        Task<Leave> AddLeaveAsync(Leave leave);
        Task<LeaveApproval> AddLeaveApprovalAsync(LeaveApproval leaveApproval);
        Task<Leave> GetLeaveByIdAsync(int id);
        Task<Leave> UpdateLeaveAsync(Leave leave);
        Task<bool> DeleteLeaveAsync(int id);


        Task<IEnumerable<LeaveDTO>> GetAdminPendingRequestsAsync(int adminUserId);
        Task<Leave> GetLeaveForApprovalByIdAsync(int id);
        Task<User> GetUserByNameAsync(string firstName, string lastName);
        Task<Trainee> GetTraineeByUserIdAsync(int userId);
        
    }
}
