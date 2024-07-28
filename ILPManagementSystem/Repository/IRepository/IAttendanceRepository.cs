using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAttendanceAsync();
        Task<Attendance> GetAttendanceByIdAsync(int id);
        Task AddAttendance(Attendance attendance);
        Task<Attendance> UpdateAttendance(Attendance attendance);
        Task DeleteAttendance(int id);
    }
}
