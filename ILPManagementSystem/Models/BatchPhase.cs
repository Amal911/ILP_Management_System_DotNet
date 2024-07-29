using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ILPManagementSystem.Models
{
    public class BatchPhase
    {
        public int Id { get; set; }
        public int NumberOfDays {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }

        [ForeignKey("Batch")]
        public int BatchId {  get; set; }
        [NotMapped]
        [JsonIgnore]
        public Batch Batch { get; set; }

        [ForeignKey("Phase")]
        public int PhaseId { get; set; }
        [NotMapped]

        public Phase Phase { get; set; }

        [NotMapped]
        public List<PhaseAssessmentTypeMapping> PhaseAssessmentTypeMappings { get; set; }
    }
    public enum Status 
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2
    }
}
