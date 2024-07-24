using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models
{
    public class Trainee
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Batch")]
        public int BatchId { get; set; }

        public User User { get; set; }
        public Batch Batch { get; set; }
    }
}
