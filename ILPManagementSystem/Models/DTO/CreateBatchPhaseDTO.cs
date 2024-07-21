namespace ILPManagementSystem.Models.DTO
{
    public class CreateBatchPhaseDTO
    {
        public int NumberOfDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Boolean IsCompleted { get; set; } = false;
        public int BatchId { get; set; }
        public int PhaseId { get; set; }
        public IEnumerable<PhaseAssessmentMappingDTO> PhaseAssessmentMapping { get; set; }   
    }
}
