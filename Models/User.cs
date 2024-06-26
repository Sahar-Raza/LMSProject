using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LMSProject.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Navigation property
        public ICollection<UserCourse> UserCourses { get; set; }

        // Constructor with parameters
        public User(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
            UserCourses = [];
        }

        // Default constructor
        public User()
        {
            UserCourses = [];
        }

        // Method to validate email
        public bool IsValidEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                return addr.Address == Email;
            }
            catch
            {
                return false;
            }
        }
    }
}
