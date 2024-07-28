using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ILPManagementSystem.Models
{
    public class Leave
    {
        public int Id { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public int NumofDays { get; set; }

        [AllowNull]
        public DateTime LeaveDate { get; set; }

        [AllowNull]
        public DateTime LeaveDateFrom { get; set; }

        [AllowNull]
        public DateTime LeaveDateTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public Trainee Trainee { get; set; }

        public Leave()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public ICollection<LeaveApproval> LeaveApprovals { get; set; } = new List<LeaveApproval>();
    }
}
