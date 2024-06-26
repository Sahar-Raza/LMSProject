using System;
using System.Collections.Generic;

namespace LMSProject.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation property
        public ICollection<UserCourse> UserCourses { get; set; }

        // Parameterless constructor required by EF Core
        public Course()
        {
            UserCourses = [];
        }

        // Additional constructor that binds to properties
        public Course(string courseName, string courseDescription, DateTime startDate, DateTime endDate)
        {
            CourseName = courseName;
            CourseDescription = courseDescription;
            StartDate = startDate;
            EndDate = endDate;
            UserCourses = [];
        }
    }
}
