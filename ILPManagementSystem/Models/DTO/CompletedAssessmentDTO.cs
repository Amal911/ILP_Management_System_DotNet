﻿namespace ILPManagementSystem.Models.DTO
{
    public class CompletedAssessmentDTO
    {
        public int Id { get; set; }
        public int AssessmentId { get; set; }
        public int TraineeId { get; set; }
        public double Score { get; set; }
        public string Comments { get; set; }
        public DateTime SubmissionTime { get; set; }
    }
}
