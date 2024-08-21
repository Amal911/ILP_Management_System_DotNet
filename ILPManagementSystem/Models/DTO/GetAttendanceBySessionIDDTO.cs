namespace ILPManagementSystem.Models.DTO
{
    public class GetAttendanceBySessionIDDTO
    {
        public int TraineeId { get; set; }

        public int SessionId { get; set; }

        public bool IsPresent { get; set; }
        public string? Remarks { get; set; }
    }
}
