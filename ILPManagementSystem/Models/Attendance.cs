namespace ILPManagementSystem.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public int SessionId { get; set; }

        public int TraineeId {  get; set; }

        public  Boolean IsPresent {  get; set; }

        public string? Remarks { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
