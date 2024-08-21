namespace ILPManagementSystem.Models.DTO
{
    public class GetAttendanceBySessionIDDTO
    {
        public int TraineeId { get; set; }
        public string TraineeName { get; set; }
        public bool IsPresent { get; set; }
        public string? Remarks { get; set; }
    }
}
