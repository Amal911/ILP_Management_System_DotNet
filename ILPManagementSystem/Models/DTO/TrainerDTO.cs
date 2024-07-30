using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models.DTO
{
    public class TrainerDTO
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int userId { get; set; }
        [NotMapped]
        public User User { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
