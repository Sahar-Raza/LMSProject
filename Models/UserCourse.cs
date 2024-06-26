namespace LMSProject.Models
{
    public class UserCourse
    {
        public int UserID { get; set; }
        public User? User { get; set; }

        public int CourseID { get; set; }
        public Course? Course { get; set; }
    }
}
