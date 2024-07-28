using ILPManagementSystem.Models.DTO;
namespace ILPManagementSystem.Repository.IRepository
{
    public interface IExposedBatchRepository
    {
        Task<IEnumerable<ExposedBatchDTO>> GetAllAsync();
    }
}
