namespace ILPManagementSystem.Models
{
    public class Scorecard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DailyAssessment { get; set; }
        public int LiveAssessment { get; set; }
        public int ModuleAssessment { get; set; }
        public int CaseStudy { get; set; }
        public int Project { get; set; }
    }
}
