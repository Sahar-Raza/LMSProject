using System;

namespace LMSProject.Models
{
    public class Submission
    {
        public int SubmissionID { get; set; }
        public int AssignmentID { get; set; }
        public int StudentID { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string SubmissionContent { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Submission()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            // Parameterless constructor required by EF Core
        }

        public Submission(int submissionID, int assignmentID, int studentID, DateTime submissionDate, string submissionContent)
        {
            SubmissionID = submissionID;
            AssignmentID = assignmentID;
            StudentID = studentID;
            SubmissionDate = submissionDate;
            SubmissionContent = submissionContent;
        }
    }
}
