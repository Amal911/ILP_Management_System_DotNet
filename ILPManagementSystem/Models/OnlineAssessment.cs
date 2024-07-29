using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ILPManagementSystem.Models
{
    public class OnlineAssessment
    {
        [Key]
        public int Id { get; set; }
        public string OnlineAssessmentName { get; set; }
        public string CreatedByName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OnlineAssessmentStatus { get; set; }
        public string link {  get; set; }
        public int batchId { get; set; }
        [NotMapped]
        [JsonIgnore]
        [ForeignKey("BatchId")]
        public Batch Batch { get; set; }
    }
}
