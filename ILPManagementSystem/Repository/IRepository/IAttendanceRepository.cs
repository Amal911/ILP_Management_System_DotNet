using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAttendanceAsync();
        Task<IEnumerable<GetAttendanceBySessionIDDTO>> GetAttendanceBySessionIdAsync(int id);
        Task AddAttendance(Attendance attendance);
        Task UpdateAttendance(Attendance attendance);
        Task DeleteAttendance(int id);
    }
}
