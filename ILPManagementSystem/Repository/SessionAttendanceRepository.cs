
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;

namespace ILPManagementSystem.Repository
{
    public class SessionAttendanceRepository :ISessionAttendanceRepository
    {
        private  ApiContext _context;
        public SessionAttendanceRepository(ApiContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<SessionAttendance>> GetAllAttendancesAsync()
        {
            return this._context.SessionAttendances;
        }

        public async Task AddNewSessionAttendance(SessionAttendance sessionAttendance)
        {
            _context.SessionAttendances.Add(sessionAttendance);
            await this._context.SaveChangesAsync();
        }
    }
}
