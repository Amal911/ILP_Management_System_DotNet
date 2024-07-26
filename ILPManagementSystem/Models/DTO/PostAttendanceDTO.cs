namespace ILPManagementSystem.Models.DTO
{
    public class PostAttendanceDTO
    {
        public int SessionId { get; set; }
        public List<AttendanceSecondaryDTO> Attendees { get; set; }
    }
}
