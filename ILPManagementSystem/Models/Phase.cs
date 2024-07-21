using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ILPManagementSystem.Models
{
    public class Phase
    {
        public int Id { get; set; }
        public string PhaseName { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<BatchPhase> BatchPhases { get; set; }

       
    }
}
