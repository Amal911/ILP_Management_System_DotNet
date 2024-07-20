namespace ILPManagementSystem.Models
{
    public class LeaveApproval
    {
        public int Id { get; set; }
        public int LeavesId { get; set; }
        public int userId { get; set; }
        public bool IsApproved { get; set; }
    }
}
