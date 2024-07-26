using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models
{
    public class Assessment
    {
        public int Id { get; set; }
        public string AssessmentTitle { get; set; }
        public string Description { get; set; }
        public int TotalScore { get; set; }
        public bool IsSubmitable { get; set; }
        public DateTime DueDateTime { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("AssessmentType")]
        public int AssessmentTypeID { get; set; }
        [NotMapped]
        public AssessmentType AssessmentType { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        [NotMapped]
        public Trainer Trainer { get; set; }
    }
}
