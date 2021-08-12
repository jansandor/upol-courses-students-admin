using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cv8_mvc.Models
{
    // enum db table
    public class CourseStatute
    {
        public int CourseStatuteId { get; set; }

        [MaxLength(1)]
        [Display(Name = "Course Statute")]
        public string Value { get; set; } // A, B, C

        // one-to-many CourseStatute has many Enrollments
        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}