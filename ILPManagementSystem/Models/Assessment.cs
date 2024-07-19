﻿namespace ILPManagementSystem.Models
{
    public class Assessment
    {
        public int Id { get; set; }
        public string AssessmentTitle { get; set; }
        public string Description { get; set; }
        public int TotalScore { get; set; }
        public bool IsSubmitable { get; set; }
        public int TrainerId { get; set; }
        public int AssessmentTypeID { get; set; }
        public DateTime DueDateTime { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
