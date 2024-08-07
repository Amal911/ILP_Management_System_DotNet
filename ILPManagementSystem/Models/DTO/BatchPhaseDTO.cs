namespace ILPManagementSystem.Models.DTO
{
    public class BatchPhaseDTO
    {
        public int BatchId { get; set; }

        public int PhaseId { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<PhaseAssessmentTypeMappingDTO> PhaseAssessmentTypeMappings { get; set; }


    }
}
