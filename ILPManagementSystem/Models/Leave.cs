﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ILPManagementSystem.Models
{
    public class Leave
    {
        [NotMapped]
        public string Name { get; set; }
        public int Id { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public int NumofDays { get; set; }
        public DateTime LeaveDate { get; set; }
        public DateTime LeaveDateFrom { get; set; }
        public DateTime LeaveDateTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public Trainee Trainee { get; set; }

        public Leave()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
