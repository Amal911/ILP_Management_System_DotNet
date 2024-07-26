using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models.DTO
{
    public class LeaveDTO
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public string Name { get; set; }
        public int NumofDays { get; set; }
        public DateTime? LeaveDate { get; set; }
        public DateTime? LeaveDateFrom { get; set; }
        public DateTime? LeaveDateTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public Trainee Trainee { get; set; }
        public List<int> PocIds { get; set; } // List of POC User IDs
        public bool IsPending { get; set; }
        
    }
}
