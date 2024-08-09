namespace ILPManagementSystem.Models.DTO
{
    public class AttendanceDTO
    {
        public int TraineeId { get; set; }

        public int SessionId {  get; set; }

        public Boolean IsPresent { get; set; }

        public string? Remarks { get; set; }
    }
}
