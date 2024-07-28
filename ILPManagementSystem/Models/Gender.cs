using System.ComponentModel;

namespace ILPManagementSystem.Models
{
    public enum Gender
    {
        [Description("Male")]
        Male = 1,
        [Description("Female")]
        Female = 2,
        [Description("Other")]
        Other = 3
    }
}
