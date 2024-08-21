using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private ApiContext _context;
        private IMapper _mapper;
        public AttendanceRepository(ApiContext _context,IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
            
        }
        public async Task AddAttendance(Attendance attendance)
        {
            _context.Add(attendance);
            await this._context.SaveChangesAsync();

        }
        public async Task DeleteAttendance(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null) {
                 _context.Remove(attendance);
                await this._context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Attendance>> GetAttendanceAsync()
        {
            return this._context.Attendances;
        }
        public async Task<IEnumerable<GetAttendanceBySessionIDDTO>> GetAttendanceBySessionIdAsync(int sessionId)
        {
            return await _context.Attendances
                .Where(a=>a.SessionId == sessionId)
                .Include(a=>a.Trainee)
                .ThenInclude(t=>t.User)
                .Select(a=>new GetAttendanceBySessionIDDTO
                {
                    TraineeId = a.TraineeId,
                    IsPresent=a.IsPresent,
                    Remarks=a.Remarks
                })
                .ToListAsync();
        }

        public async Task UpdateAttendance(GetAttendanceBySessionIDDTO attendance)
        {
            var existingAttendance = await _context.Attendances
                .FirstOrDefaultAsync(a => a.SessionId == attendance.SessionId && a.TraineeId == attendance.TraineeId);

            if (existingAttendance != null)
            {
                existingAttendance.IsPresent = attendance.IsPresent;
                existingAttendance.Remarks = attendance.Remarks ?? string.Empty;
                await _context.SaveChangesAsync();
            }
        }

    }
}
