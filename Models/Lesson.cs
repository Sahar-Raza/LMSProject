using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSProject.Models
{
    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }

        [Required]
        [StringLength(200)]
        public string LessonTitle { get; set; }

        [Required]
        public string LessonContent { get; set; }

        [Required]
        public int ModuleID { get; set; }

        [ForeignKey("ModuleID")]
        public Module Module { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Lesson()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            // Parameterless constructor required by EF Core
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Lesson(string lessonTitle, string lessonContent, int moduleID)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            LessonTitle = lessonTitle;
            LessonContent = lessonContent;
            ModuleID = moduleID;
        }
    }
}
