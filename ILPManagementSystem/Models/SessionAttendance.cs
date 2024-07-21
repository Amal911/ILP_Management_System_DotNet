namespace ILPManagementSystem.Models
{
    public class SessionAttendance
    {

        public int Id { get; set; }

        public int SessionId { get; set; }

        public int TraineeId { get; set; }

        public Boolean Attendance { get; set; }

        public string Remarks { get; set; }

    }
}
