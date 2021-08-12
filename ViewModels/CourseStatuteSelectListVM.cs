using cv8_mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace cv8_mvc.ViewModels
{
    public class CourseStatuteSelectListVM
    {
        public string ViewModelName { get; }
        public List<SelectListItem> CourseStatutes { get; }

        public CourseStatuteSelectListVM(List<CourseStatute> statutes, string vmName)
        {
            ViewModelName = vmName;
            CourseStatutes = new List<SelectListItem>(statutes.Count);
            foreach (var statute in statutes)
            {
                CourseStatutes.Add(
                    new SelectListItem
                    {
                        Value = statute.CourseStatuteId.ToString(),
                        Text = statute.Value
                    });
            }
        }
    }
}