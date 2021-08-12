using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cv8_mvc.Models
{
    // enum db table
    public class Grade
    {
        public static string NoGradeYetValue => "-"; // asi neni uplne top reseni
        public int GradeId { get; set; }

        [MaxLength(1)]
        [Display(Name = "Grade")]
        public string Value { get; set; } // A, B, ..., F

        // one-to-many Grade has many Enrollments
        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}