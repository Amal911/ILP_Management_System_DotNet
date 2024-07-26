using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;

namespace ILPManagementSystem.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private ApiContext _context;
        public AttendanceRepository(ApiContext _context)
        {
            this._context = _context;
            
        }
        public async Task AddAttendance(Attendance attendance)
        {
            _context.Add(attendance);
            await this._context.SaveChangesAsync();

        }

        public async Task DeleteAttendance(int id)
        {
            _context.Remove(_context.Attendances.Find(id));
            await this._context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Attendance>> GetAttendanceAsync()
        {
            return this._context.Attendances;
        }
        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }

        public async Task<Attendance> UpdateAttendance(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await this._context.SaveChangesAsync();
            return attendance;


        }

       
    }
}
