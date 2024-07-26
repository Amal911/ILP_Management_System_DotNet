using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        [ForeignKey("Trainer")]
        public int userId {  get; set; }
        [NotMapped]
        public User User {  get; set; }

    }
}
