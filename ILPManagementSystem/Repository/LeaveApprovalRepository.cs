using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository
{
    public class LeaveApprovalRepository : ILeaveApprovalRepository
    {
        private readonly ApiContext _context;

        public LeaveApprovalRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveApproval>> GetAllApprovalsAsync()
        {
            return await _context.LeaveApprovals.ToListAsync();
        }

        public async Task<LeaveApproval> GetApprovalByIdAsync(int id)
        {
            return await _context.LeaveApprovals.FindAsync(id);
        }

        public async Task<LeaveApproval> AddApprovalAsync(LeaveApproval leaveApproval)
        {
            _context.LeaveApprovals.Add(leaveApproval);
            await _context.SaveChangesAsync();
            return leaveApproval;
        }

        public async Task<LeaveApproval> UpdateApprovalAsync(LeaveApproval leaveApproval)
        {
            _context.LeaveApprovals.Update(leaveApproval);
            await _context.SaveChangesAsync();
            return leaveApproval;
        }

        public async Task<bool> DeleteApprovalAsync(int id)
        {
            var leaveApproval = await _context.LeaveApprovals.FindAsync(id);
            if (leaveApproval == null) return false;

            _context.LeaveApprovals.Remove(leaveApproval);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
