using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IBatchKnowlixRepository
    {
        
            Task <IEnumerable<BatchKnowlixDTO>> GetAllAsync();
    }
}
