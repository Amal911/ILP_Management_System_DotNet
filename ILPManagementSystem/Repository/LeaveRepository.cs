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


    public async Task<Trainee> GetTraineeByFirstNameAsync(string firstName)
    {
        return await _context.Trainees.Include(t => t.User).FirstOrDefaultAsync(t => t.User.FirstName == firstName);
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
        return await _context.Leaves.ToListAsync();
    }

    public async Task<Leave> GetLeaveByIdAsync(int id)
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
}



/*public async Task<Leave> AddLeaveAsync(Leave leave)
{
_context.Leaves.Add(leave);
await _context.SaveChangesAsync();
return leave;
}*/

/* public async Task AddLeaveAsync(LeaveDTO leaveDto)
{
 // Find the trainee by name
 var trainee = await _context.Trainees
                             .Include(t => t.User)
                             .FirstOrDefaultAsync(t => t.User.FirstName  == leaveDto.Name);
 if (trainee == null)
 {
     throw new Exception("Trainee not found");
 }

 var leave = new Leave
 {
     TraineeId = trainee.Id,
     NumofDays = leaveDto.NumofDays,
     LeaveDate = leaveDto.NumofDays == 1 ? leaveDto.LeaveDate ?? DateTime.MinValue : DateTime.MinValue,
     LeaveDateFrom = leaveDto.NumofDays > 1 ? leaveDto.LeaveDateFrom ?? DateTime.MinValue : DateTime.MinValue,
     LeaveDateTo = leaveDto.NumofDays > 1 ? leaveDto.LeaveDateTo ?? DateTime.MinValue : DateTime.MinValue,
     Reason = leaveDto.Reason,
     Description = leaveDto.Description
 };

 _context.Leaves.Add(leave);
 await _context.SaveChangesAsync();

 var leaveApprovals = leaveDto.PocIds.Select(pocId => new LeaveApproval
 {
     LeavesId = leave.Id,
     userId = pocId,
     IsApproved = false // default value
 }).ToList();

 _context.LeaveApprovals.AddRange(leaveApprovals);
 await _context.SaveChangesAsync();
}*/