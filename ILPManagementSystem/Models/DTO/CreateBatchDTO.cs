namespace ILPManagementSystem.Models.DTO
{
    public class CreateBatchDTO
    {
        public string BatchName { get; set; }
        public string BatchCode { get; set; }
        public int batchId { get; set; }
        public int BatchDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProgramId { get; set; }
        public int LocationId { get; set; }
    }
}
