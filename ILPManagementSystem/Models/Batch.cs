using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ILPManagementSystem.Models
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }
        public string BatchName { get; set; }
        public string BatchCode { get; set; }
        public int BatchDuration  { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int ProgramId { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [NotMapped]
        public Location Location { get; set; }
        [ForeignKey("BatchType")]
        public int BatchTypeId { get; set; }
        [NotMapped]
        public BatchType BatchType { get; set; }

        [NotMapped]
        public List<BatchPhase> BatchPhases{ get; set; }

        [NotMapped]
        public List<Trainee> TraineeList { get; set; }




    }
}
