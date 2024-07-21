namespace ILPManagementSystem.Models.DTO
{
    public class UserDTO
    {
        public string EmailId { get; set; }
        public int RoleId { get; set; }
        public string MobileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }
    }
}
