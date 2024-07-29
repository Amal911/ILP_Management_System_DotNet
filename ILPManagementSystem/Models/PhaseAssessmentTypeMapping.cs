using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public BatchPhase BatchPhase { get; set; }
    }
}
