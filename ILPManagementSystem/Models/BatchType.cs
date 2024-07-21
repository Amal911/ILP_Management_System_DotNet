using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ILPManagementSystem.Models
{
    public class BatchType
    {
        [Key]
        public int Id { get; set; }
        public string BatchTypeName { get; set; }
        [NotMapped]
        [JsonIgnore]
        public ICollection<Batch> Batches { get; set; }
    }
}
