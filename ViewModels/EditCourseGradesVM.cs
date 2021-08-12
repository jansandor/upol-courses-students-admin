using System.ComponentModel.DataAnnotations;
using cv8_mvc.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cv8_mvc.ViewModels
{
    public class EditCourseGradesVM{
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int CourseStatuteId { get; set; }

        [Display(Name = "Course Statute")]
        public CourseStatute CourseStatute { get; set; }

        public int GradeId { get; set; }
        public Grade CurrentGrade { get; set; }

        [Display(Name = "Student Grade")]
        public List<SelectListItem> Grades { get; set; }

        public EditCourseGradesVM(){}

        public EditCourseGradesVM(StudentCourse enrollment){
            StudentId = enrollment.StudentId;
            Student = enrollment.Student;
            CourseId = enrollment.CourseId;
            Course = enrollment.Course;
            CourseStatuteId = enrollment.CourseStatuteId;
            CourseStatute = enrollment.CourseStatute;

            GradeId = enrollment.GradeId;
            Grades = new List<SelectListItem>(); // se bude asi muset zvenci nastavit
            CurrentGrade = enrollment.StudentGrade;
        }
    }
}