using cv8_mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace cv8_mvc.ViewModels
{
    public class GradeSelectListVM
    {
        public string ViewModelName { get; set; }
        public List<SelectListItem> Grades { get; }

        public GradeSelectListVM(List<Grade> grades, string vmName)
        {
            ViewModelName = vmName;
            Grades = new List<SelectListItem>(grades.Count);
            foreach (var grade in grades)
            {
                Grades.Add(
                    new SelectListItem
                    {
                        Value = grade.GradeId.ToString(),
                        Text = grade.Value
                    });
            }
        }
    }
}