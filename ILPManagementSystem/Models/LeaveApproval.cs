using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ILPManagementSystem.Models
{
    public class LeaveApproval
    {
        public int Id { get; set; }

        [ForeignKey("Leaves")]
        public int LeavesId { get; set; }

        [ForeignKey("User")]
        public int userId { get; set; }

        [AllowNull]
        public bool? IsApproved { get; set; }

        public Leave Leaves { get; set; }
        public User User { get; set; }
    }
}
