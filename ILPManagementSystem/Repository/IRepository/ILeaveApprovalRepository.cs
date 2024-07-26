﻿using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface ILeaveApprovalRepository
    {
        Task<LeaveApproval> GetLeaveApprovalAsync(int leaveId, int userId);
        Task<IEnumerable<LeaveApproval>> GetApprovalsByLeaveIdAsync(int leaveId);
        Task<IEnumerable<LeaveApproval>> GetAllApprovalsAsync();
        Task<LeaveApproval> GetApprovalByIdAsync(int id);
        Task<LeaveApproval> AddApprovalAsync(LeaveApproval leaveApproval);
        Task<LeaveApproval> UpdateApprovalAsync(LeaveApproval leaveApproval);
        Task<bool> DeleteApprovalAsync(int id);
    }
}
