using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ILPManagementSystem.Models
{
    public class AssessmentType
    {
        public int Id { get; set; }
        public string AssessmentTypeName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public List<PhaseAssessmentTypeMapping> PhaseAssessmentTypeMappings { get; set; }
    }
}
