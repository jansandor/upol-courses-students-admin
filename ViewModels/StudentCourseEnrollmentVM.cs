using System.Collections.Generic;
using cv8_mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace cv8_mvc.ViewModels
{
    public class StudentCourseEnrollmentVM
    {
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Display(Name = "Course Statute")]
        public int CourseStatuteId { get; set; }

        [Display(Name = "Grade")]
        public int GradeId { get; set; }

        public List<SelectListItem> Students { get; set; }
        public List<SelectListItem> Courses { get; set; }
        public List<SelectListItem> CourseStatutes { get; set; }
        public List<SelectListItem> Grades { get; set; }

        public StudentCourseEnrollmentVM()
        {
            Students = new List<SelectListItem>();
            Courses = new List<SelectListItem>();
            CourseStatutes = new List<SelectListItem>();
            Grades = new List<SelectListItem>();
        }

        public StudentCourseEnrollmentVM(List<Student> students, List<Course> courses, List<CourseStatute> statutes)
        {
            Students = new List<SelectListItem>(students.Count);
            Courses = new List<SelectListItem>(courses.Count);
            CourseStatutes = new List<SelectListItem>(statutes.Count);
            foreach (var student in students)
            {
                Students.Add(new SelectListItem
                {
                    Value = student.StudentId.ToString(),
                    Text = $"{student.FirstName} {student.LastName}"
                });
            }
            foreach (var course in courses)
            {
                Courses.Add(new SelectListItem
                {
                    Value = course.CourseId.ToString(),
                    Text = course.CourseNameAbbreviation
                });
            }
            foreach (var statute in statutes)
            {
                CourseStatutes.Add(new SelectListItem
                {
                    Value = statute.CourseStatuteId.ToString(),
                    Text = statute.Value
                });
            }
        }
    }
}