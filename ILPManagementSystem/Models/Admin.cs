using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [NotMapped]
        public User User { get; set; }
    }
}
