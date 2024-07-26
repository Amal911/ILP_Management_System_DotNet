namespace ILPManagementSystem.Models
{
    public class OnlineAssessmentScore
    {
        public int Id { get; set; }
        public int traineeId { get; set; }
        public int assessmentId { get; set; }
        public int score { get; set; }
        public int totalScore { get; set; }

    }
}
