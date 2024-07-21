namespace ILPManagementSystem.Models.DTO
{
    public class SessionAttendanceDTO
    {
     public int  SessionId { get; set; }
     public int  TraineeId { get; set; }
     public Boolean Attendance { get; set; }
     public string Remarks { get; set; }


    }
}
