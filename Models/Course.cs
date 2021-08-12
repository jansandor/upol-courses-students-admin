using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cv8_mvc.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [MaxLength(30)]
        [Display(Name = "Course Abbr.")]
        public string CourseNameAbbreviation { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        // 1:N one course has many students enrolled via joining entity
        public List<StudentCourse> StudentCourses { get; set; }
    }
}