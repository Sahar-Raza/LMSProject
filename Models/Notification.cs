namespace LMSProject.Models
{
    public class Notification
    {
        public Notification(int v1, int v2, string v3, DateTime now)
        {
        }

        public int NotificationID { get; set; }
        public int UserID { get; set; }
        public string? NotificationMessage { get; set; }
        public DateTime NotificationDate { get; set; }
        public User? User { get; set; }
    }
}
