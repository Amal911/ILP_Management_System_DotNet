﻿using System.Reflection;

namespace ILPManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string MobileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }


    }
}
