using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;


namespace ILPManagementSystem.Repository.IRepository
{
    public interface ISessionAttendanceRepository
    {
       Task<IEnumerable<SessionAttendance>> GetAllAttendancesAsync();

    }
}
