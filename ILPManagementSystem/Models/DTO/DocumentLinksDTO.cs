namespace ILPManagementSystem.Models.DTO
{
    public class DocumentLinksDTO
    {
        public int Id { get; set; }
        public int AssessmentId { get; set; }
        public string DocumentUrl { get; set; }
        public string DocumentType { get; set; }

    }
}
