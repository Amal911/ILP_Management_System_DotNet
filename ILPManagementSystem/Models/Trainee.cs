using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [NotMapped]
        public User User { get; set; }

        [ForeignKey("Batch")]
        public int  BatchId { get; set; }
        [NotMapped]
        public Batch Batch { get; set; }    
    }
}
