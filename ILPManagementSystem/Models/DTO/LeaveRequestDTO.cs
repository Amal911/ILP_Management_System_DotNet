namespace ILPManagementSystem.Models.DTO
{
    public class LeaveRequestDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int NumofDays { get; set; }
        public DateTime? LeaveDate { get; set; }
        public DateTime? LeaveDateFrom { get; set; }
        public DateTime? LeaveDateTo { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public List<bool?> IsPending { get; set; }

    }
}
