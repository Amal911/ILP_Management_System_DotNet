using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
namespace ILPManagementSystem.Repository.IRepository;

public interface ISessionRepository
{
    Task<ICollection<SessionDTO>> GetAllAsync();
    Task<Session> GetAsync(int id);

    Task CreateAsync(Session session);

    Task UpdateAsync(Session coupon);

    Task RemoveAsync(Session coupon);

    Task <bool>SaveAsync();
    Task<SessionDTO> GetSessionDetails(int id);
}
