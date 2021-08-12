using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cv8_mvc.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Display(Name = "Personal Number")]
        public string PersonalNumber { get; set; }

        [MaxLength(30)]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [MaxLength(8)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Study Program Name")]
        public string StudyProgramName { get; set; }

        public string Faculty { get; set; }

        [Display(Name = "Study Program Code")]
        public string StudyProgramCode { get; set; }

        [MaxLength(1)]
        [Display(Name = "Study Form")]
        public string StudyForm { get; set; }

        [Display(Name = "Year of Study")]
        public int? YearOfStudy { get; set; }
        
        public string Specialization { get; set; }

        public string Email { get; set; }

        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [MaxLength(1)]
        public string Gender { get; set; }

        // 1:N one student is enrolled in many courses
        public List<StudentCourse> StudentCourses { get; set; }

        [Display(Name="Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}