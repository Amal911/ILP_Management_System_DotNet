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

    public async Task<IEnumerable<LeaveRequestDTO>> GetLeavesByUserIdAsync(int userId)
    {
        var leaves = await _context.Leaves
                               .Where(l => l.Trainee.UserId == userId)
                               .Include(l => l.Trainee)
                               .ThenInclude(t => t.User)
                               .Include(t => t.LeaveApprovals)
                               .ToListAsync();

        var leaveDtos = leaves.Select(l => new LeaveRequestDTO
        {
            Id = l.Id,
            CreatedDate = l.CreatedDate,
            NumofDays = l.NumofDays,
            LeaveDate = l.LeaveDate,
            LeaveDateFrom = l.LeaveDateFrom,
            LeaveDateTo = l.LeaveDateTo,
            Reason = l.Reason,
            Description = l.Description,
            IsPending = l.LeaveApprovals.Select(la => la.IsApproved).ToList()
        });

        return leaveDtos;
    }

    public async Task<IEnumerable<Leave>> GetAllLeavesAsync()
    {
        return await _context.Leaves.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<Trainee> GetTraineeByUserIDAsync(int userID)
    {
        return await _context.Trainees.Include(t => t.User).FirstOrDefaultAsync(t => t.UserId == userID);

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

    public async Task<Leave> GetLeaveByIdAsync(int id)
    {
        return await _context.Leaves
        .Include(l => l.Trainee)
        .Include(l => l.LeaveApprovals)
            .ThenInclude(la => la.User)
        .FirstOrDefaultAsync(l => l.Id == id);
        /*return await _context.Leaves.FindAsync(id);*/
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






    public async Task<Trainee> GetTraineeWithBatchByIdAsync(int traineeId)
    {
        return await _context.Trainees
            .Include(t => t.Batch)
            .FirstOrDefaultAsync(t => t.Id == traineeId);
    }

    public async Task<Leave> GetLeaveForApprovalByIdAsync(int id)
    {
        return await _context.Leaves.FindAsync(id);
    }

    public async Task<User> GetUserByNameAsync(string firstName, string lastName)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.FirstName == firstName && u.LastName == lastName);
    }

    public async Task<Trainee> GetTraineeByUserIdAsync(int userId)
    {
        return await _context.Trainees.FirstOrDefaultAsync(t => t.UserId == userId);
    }

    public async Task<IEnumerable<LeaveDTO>> GetAdminPendingRequestsAsync(int adminUserId)
    {
        return await _context.Leaves
            .Include(l => l.LeaveApprovals)
            .Include(l => l.Trainee)
                .ThenInclude(t => t.User) // Include the User entity
            .Where(l => l.LeaveApprovals.Any(la => la.userId == adminUserId && la.IsApproved == null))
            .Select(l => new LeaveDTO
            {
                Id = l.Id,
                Name = $"{l.Trainee.User.FirstName} {l.Trainee.User.LastName}", // Construct the full name
                NumofDays = l.NumofDays,
                LeaveDate = l.LeaveDate,
                LeaveDateFrom = l.LeaveDateFrom,
                LeaveDateTo = l.LeaveDateTo,
                CreatedDate = l.CreatedDate,
                Reason = l.Reason,
                Description = l.Description,
                PocIds = l.LeaveApprovals.Select(la => la.userId).ToList(),
                IsPending = l.LeaveApprovals.Any(la => la.IsApproved == null)
                // Approvals are not set here as it's marked with JsonIgnore
            })
            .ToListAsync();
    }

    /*public async Task<IEnumerable<Leave>> GetAdminPendingRequestsAsync()
    {
        return await _context.Leaves
            .Include(l => l.LeaveApprovals)
            .Include(l => l.Trainee)
            .Where(l => l.LeaveApprovals.Any(la => la.IsApproved == true) &&
                        l.LeaveApprovals.Any(la => la.IsApproved == null))
            .ToListAsync();
    }*/








}
