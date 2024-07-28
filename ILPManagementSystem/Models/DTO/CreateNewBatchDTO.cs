namespace ILPManagementSystem.Models.DTO
{
    public class CreateNewBatchDTO
    {
        public CreateBatchDTO BatchDetails { get; set; }
        public IEnumerable<CreateBatchPhaseDTO> PhaseDetails { get; set; }

        public IEnumerable<UserDTO> TraineeList { get; set; }
    }
}
