using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public string SessionDescription { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int TrainerId { get; set; }
        public int BatchId { get; set; }

        [ForeignKey("TrainerId")]
        public Trainer Trainer { get; set; }

        [ForeignKey("BatchId")]
        public Batch Batch { get; set; }



    }
}
