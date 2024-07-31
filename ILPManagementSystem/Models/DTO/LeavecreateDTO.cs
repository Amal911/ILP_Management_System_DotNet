namespace ILPManagementSystem.Models.DTO
{
    public class LeavecreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public int NumofDays { get; set; }
        public DateTime? LeaveDate { get; set; }
        public DateTime? LeaveDateFrom { get; set; }
        public DateTime? LeaveDateTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public List<int> PocIds { get; set; } // List of POC User IDs
        public bool IsPending { get; set; }
    }
}
