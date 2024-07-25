using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface ILeaveRepository
    {
        Task<Trainee> GetTraineeByFirstNameAsync(string firstName);
        Task<Leave> AddLeaveAsync(Leave leave);
        Task<LeaveApproval> AddLeaveApprovalAsync(LeaveApproval leaveApproval);
        Task<IEnumerable<Leave>> GetAllLeavesAsync();
        Task<Leave> GetLeaveByIdAsync(int id);
        Task<Leave> UpdateLeaveAsync(Leave leave);
        Task<bool> DeleteLeaveAsync(int id);
        Task<User> GetUserByNameAsync(string firstName, string lastName);
        Task<Trainee> GetTraineeByUserIdAsync(int userId);
    }
}
