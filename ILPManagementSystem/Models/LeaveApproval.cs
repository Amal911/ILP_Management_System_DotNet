using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models
{
    public class LeaveApproval
    {
        public int Id { get; set; }

        [ForeignKey("Leaves")]
        public int LeavesId { get; set; }

        [ForeignKey("User")]
        public int userId { get; set; }
        public bool? IsApproved { get; set; }

        public Leave Leaves { get; set; }
        public User User { get; set; }
    }
}
