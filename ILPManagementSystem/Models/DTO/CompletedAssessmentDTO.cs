using System.Text.Json.Serialization;

namespace ILPManagementSystem.Models.DTO
{
    public class CompletedAssessmentDTO
    {
        [JsonPropertyName("assessmentId")]
        public string AssessmentIdString { get; set; }

        [JsonIgnore]
        public int AssessmentId
        {
            get
            {
                int.TryParse(AssessmentIdString, out int result);
                return result;
            }
        }

        [JsonPropertyName("traineeId")]
        public int TraineeId { get; set; }

        [JsonPropertyName("score")]
        public double Score { get; set; }
    }
}
