using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository;

public class LeaveRepository : ILeaveRepository
{
    private readonly ApiContext _context;

    public LeaveRepository(ApiContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Leave>> GetLeavesByUserIdAsync(int userId)
    {
        return await _context.Leaves
                             .Include(l => l.Trainee)
                             .ThenInclude(t => t.User)
                             .Where(l => l.Trainee.UserId == userId)
                             .ToListAsync();
    }

    public async Task<Trainee> GetTraineeByFullNameAsync(string fullName)
    {
        /*return await _context.Trainees.Include(t => t.User).FirstOrDefaultAsync(t => t.User.FirstName == firstName);*/
        return await _context.Trainees
                         .Include(t => t.User)
                         .FirstOrDefaultAsync(t => (t.User.FirstName + " " + t.User.LastName) == fullName);

    }

    public async Task<Leave> AddLeaveAsync(Leave leave)
    {
        _context.Leaves.Add(leave);
        await _context.SaveChangesAsync();
        return leave;
    }

    public async Task<LeaveApproval> AddLeaveApprovalAsync(LeaveApproval leaveApproval)
    {
        _context.LeaveApprovals.Add(leaveApproval);
        await _context.SaveChangesAsync();
        return leaveApproval;
    }

    public async Task<IEnumerable<Leave>> GetAllLeavesAsync()
    {
        /*return await _context.Leaves
        .Include(l => l.Trainee)
        .Include(l => l.LeaveApprovals)
            .ThenInclude(la => la.User)
        .ToListAsync();*/
        return await _context.Leaves.ToListAsync();
    }

    public async Task<Leave> GetLeaveByIdAsync(int id)
    {
        return await _context.Leaves
        .Include(l => l.Trainee)
        .Include(l => l.LeaveApprovals)
            .ThenInclude(la => la.User)
        .FirstOrDefaultAsync(l => l.Id == id);
        /*return await _context.Leaves.FindAsync(id);*/
    }

    public async Task<Leave> GetLeaveForApprovalByIdAsync(int id)
    {
        return await _context.Leaves.FindAsync(id);
    }

    public async Task<Leave> UpdateLeaveAsync(Leave leave)
    {
        _context.Leaves.Update(leave);
        await _context.SaveChangesAsync();
        return leave;
    }

    public async Task<bool> DeleteLeaveAsync(int id)
    {
        var leave = await _context.Leaves.FindAsync(id);
        if (leave == null) return false;

        _context.Leaves.Remove(leave);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<User> GetUserByNameAsync(string firstName, string lastName)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.FirstName == firstName && u.LastName == lastName);
    }

    public async Task<Trainee> GetTraineeByUserIdAsync(int userId)
    {
        return await _context.Trainees.FirstOrDefaultAsync(t => t.UserId == userId);
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<Trainee> GetTraineeWithBatchByIdAsync(int traineeId)
    {
        return await _context.Trainees
            .Include(t => t.Batch)
            .FirstOrDefaultAsync(t => t.Id == traineeId);
    }



}
