namespace LMSProject.Models
{
    public class Grade
    {
        public int GradeID { get; set; }
        public int SubmissionID { get; set; }
        public decimal GradeValue { get; set; }
        public string Feedback { get; set; }

        public Grade(int gradeID, int submissionID, decimal gradeValue, string feedback)
        {
            GradeID = gradeID;
            SubmissionID = submissionID;
            GradeValue = gradeValue;
            Feedback = feedback;
        }
    }
}
