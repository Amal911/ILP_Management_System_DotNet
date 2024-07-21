namespace ILPManagementSystem.Models.DTO
{
    public class BatchDTO
    {
        public int Id { get; set; }
        public string BatchName { get; set; }
        public string BatchCode { get; set; }
        public int batchTypeId { get; set; }
        public string BatchType { get; set; }
        public int BatchDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int ProgramId { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
