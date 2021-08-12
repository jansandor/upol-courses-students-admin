using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cv8_mvc.Models
{
    // M:N joining table representing students enrolled in the course
    // contains the grade gained by concrete student in the concrete course
    // contains course statue, diff students can have diff course statutes
    public class StudentCourse
    {
        public int StudentId { get; set; } // FK
        public Student Student { get; set; }
        public int CourseId { get; set; } // FK
        public Course Course { get; set; }

        // one-to-many Grade - StudentCourse
        public int GradeId { get; set; }
        [Display(Name = "Student Grade")]
        public Grade StudentGrade { get; set; }

        // one-to-many CourseStatute - StudentCourse
        public int CourseStatuteId { get; set; }
        [Display(Name = "Course Statute")]
        public CourseStatute CourseStatute { get; set; }
    }
}