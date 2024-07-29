namespace ILPManagementSystem.Models.DTO
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public string SessionDescription { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int BatchId { get; set; }

        public int TrainerId { get; set; }
        public string TrainerName {  get; set; }
    }
}
