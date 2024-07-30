using Microsoft.AspNetCore.Http;

namespace ILPManagementSystem.Models.DTO
{
    public class CreateAssessmentDTO
    {
        public int BatchId { get; set; }
        public int PhaseId { get; set; }
        public string AssessmentTitle { get; set; }
        public string? Description { get; set; }
        public int TotalScore { get; set; }
        public bool IsSubmitable { get; set; }
        public int UserId { get; set; }
        public int AssessmentTypeID { get; set; }
        public DateTime? DueDateTime { get; set; } 
        public IFormFile? Document { get; set; } 
        public List<CompletedAssessmentDTO>? Marks { get; set; }

    }
}