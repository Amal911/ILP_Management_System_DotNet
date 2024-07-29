using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int userId {  get; set; }
        [NotMapped]
        public User User {  get; set; }

    }
}
