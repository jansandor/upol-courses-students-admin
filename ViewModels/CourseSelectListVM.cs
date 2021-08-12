using cv8_mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace cv8_mvc.ViewModels
{
    public class CourseSelectListVM
    {
        public string ViewModelName { get; set; }
        public List<SelectListItem> Courses { get; }

        public CourseSelectListVM(List<Course> courses, string vmName)
        {
            ViewModelName = vmName;
            Courses = new List<SelectListItem>(courses.Count);
            foreach (var course in courses)
            {
                Courses.Add(
                    new SelectListItem
                    {
                        Value = course.CourseId.ToString(),
                        Text = course.CourseNameAbbreviation
                    });
            }
        }
    }
}