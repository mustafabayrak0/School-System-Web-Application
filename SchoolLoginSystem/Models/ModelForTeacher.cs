using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolLoginSystem.Models
{
    public class ModelForTeacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Column(TypeName="Varchar(20)")]
        public string TeacherName { get; set; }
        [Column(TypeName = "Varchar(10)")]

        public string TeacherPassword { get; set; }
    }
}
