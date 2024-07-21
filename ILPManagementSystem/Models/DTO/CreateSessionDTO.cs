namespace ILPManagementSystem.Models.DTO
{
    public class CreateSessionDTO
    {
        public string SessionName { get; set; }
        public string SessionDescription { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int trainerId { get; set; }
        public int topicid { get; set; }
    }
}
