﻿using System.ComponentModel.DataAnnotations;

namespace ILPManagementSystem.Models
{
    public class CompletedAssessment
    {
        [Key]
        public int Id { get; set; }
        public int AssessmentId { get; set; }
        public int TraineeId { get; set; }
        public double Score { get; set; }
        public string Comments { get; set; }
        public DateTime SubmissionTime { get; set; }
    }
}
