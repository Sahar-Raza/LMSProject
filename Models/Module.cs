using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMSProject.Models
{
    public class Module
    {
        [Key]
        public int ModuleID { get; set; }

        [Required]
        [StringLength(100)]
        public string? ModuleName { get; set; }

        public ICollection<Lesson> Lessons { get; set; } = [];
    }
}
