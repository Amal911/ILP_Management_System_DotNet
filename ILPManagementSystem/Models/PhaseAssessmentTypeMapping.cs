using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models
{
    public class PhaseAssessmentTypeMapping
    {
        public int Id { get; set; }
        public int Weightage { get; set; }

        [ForeignKey("AssessmentType")]
        public int AssessmentTypeId { get; set; }
        [NotMapped]
        public AssessmentType AssessmentType { get; set; }

        [ForeignKey("Phase")]
        public int BatchPhaseId { get; set; }
        [NotMapped]
        public BatchPhase BatchPhase { get; set; }
    }
}
