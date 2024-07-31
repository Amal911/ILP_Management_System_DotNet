using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface ILeaveRepository
    {
        Task<IEnumerable<Leave>> GetLeavesByUserIdAsync(int userId);
        Task<Trainee> GetTraineeByFullNameAsync(string fullName);
        Task<Leave> AddLeaveAsync(Leave leave);
        Task<LeaveApproval> AddLeaveApprovalAsync(LeaveApproval leaveApproval);
        Task<IEnumerable<Leave>> GetAllLeavesAsync(); //Task<IEnumerable<Leave>> GetLeaveRequests();
        Task<Leave> GetLeaveByIdAsync(int id);
        Task<Leave> GetLeaveForApprovalByIdAsync(int id);
        Task<Leave> UpdateLeaveAsync(Leave leave);
        Task<bool> DeleteLeaveAsync(int id);
        Task<User> GetUserByNameAsync(string firstName, string lastName);
        Task<Trainee> GetTraineeByUserIdAsync(int userId);
        Task<User>GetUserByIdAsync(int userId);
        Task<Trainee> GetTraineeWithBatchByIdAsync(int traineeId);
    }
}
