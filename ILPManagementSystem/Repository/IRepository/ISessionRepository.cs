using ILPManagementSystem.Models;
namespace ILPManagementSystem.Repository.IRepository;

public interface ISessionRepository
{
    Task<ICollection<Session>> GetAllAsync();
    Task<Session> GetAsync(int id);
    Task CreateAsync(Session session);

    Task UpdateAsync(Session coupon);

    Task RemoveAsync(Session coupon);

    Task <bool>SaveAsync();
}
