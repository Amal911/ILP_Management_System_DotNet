using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models
{
    public class Assessment
    {
        public int Id { get; set; }
        public int BatchId { get; set; }

        [ForeignKey("BatchId")]
        public Batch Batch { get; set; }
        public int PhaseId { get; set; }

        [ForeignKey("PhaseId")]
        public Phase Phase { get; set; }
        public string AssessmentTitle { get; set; }
        public string? Description { get; set; }
        public int? TotalScore { get; set; }
        public bool IsSubmitable { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int AssessmentTypeID { get; set; }

        [ForeignKey("AssessmentTypeID")]
        public AssessmentType AssessmentType { get; set; }
        public DateTime? DueDateTime { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? DocumentPath { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentContentType { get; set; }
    }
}
