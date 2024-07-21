namespace ILPManagementSystem.Models
{
    public class BatchPhase
    {
        public int Id { get; set; }
        public int BatchId {  get; set; }
        public int PhaseId { get; set; }
        public int NumberOfDays {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean IsCompleted { get; set; }=false;
    }
}
