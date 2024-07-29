using ILPManagementSystem.Models.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ILPManagementSystem.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public string SessionDescription { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int BatchId { get; set; }

        public int TrainerId { get; set; }
        [NotMapped]
        [ForeignKey("Trainer")]
        public Trainer Trainer { get; set; }
        [NotMapped]
        [JsonIgnore]
        [ForeignKey("BatchId")]
        public Batch Batch { get; set; }


    }
}
