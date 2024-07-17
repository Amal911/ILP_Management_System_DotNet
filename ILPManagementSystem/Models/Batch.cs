using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }
        public string BatchName { get; set; }
        public string BatchCode { get; set; }
        public int batchId { get; set; }
        public int BatchDuration  { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int ProgramId { get; set; }
        public int LocationId { get; set; }

/*        public BatchType BatchType { get; set; }
        public Location Location { get; set; }*/
    }
}
