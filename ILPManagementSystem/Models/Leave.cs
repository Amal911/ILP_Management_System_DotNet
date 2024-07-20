namespace ILPManagementSystem.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public int NumofDays { get; set; }
        public DateTime LeaveDate { get; set; }
        public DateTime LeaveDateFrom { get; set; }
        public DateTime LeaveDateTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
    }
}
