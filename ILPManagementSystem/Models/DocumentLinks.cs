using System.ComponentModel.DataAnnotations;

namespace ILPManagementSystem.Models
{
    public enum DocumentType
    {
        document,
        link
    }
    public class DocumentLinks
    {
        [Key]
        public int Id { get; set; }
        public int AssessmentId { get; set; }
        public string DocumentUrl { get; set; }
        public DocumentType documentType {  get; set; } 
    }
}
