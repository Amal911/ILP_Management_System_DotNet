namespace ILPManagementSystem.Models.DTO
{
    public class UpdateBatchRequestDTO
    {
        public int Id { get; set; }  

        public string BatchName { get; set; }
        public string BatchCode { get; set; }
        public int BatchDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int ProgramId { get; set; }
        public int LocationId { get; set; }
        public int BatchTypeId { get; set; }

        public List<BatchPhaseDTO> BatchPhases { get; set; }
    }

    public class BatchPhasesDTO
    {
        public int Id { get; set; }  // ID of the phase

        public int NumberOfDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }

        public List<PhaseAssessmentTypeMappingDTO> PhaseAssessmentTypeMappings { get; set; }
    }

    public class PhaseAssessmentTypeMappingDTO
    {
        public int Id { get; set; } 

        public int AssessmentTypeId { get; set; }
        public int Weightage { get; set; }
    }
}
