using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Services
{
    public interface ICreateBatchService
    {
        Task CreateNewBatch(CreateBatchDTO batchDetails, IEnumerable<CreateBatchPhaseDTO> batchPhaseDetails, IEnumerable<UserDTO> traineeDetails  );
    }
}
