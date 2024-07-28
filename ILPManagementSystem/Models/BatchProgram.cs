using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ILPManagementSystem.Models
{
    public class BatchProgram
    {
        [Key]
        public int Id { get; set; }
        public string ProgramName { get; set; }

        [NotMapped]
        
        public IEnumerable<Batch> BatchList { get; set; }
    }
}
