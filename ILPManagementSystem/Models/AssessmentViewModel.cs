namespace ILPManagementSystem.Models
{
    public class AssessmentViewModel
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public string AssessmentTitle { get; set; }
        public string Description { get; set; }
        public int? TotalScore { get; set; }
        public bool IsSubmitable { get; set; }
        public DateTime? DueDateTime { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentName { get; set; }
        public string DocumentContentType { get; set; }
        public int TotalCountOfTrainees { get; set; }
        public int TotalSubmits { get; set; }
    }
}
